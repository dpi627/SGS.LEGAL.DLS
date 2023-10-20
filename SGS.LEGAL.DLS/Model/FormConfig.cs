using System.DirectoryServices.AccountManagement;
using System.Drawing.Printing;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service;
using SGS.LIB.Common;

namespace SGS.LEGAL.DLS.Model
{
    public record FormConfig
    {
        // TODO: 要改抓資料庫
        private string impPassword = "OADApplicationPW!@#$%^02";
        private string impUserID = "efile_tw";

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
            if (impUID !=null && impPWD != null)
            {
                this.impUserID = impUID;
                this.impPassword = impPWD;
            }

            this.Impersonator = new Impersonator(impUserID, impPassword);
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
