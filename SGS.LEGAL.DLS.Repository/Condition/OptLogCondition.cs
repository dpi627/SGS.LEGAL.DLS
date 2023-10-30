using SGS.LEGAL.DLS.Entity;

namespace SGS.LEGAL.DLS.Repository.Condition
{
    public record OptLogCondition : OPT_LOG
    {
        public DateTime? DATE_START { get; set; }
        public DateTime? DATE_END { get; set; }
    }
}
