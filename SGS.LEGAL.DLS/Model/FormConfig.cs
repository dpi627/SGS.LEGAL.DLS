using System.DirectoryServices.AccountManagement;
using System.Drawing.Printing;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service;
using SGS.LIB.Common;
using SGS.LIMS.DB;

namespace SGS.LEGAL.DLS.Model
{
    public record FormConfig
    {
        private string? impPassword = null;
        private string? impUserID = null;

        #region property
        /// <summary>
        /// 目前使用者
        /// </summary>
        public SYS_USER? CurrentUser { get; set; }
        /// <summary>
        /// 特殊AD身分
        /// </summary>
        public Impersonator? Impersonator { get; private set; }
        /// <summary>
        /// 檔案類型
        /// </summary>
        public IList<SYS_PARAM> FileTypes { get; set; }
        /// <summary>
        /// 信函類型
        /// </summary>
        public IList<SYS_PARAM> LetterTypes { get; set; }
        /// <summary>
        /// 本機印表機
        /// </summary>
        public string[] DefaultPrinters { get; set; }
        /// <summary>
        /// 印表機紙匣 (預設第一台的紙匣)
        /// </summary>
        public List<PaperSource> DefaultPaperSources { get; set; }
        /// <summary>
        /// 自動更新設定檔路徑
        /// </summary>
        public string? UploadSettingFullPath { get; set; }
        /// <summary>
        /// 使用手冊路徑
        /// </summary>
        public string? UserManualFullPath { get; set; }
        #endregion

        /// <summary>
        /// 取得目前電腦AD帳號，取出工號後，再取得完整使用者資料
        /// </summary>
        public FormConfig SetCurrentUser(UserPrincipal? adUser = null)
        {
            UserPrincipal? AdUser = adUser ?? Utility.GetCurrentAdUser();
            if (AdUser == null)
                throw new Exception("無法取得使用者資料");
            using SysUserService svc = new();
            this.CurrentUser = svc.Get(AdUser?.EmployeeId);
            return this;
        }

        /// <summary>
        /// 切換指定AD帳號
        /// </summary>
        /// <param name="impUID">AD帳號</param>
        /// <param name="impPWD">AD密碼</param>
        public FormConfig SetImpersonator(string? impUID = null, string? impPWD = null)
        {
            if (impUID != null && impPWD != null)
            {
                this.impUserID = impUID;
                this.impPassword = impPWD;
            }
            else
            {
                using SGS.LIB.Common.ConfigReader cr = new();

                Dictionary<string, string?>? imp = cr.GetSection(
                    cr.GetValue("Enviroment")!,
                    "Impersonators"
                    );

                DbInfo db = new(
                    imp["Server"],
                    imp["Database"],
                    imp["Role"]
                );

                this.impUserID = db.ID_Decrypt;
                this.impPassword = db.PW_Decrypt;
            }

            this.Impersonator = new Impersonator(impUserID, impPassword);
            return this;
        }

        /// <summary>
        /// 設定通用系統參數
        /// </summary>
        /// <returns></returns>
        public FormConfig SetSystemData()
        {
            using SysParamService svc = new(this.CurrentUser);
            IList<SYS_PARAM>? sys = svc.Get("SYSTEM")!;
            //檔案類型
            this.UploadSettingFullPath = sys.Where(p => p.P_VAL == "AU").FirstOrDefault()?.EXT_1;
            //催款函類型
            this.UserManualFullPath = sys.Where(p => p.P_VAL == "UM").FirstOrDefault()?.EXT_1;
            return this;
        }

        /// <summary>
        /// 設定通用資料，避免資料庫IO
        /// </summary>
        /// <returns></returns>
        public FormConfig SetCommonData()
        {
            using SysParamService svc = new(this.CurrentUser);
            //檔案類型
            this.FileTypes = svc.Get("FILE")!;
            //催款函類型
            this.LetterTypes = svc.Get("D_LETTER")!;
            return this;
        }

        /// <summary>
        /// 設定本機印表機與紙匣
        /// </summary>
        public FormConfig SetPrinter()
        {
            // 取得本機的印表機清單，排除 Fax 與 無紙匣 項目
            this.DefaultPrinters = PrinterHelper.GetLocalPrinters();
            // 取得印表機的紙匣結構清單，排除 RawKind >= 1000 的項目
            this.DefaultPaperSources = PrinterHelper.GetPaperSources(this.DefaultPrinters[0]);
            return this;
        }
    }
}
