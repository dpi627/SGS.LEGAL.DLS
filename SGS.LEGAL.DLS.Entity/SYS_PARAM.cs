using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Entity
{
    public record SYS_PARAM : BaseModel
    {
        [Key]
        [Required]
        public int P_ID { get; set; }
        public string? P_CLS { get; set; }
        [Required]
        public string P_TXT { get; set; }
        public string? P_TXT_E { get; set; }
        public string? P_VAL { get; set; }
        public short? P_SEQ { get; set; }
        public bool IS_ACT { get; set; }
        public bool IS_DEL { get; set; }
        public string? EXT_1 { get; set; }
        public string? EXT_2 { get; set; }
    }
}
