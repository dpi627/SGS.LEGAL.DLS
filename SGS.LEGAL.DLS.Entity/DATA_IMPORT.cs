using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Entity
{
    public record DATA_IMPORT : BaseModel
    {
        [Key]
        [Required]
        public int DI_ID { get; set; }
        public DateTime? PROCESS_START { get; set; }
        public DateTime? PROCESS_END { get; set; }
        public bool? IS_MANUAL { get; set; }
        public string? FINISH_REASON { get; set; }
        public string? DI_STA { get; set; } = DataImportStatus.New;
        public string? DI_STA_NM { get; set; }
        public string? DI_STA_DISPAY { get; set; }
    }
}
