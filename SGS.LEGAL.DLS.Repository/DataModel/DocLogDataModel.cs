using SGS.LEGAL.DLS.Entity;

namespace SGS.LEGAL.DLS.Repository.DataModel
{
    public record DocLogDataModel : DOC_LOG
    {
        public string COMPANY { get; set; }
        public string COMPANY_NM { get; set; }
        public string BOSS_NO { get; set; }
        public string CST_NO { get; set; }
        public string CST_NM { get; set; }
        public string FIL_TYP_NM { get; set; }
        public string LET_TYP_NM { get; set; }
        public string USER_NM { get; set; }
        public string EMP_ID { get; set; }
    }
}
