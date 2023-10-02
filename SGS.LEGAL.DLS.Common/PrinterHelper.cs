using System.Data;
using System.Drawing.Printing;

namespace SGS.LIB.Common
{
    public class PrinterHelper
    {
        /// <summary>
        /// 取得本機的印表機清單，排除 Fax 與 無紙匣 項目
        /// </summary>
        /// <returns>印表機名稱(字串)陣列</returns>
        public static string[] GetLocalPrinters() {
            return PrinterSettings
            .InstalledPrinters
            .Cast<string>()
            .Where(
                x => GetPaperSources(x).Count > 0 &&
                !x.Contains("Fax", StringComparison.OrdinalIgnoreCase)
            )
            .ToArray();
        }

        /// <summary>
        /// 取得印表機的紙匣結構清單，排除 RawKind >= 1000 的項目
        /// </summary>
        /// <param name="printerName">印表機名稱</param>
        /// <param name="excludeRawKind">某種印表機參數</param>
        /// <returns>紙匣陣列</returns>
        public static List<PaperSource> GetPaperSources(string printerName, int excludeRawKind = 1000)
        {
            // 建立印表機設定 (指定印表機名稱)
            PrinterSettings printerSettings = new() { PrinterName = printerName };
            // 取得印表機紙匣 (觀看資料好像只有 RawKind < 1000 的才是紙匣)
            return printerSettings.PaperSources.Cast<PaperSource>()
                .Where(x => x.RawKind < excludeRawKind)
                .ToList();
        }
    }
}
