using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Model
{
    /// <summary>
    /// 客戶資料結構
    /// </summary>
    public record Customer : BaseModel
    {
        [Required]
        public string? CST_NM { get; set; }
        [Required]
        public string? CST_DEPT { get; set; } = "財會部門";
        [Required]
        public string? CST_POST_CODE { get; set; }
        [Required]
        public string? CST_ADDR { get; set; }
        [Required]
        public string? CST_NO { get; set; }
        [Required]
        public string? BOSS_NO { get; set; }
        public string? CST_FAX { get; set; }
        public string? CST_MAIL { get; set; }
        public string? NOTICE { get; set; }

        /// <summary>
        /// 郵遞區號前三碼
        /// </summary>
        public string? CST_POST_CODE_1 => CST_POST_CODE?.Substring(0,3);
        /// <summary>
        /// 郵遞區號第四碼到最後
        /// </summary>
        public string? CST_POST_CODE_2 => CST_POST_CODE?.Substring(3);
    }
}
