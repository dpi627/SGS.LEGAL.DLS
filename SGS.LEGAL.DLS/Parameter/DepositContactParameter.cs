namespace SGS.LEGAL.DLS.Parameter
{
    public record DepositContactParameter
    {
        public string COM_CODE { get; set; } = "";
        public string COM_POST_CODE { get; set; } = "";
        public string COM_ADDR { get; set; } = ""; // 總公司地址，收件回執使用
        public string SND_NM { get; set; } = "";
        public string SND_POST_CODE { get; set; } = "";
        public string SND_ADDR { get; set; } = "";
        public string SND_CEO { get; set; } = "";
        public string RCV_NM { get; set; } = "";
        public string RCV_POST_CODE { get; set; } = "";
        public string RCV_ADDR { get; set; } = "";
        public string RCV_CEO { get; set; } = "";
        public string CC_NM { get; set; } = "";
        public string CC_POST_CODE { get; set; } = "";
        public string CC_ADDR { get; set; } = "";
        public string AMT_NM { get; set; } = "";
    }
}
