using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Entity
{
    /// <summary>
    /// 公司資料
    /// </summary>
    public record COMPANY() : BaseModel
    {
        [Key]
        [Required]
        public string? COM_CODE { get; set; }
        public string BRANCH_CODE { get; set; }
        public string? COM_NM { get; set; }
        public string? COM_NM_E { get; set; }
        public string? COM_ADDR { get; set; }
        public string? COM_ADDR_E1 { get; set; }
        public string? COM_ADDR_E2 { get; set; }
        public string? COM_ADDR_E3 { get; set; }
        public string? COM_TEL { get; set; }
        public string? COM_FAX { get; set; }
        /// <summary>
        /// 銀行帳戶名稱
        /// </summary>
        public string? BANK_ACT_NM { get; set; }
        /// <summary>
        /// 銀行名稱
        /// </summary>
        public string? BANK_NM { get; set; }
        /// <summary>
        /// 銀行帳號，依照公司規則不同
        /// </summary>
        public string? BANK_ACT { get; set; }
        public string? CHK_TIL { get; set; }
        public string? CHK_ADDR { get; set; }

        public string BUS_REG_ADDR { get; set; }
        public string CEO { get; set; }
    }
}
