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
        public string? CST_ADDR { get; set; }
        [Required]
        public string? CST_NO { get; set; }
        [Required]
        public string? BOSS_NO { get; set; }
        public string? CST_FAX { get; set; }
        public string? CST_MAIL { get; set; }
        public string? NOTICE { get; set; }
    }
}
