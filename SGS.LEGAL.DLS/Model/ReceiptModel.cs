namespace SGS.LEGAL.DLS.Model
{
    /// <summary>
    /// 收件回執結構
    /// </summary>
    /// <param name="CST_POST_CODE">客戶地址郵遞區號</param>
    /// <param name="CST_ADDR">客戶地址</param>
    /// <param name="CST_NM">客戶名稱</param>
    /// <param name="COM_POST_CODE">公司(我司)地址郵遞區號</param>
    /// <param name="COM_ADDR">公司(我司)地址</param>
    /// <param name="COM_NM">公司(我司)名稱</param>
    /// <param name="USER_NM">姓名</param>
    /// <param name="USER_TEL_EXT">分機</param>
    public record ReceiptModel(
        string CST_POST_CODE,
        string CST_ADDR,
        string CST_NM,
        string COM_POST_CODE,
        string COM_ADDR,
        string COM_NM,
        string USER_NM,
        string USER_TEL_EXT
        )
    {
        /// <summary>
        /// 郵遞區號前三碼
        /// </summary>
        public string? CST_POST_CODE_1 => CST_POST_CODE?[..3];
        /// <summary>
        /// 郵遞區號第四碼到最後
        /// </summary>
        public string? CST_POST_CODE_2 => CST_POST_CODE?[3..];

        /// <summary>
        /// 郵遞區號前三碼
        /// </summary>
        public string? COM_POST_CODE_1 => COM_POST_CODE?[..3];
        /// <summary>
        /// 郵遞區號第四碼到最後
        /// </summary>
        public string? COM_POST_CODE_2 => COM_POST_CODE?[3..];
    };
}
