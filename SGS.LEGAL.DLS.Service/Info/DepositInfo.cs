using SGS.LIB.Common;

namespace SGS.LEGAL.DLS.Service.Info
{
    public record DepositInfo
    {
        public string AMT_NM { get; set; } = "";
        public decimal AMT { get; set; } = 0;
        public List<string> LST_INV_NO { get; set; } = new();
        public string TEL { get; set; } = "";
        public string EXT { get; set; } = "";
        public string USR_NM { get; set; } = "";

        public string AMT_DSP { get => AmtHelper.ConvertToChineseAmount(AMT); set { } }
        public string INV_NO_DSP { get => string.Join('、', LST_INV_NO); set { } }
    }
}
