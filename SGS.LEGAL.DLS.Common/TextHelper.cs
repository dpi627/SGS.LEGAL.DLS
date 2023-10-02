using System.Text;

namespace SGS.LIB.Common
{
    /// <summary>
    /// 文字處理
    /// </summary>
    public class TextHelper
    {
        /// <summary>
        /// 將輸入字串轉換為全形
        /// 處理英文、數字與特殊符號(含標點符號)等
        /// 空白另外處理
        /// </summary>
        /// <param name="input">輸入字串</param>
        /// <returns>全形字串</returns>
        public static string ConvertToFullWidth(string input)
        {
            StringBuilder result = new();
            foreach (char c in input)
            {
                if (c > ' ' && c <= '~')
                    result.Append((char)(c + 65248));  // 將字元轉換為全形
                else if (c == ' ')
                    result.Append('\u3000');  // 將半形空白轉換為全形空白
                else
                    result.Append(c);  // 非半形字元保持不變
            }
            return result.ToString();
        }

        /// <summary>
        /// 字串切割為指定長度陣列，未滿長度補上指定字元
        /// </summary>
        /// <param name="source">來源字串</param>
        /// <param name="N">指定長度</param>
        /// <param name="fillChar">填充字元</param>
        /// <returns></returns>
        public static List<string> SplitAndFill(string source, int N, char fillChar = '\u3000')
        {
            List<string> result = new();

            // 如來源資料為空字串，補滿填充字元
            if (source.Length == 0)
            {
                result.Add(new string(fillChar, N));
                return result;
            }

            int sourceLength = source.Length;
            int currentIndex = 0;

            while (currentIndex < sourceLength)
            {
                int remaining = sourceLength - currentIndex;
                string chunk;

                if (remaining >= N)
                {
                    chunk = source.Substring(currentIndex, N);
                }
                else
                {
                    chunk = source.Substring(currentIndex) + new string(fillChar, N - remaining);
                }

                result.Add(chunk);
                currentIndex += N;
            }

            return result;
        }
    }
}
