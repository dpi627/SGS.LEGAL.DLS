using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Service.ResultModel
{
    public record OptLogResultModel
    {
        public long LOG_ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime CRT_DATE { get; set; }
        public string? CRT_USER { get; set; }
        public string? ACT_NM { get; set; }
        public string? FUNC_NM { get; set; }
        public string? USER_NM { get; set; }
    }
}
