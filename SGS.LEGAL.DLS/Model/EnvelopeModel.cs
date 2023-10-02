namespace SGS.LEGAL.DLS.Model
{
    /// <summary>
    /// 收件回執結構
    /// </summary>
    /// <param name="CST_ADDR">客戶地址</param>
    /// <param name="CST_NM">客戶名稱</param>
    /// <param name="USER_NM">姓名</param>
    /// <param name="USER_TEL">分機</param>
    /// <param name="USER_TEL_EXT">分機</param>
    public record EnvelopeModel(
        string CST_ADDR,
        string CST_NM,
        string USER_NM,
        string USER_TEL,
        string USER_TEL_EXT
        );
}
