namespace SGS.LEGAL.DLS.ViewModel
{
    public record DocLogViewModel
    {
        public string COMPANY { get; set; }
        public string COMPANY_NM { get; set; }
        public string BOSS_NO { get; set; }
        public string CST_NO { get; set; }
        public string CST_NM { get; set; }
        public string FIL_TYP { get; set; }
        public string LET_TYP { get; set; }
        public string FIL_TYP_NM { get; set; }
        public string LET_TYP_NM { get; set; }
        public string EMP_ID { get; set; }
        public string USER_NM { get; set; }
        public string BAK_PATH { get; set; }
        public string TIME_STAMP { get; set; }
    }
}
