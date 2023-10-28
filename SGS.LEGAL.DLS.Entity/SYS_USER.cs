using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Entity
{
    public record SYS_USER : BaseModel
    {
        [Key]
        [Required]
        public int U_ID { get; init; }
        [Required]
        public string? EMP_ID { get; set; } = "SYSOP";
        [Required]
        public string? AD_ID { get; set; }
        public string? USER_ID { get; set; }
        public string? USER_NM { get; set; }
        public string? USER_NM_E { get; set; }
        [Required]
        public string? PWD { get; set; }
        [Required]
        public string? EMAIL { get; set; }
        public string? DEPT_ID { get; set; }
        public string? DEPT_NM { get; set; }
        public string? ROLE_ID { get; set; }
        public string? GROUP_ID { get; set; }
        public bool? IS_ACT { get; set; }
        public DateTime? LAST_LOGIN { get; set; }
        public DateTime? LAST_PWD_CHG { get; set; }
        public string? USER_STA { get; set; }
        public string? USER_TIL { get; set; }
        public string? USER_TEL { get; set; }
        public string? USER_TEL_EXT { get; set; }

        public string? USER_DISP
        {
            get => $"{EMP_ID} {USER_NM} {USER_NM_E}";
            set { }
        }
    }
}
