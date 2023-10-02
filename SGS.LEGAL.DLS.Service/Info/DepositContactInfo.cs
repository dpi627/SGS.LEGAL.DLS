namespace SGS.LEGAL.DLS.Service.Info
{
    /// <summary>
    /// 存證信函聯絡人相關資訊
    /// 含SND寄件件人、RCV收件人與CC副本
    /// </summary>
    public record DepositContactInfo
    {
        public string COM_ADDR { get; set; } = ""; // 總公司地址，收件回執使用
        public string SND_NM { get; set; } = "";
        public string SND_ADDR { get; set; } = "";
        public string SND_CEO { get; set; } = "";
        public string RCV_NM { get; set; } = "";
        public string RCV_ADDR { get; set; } = "";
        public string RCV_CEO { get; set; } = "";
        public string CC_NM { get; set; } = "";
        public string CC_ADDR { get; set; } = "";
    }
}
