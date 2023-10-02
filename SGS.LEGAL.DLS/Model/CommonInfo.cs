namespace SGS.LEGAL.DLS.Model
{
    /// <summary>
    /// 通知函
    /// </summary>
    /// <param name="INV_DUE_DT">發票截止日期</param>
    /// <param name="TLT">金額總和</param>
    /// <param name="CRT_DT">通知函產生日期</param>
    public record CommonInfo(DateTime INV_DUE_DT, decimal TLT)
    {
        /// <summary>
        /// 發票截止日期
        /// </summary>
        public string INV_DUE_DT_DISP => INV_DUE_DT.ToString("yyyy/MM/dd");

        /// <summary>
        /// 通知函產生日期
        /// </summary>
        public DateTime CRT_DT { get; set; } = DateTime.Now;
        /// <summary>
        /// 通知函產生日期 - 民國年
        /// </summary>
        public string YY => Convert.ToString(CRT_DT.Year - 1911);
        public string MM => Convert.ToString(CRT_DT.Month);
        public string DD => Convert.ToString(CRT_DT.Day);
        public int PRECISION { get; set; } = 0;
        public string TLT_DISP => TLT.ToString($"N{PRECISION}");
    }
}
