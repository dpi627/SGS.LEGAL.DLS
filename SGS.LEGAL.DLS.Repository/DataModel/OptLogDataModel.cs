
namespace SGS.LEGAL.DLS.Repository.DataModel
{
    public record OptLogDataModel
    {
        public long LOG_ID { get; set; }
        public int ACT_ID { get; set; }
        public string? MSG { get; set; }
        public string? MEMO { get; set; }
        public DateTime CRT_DATE { get; set; }
        public string? CRT_USER { get; set; }
        public string? ACT_NM { get; set; }
        public string? FUNC_NM { get; set; }
        public string? USER_NM { get; set; }
    }
}
