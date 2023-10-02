namespace SGS.LIB.Common
{
    /// <summary>
    /// Amount Helper
    /// </summary>
    public class AmtHelper
    {
        private static readonly string[] ChineseNumberDigits = { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
        private static readonly string[] ChineseNumberUnits = { "", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "億", "拾", "佰", "仟" };

        /// <summary>
        /// 中文金額轉換
        /// </summary>
        /// <param name="amount">數字金額</param>
        public static string ConvertToChineseAmount(decimal amount)
        {
            string amountStr = amount.ToString("0"); // 轉換為整數字串
            int length = amountStr.Length;
            int unitIndex = 0;
            bool lastDigitIsZero = false;
            string result = "";

            for (int i = 0; i < length; i++)
            {
                int digit = int.Parse(amountStr[i].ToString());

                if (digit == 0)
                {
                    lastDigitIsZero = true;
                }
                else
                {
                    if (lastDigitIsZero)
                    {
                        result += ChineseNumberDigits[0]; // 補零
                        lastDigitIsZero = false;
                    }

                    result += ChineseNumberDigits[digit] + ChineseNumberUnits[length - i - 1];
                }

                if (unitIndex < ChineseNumberUnits.Length - 1)
                {
                    unitIndex++;
                }
            }

            return result;
        }
    }
}
