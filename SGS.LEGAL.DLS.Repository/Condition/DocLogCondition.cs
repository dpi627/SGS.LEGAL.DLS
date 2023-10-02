namespace SGS.LEGAL.DLS.Repository.Condition
{
    public record DocLogCondition
    {
        public string COMPANY { get; set; }
        public string KEYWORD { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public IList<string>? LST_FIL_TYP { get; set; }
        public IList<string>? LST_LET_TYP { get; set; }
        public string? CRT_USER { get; set; }
    }
}
