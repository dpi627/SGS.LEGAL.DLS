using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service;

namespace SGS.LEGAL.DLS.Model
{
    public enum LetterType
    {
        /// <summary>
        /// 通知函 Notify
        /// </summary>
        NTF,
        /// <summary>
        /// 催收函 Dunning
        /// </summary>
        DUN,
        /// <summary>
        /// 存證信函 Deposit
        /// </summary>
        DPS,
        /// <summary>
        /// 收件回執 Receipt
        /// </summary>
        RCV
    }
    public enum FileType
    {
        /// <summary>
        /// 信函 Letter
        /// </summary>
        L,
        /// <summary>
        /// 信封 Envelope
        /// </summary>
        E,
        /// <summary>
        /// 收件回執 Receipt
        /// </summary>
        R,
    }

    /// <summary>
    /// 催款函
    /// </summary>
    /// <param name="LetterType">催款(信)函類型</param>
    /// <param name="SourceFile">來源檔案 (含副檔名，通常為範本檔)</param>
    /// <param name="TargetFileName">目標檔案名稱 (不含副檔名，默認 .pdf)</param>
    /// <param name="FileType">檔案類型，例如催款函可能產出信函、信封、收件回執等</param>
    /// <param name="BackupFileName">備份檔案名稱 (不含副檔名，默認 .pdf)</param>
    public record Letter(LetterType LetterType, string SourceFile, string TargetFileName, FileType FileType = FileType.L, string? BackupFileName = default)
    {
        /// <summary>
        /// 第一筆 BOSS 資料ID，作為後續 join 使用
        /// </summary>
        public long BD_ID_1ST { get; set; }

        /// <summary>
        /// 這個建構子單純提供預覽PDF過渡使用
        /// </summary>
        /// <param name="LetterType">信函類型</param>
        /// <param name="FileType">檔案類型</param>
        /// <param name="FileReviewTempPathType">檢視PDF時，存儲下載檔案暫存路徑</param>
        public Letter(LetterType LetterType, FileType FileType, string ReviewTempPath) : this(LetterType, "", "", FileType)
        {
            this.ReviewTempPath = ReviewTempPath;
        }

        /// <summary>
        /// 取得信函參數檔設定
        /// </summary>
        private SYS_PARAM? letterSettings = new SysParamService(null)
            .Get("D_LETTER")?
            .Where(p => p.P_VAL == LetterType.ToString())?
            .FirstOrDefault();

        /// <summary>
        /// 暫存檔案副檔名，預設為 .pdf
        /// </summary>
        public string tempFileExtension = "pdf";
        /// <summary>
        /// 暫存資料夾，預設為專案內的資料夾 [temp]
        /// </summary>
        public string tempDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
        /// <summary>
        /// 輸出暫存完整路，預設為：暫存目錄\備份檔名
        /// </summary>
        public string TempFullPath  => Path.Combine(tempDir ?? "", $"{backupFileName}.{tempFileExtension}");

        /// <summary>
        /// 瀏覽已經產出之PDF，通常會下載到本機暫存
        /// </summary>
        public string ReviewTempPath { get; set; }

        /// <summary>
        /// 輸出檔案副檔名
        /// </summary>
        public string targetFileExtension = "pdf";
        /// <summary>
        /// 備份檔案副檔名
        /// </summary>
        public string backupFileExtension = "pdf";

        /// <summary>
        /// 目標檔案名稱，預設 信函類型+檔名
        /// </summary>
        private readonly string targetFileName = $"{LetterType}{FileType}_{TargetFileName}";
        private string TargetFile => $"{targetFileName}.{targetFileExtension}";

        /// <summary>
        /// 備份檔案名稱，預設 信函類型+檔名+時間戳記
        /// </summary>
        private readonly string backupFileName = string.IsNullOrEmpty(BackupFileName) ?
            $"{LetterType}{FileType}_{TargetFileName}_{DateTime.Now:yyyyMMddHHmmss}" :
            BackupFileName;
        private string BackupFile => $"{backupFileName}.{backupFileExtension}";

        /// <summary>
        /// 範本檔來源路徑(資料夾)，專案內範本檔資料夾 [template]
        /// </summary>
        private readonly string sourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template");

        /// <summary>
        /// 範本檔來源完整路徑
        /// </summary>
        public string SourceFullPath => Path.Combine(sourcePath, SourceFile);

        /// <summary>
        /// 路徑中間值，預設為日期
        /// </summary>
        private readonly string middlePath = DateTime.Today.ToString("yyyyMMdd");

        /// <summary>
        /// 輸出路徑(資料夾)
        /// </summary>
        public string TargetPath => Path.Combine(letterSettings?.EXT_1 ?? "", middlePath);
        /// <summary>
        /// 輸出完整路徑
        /// </summary>
        public string TargetFullPath => Path.Combine(letterSettings?.EXT_1 ?? "", middlePath, TargetFile);

        /// <summary>
        /// 備份路徑(資料夾)
        /// </summary>
        public string BackupPath => Path.Combine(letterSettings?.EXT_2 ?? "", middlePath);
        /// <summary>
        /// 備份完整路徑
        /// </summary>
        public string BackupFullPath => Path.Combine(letterSettings?.EXT_2 ?? "", middlePath, BackupFile);
    }
}

