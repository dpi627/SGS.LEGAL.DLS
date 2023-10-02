using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Entity
{
    public record BOSS_DAILY : BaseModel
    {
        [Key]
        [Required]
        public long BD_ID { get; set; }
        [Required]
        public int DI_ID { get; set; }
        [Required]
        public string? COMPANY { get; set; }
        public string? BD_STA { get; set; } = BossDailyStatus.New;
        public string? BD_STA_NM { get; set; }
        public Ulid DOC_ID { get; set; }
        public string? SEC { get; set; }
        public string? CC { get; set; }
        public string? LOC { get; set; }
        public string? BOSS_NO { get; set; }
        public string? CST_NO { get; set; }
        public string? CST_NM { get; set; }
        public string? INV_NO { get; set; }
        public string? BILL_NO { get; set; }
        public string? RPT_NO { get; set; }
        public DateTime? INV_DT { get; set; }
        public string? CURR { get; set; }
        public decimal? INV_AMT { get; set; }
        public decimal? ACT_BALANCE { get; set; }
        public string? BUYER_NUMBER { get; set; }
        public string? INVOICE_PAYMENT_TERM { get; set; }
        public string? CUSTOMER_PAYMENT_TERM { get; set; }

        public string? COMPANY_NM { get; set; }
        public string? INV_AMT_DISP
        {
            get => INV_AMT?.ToString($"N{PRECISION}");
            set { }
        }
        public string? ACT_BALANCE_DISP
        {
            get => ACT_BALANCE?.ToString($"N{PRECISION}");
            set { }
        }
        public string INV_DT_DISP { get => INV_DT?.ToString("yyyy/MM/dd"); set { } }

        public int PRECISION { get; set; } = 0;
        public string? KEYWORD { get; set; }
        public DateTime? DATE_S { get; set; }
        public DateTime? DATE_E { get; set; }
    }
}
