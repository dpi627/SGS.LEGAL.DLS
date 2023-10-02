namespace SGS.LEGAL.DLS.Model
{
    /// <summary>
    /// 收件回執結構
    /// </summary>
    /// <param name="CST_ADDR">客戶地址</param>
    /// <param name="CST_NM">客戶名稱</param>
    /// <param name="COM_ADDR">公司(我司)地址</param>
    /// <param name="COM_NM">公司(我司)名稱</param>
    /// <param name="USER_NM">姓名</param>
    /// <param name="USER_TEL_EXT">分機</param>
    public record ReceiptModel(
        string CST_ADDR,
        string CST_NM, 
        string COM_ADDR, 
        string COM_NM, 
        string USER_NM, 
        string USER_TEL_EXT
        );
}
