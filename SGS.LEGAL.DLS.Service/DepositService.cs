using Aspose.Words;
using Aspose.Words.Tables;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service.Info;
using t = SGS.LIB.Common.TextHelper;
using u = SGS.LIB.Common.Utility;

namespace SGS.LEGAL.DLS.Service
{
    /// <summary>
    /// 存證信函處理服務
    /// 繼承催款函服務，部分函式需 new，避免 return 型別不同
    /// </summary>
    public class DepositService : DunningLetterService
    {
        #region field
        /// <summary>
        /// 預設內容
        /// </summary>
        private string _content = "";
        /// <summary>
        /// 每頁最多幾行
        /// </summary>
        private int _maxPageLineNum = 10;
        /// <summary>
        /// 每行最多幾個字(元)
        /// </summary>
        private int _maxLineCharNum = 20;
        /// <summary>
        /// 未滿一行填補字元，預設全形空白
        /// </summary>
        private char _paddingChar = '\u3000';
        /// <summary>
        /// 預處理資料集合
        /// 資料取代、金額中文、全形轉換，依照長度切分、填充字元填補
        /// </summary>
        private List<string> _prefixData = new();
        /// <summary>
        /// 頁數
        /// </summary>
        private int _pageCount = 0;
        /// <summary>
        /// 處理好的頁數陣列，每頁包含寫入字串列
        /// </summary>
        private List<List<string>> _pages = new();
        #endregion

        public DepositService(DepositConfig? config = default, SYS_USER? user = default) : base(user)
        {
            config = (config != default) ? config : new DepositConfig();
            SetConfig(config);
        }

        private void SetConfig(DepositConfig config)
        {
            _maxPageLineNum = config.MaxPageLines;
            _maxLineCharNum = config.MaxLineCharacters;
            _paddingChar = config.PaddingCharacter;
        }

        /// <summary>
        /// 資料預處裡：
        /// 每行進行全形轉換(ConvertToFullWidth)
        /// 依照每行最大字數(_maxLineCharNum)分割，未滿字數填滿填補字元(_paddingChar)
        /// SelectMany 整合為一個陣列
        /// </summary>
        private void DataPrefix()
        {
            //RawLines = _content.Split(Environment.NewLine);
            _prefixData = _content.Split(Environment.NewLine) //RawLines
                .Select(x => t.ConvertToFullWidth(x))
                .Select(x => t.SplitAndFill(x, _maxLineCharNum, _paddingChar))
                .SelectMany(x => x)
                .ToList();
            //lstPrefix.ForEach(x=>Debug.WriteLine(x)); //印出來看
        }

        /// <summary>
        /// 設定資料、資料處理、產生分頁、資料填充
        /// </summary>
        /// <param name="info">取代內容用的資料結構</param>
        /// <param name="contact">聯絡人資料，取代每個頁首頁尾</param>
        /// <param name="content">內容文字範本</param>
        /// <returns></returns>
        public DepositService SetData(DepositInfo info, DepositContactInfo contact, string? content = default)
        {
            // 設定內容，並將 {屬性} 取代為屬性值
            SetContent(info, content);
            // 資料前處理，包含全形轉換、分割、填補
            DataPrefix();
            // 分頁處理，將預處理資料依照每頁資料行上限拆分
            DataPaging();
            // 計算需要幾頁容納資料，並新增之
            AddExtraBlankPage();
            // 頁數確認後，進行一次性資料處理，包含頁首、頁尾
            base.WriteDataOneTime(contact);
            // 資料填充
            FillData();

            return this;
        }

        /// <summary>
        /// 設定內容，進行屬性值取代
        /// </summary>
        /// <param name="info">資料結構</param>
        /// <param name="content">內容樣板，如無給預設</param>
        private void SetContent(DepositInfo info, string? content = default)
        {
            if (content == default)
            {
                /// 如果content 為 null，則取得系統參數 DPS_NOTICE
                /// 注意換行字元取代要使用 @
                using SysParamService svc = new(null);
                content = svc
                    .Get("DPS_NOTICE")?
                    .Where(x => x.P_VAL == "A")?
                    .FirstOrDefault()?
                    .EXT_1?
                    .Replace(@"\r\n", Environment.NewLine);
            }

            this._content = u.DataReplace(content!, info);
        }

        /// <summary>
        /// 依照每頁上限行數進行分頁
        /// </summary>
        private void DataPaging()
        {
            int count = 0;
            List<string> lines = new List<string>();
            // 讀取預處理資料集合，逐行加入
            foreach (string line in _prefixData)
            {
                lines.Add(line);
                count++;
                // 每達到每頁最大行數，就加入頁數陣列並重置
                if (count >= _maxPageLineNum)
                {
                    _pages.Add(lines);
                    lines = new List<string>();
                    count = 0;
                }
            }
            /// 將剩餘資料加入
            /// 或資料行一開始就未滿單頁最大行數
            if (lines.Count > 0)
                _pages.Add(lines);
        }

        /// <summary>
        /// 將資料填入每一頁(section)表格(table)的儲存格(cell)之中
        /// </summary>
        private DepositService FillData()
        {
            for (int idxP = 0; idxP < _pages.Count; idxP++)
            {
                // 取得第 idxP 頁，section 好像就是頁
                Section? sec = doc.Sections[idxP];
                // 取得該頁的 table，預設取第一個
                Table? table = GetTable(sec);
                // 取得該頁的資料行
                List<string>? lines = _pages[idxP];
                for (int idxL = 0; idxL < lines.Count; idxL++)
                {
                    Row? row = table.Rows[idxL + 1];
                    string? line = lines[idxL];

                    for (int idxC = 0; idxC < line.Length; idxC++)
                    {
                        var cell = row.Cells[idxC + 1];
                        SetCellValue(doc, cell, line[idxC]);
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// 儲存格填入資料
        /// </summary>
        /// <param name="doc">Word 文件</param>
        /// <param name="cell">儲存格</param>
        /// <param name="val">填入資料</param>
        /// <param name="isClearCell">是否清除儲存格</param>
        private void SetCellValue<T>(Document doc, Cell cell, T? val = default, bool isClearCell = false)
        {
            Paragraph p;
            if (isClearCell) // 清空儲存格內容
            {
                cell.RemoveAllChildren();
                p = new Paragraph(doc);
            }
            else
                p = cell.FirstParagraph;

            #region 填入資料定義樣式，取代則不用
            /// 參考網址似乎有類似問題已解，目前使用版本 22.12.0 仍無解，不排除版本差異問題所致
            /// https://forum.aspose.com/t/replace-text-in-table-cell-but-keep-existing-text-format/47251/12
            /// 通知函、催款函等使用取代(Replace)無此問題
            /// 存證信函採用填入方式無法繼承樣式，所以自行宣告字型
            #endregion
            Run run = new(doc);
            run.Font.Name = "標楷體";
            run.Font.Size = 12;
            run.Text = Convert.ToString(val);
            p.AppendChild(run);
        }

        private Table GetTable(Section section, int tableIndex = 0)
        {
            return section.Body.Tables[tableIndex];
        }

        /// <summary>
        /// 計算頁數，新增額外範本分頁 (複製範本第一頁)
        /// </summary>
        private void AddExtraBlankPage()
        {
            // 計算並設定頁數，無條件進位計算&設定頁數
            double result = (double)_prefixData.Count / _maxPageLineNum;
            this._pageCount = (int)Math.Ceiling(result);

            // 如果頁數超過一頁，需新增頁面
            if (_pageCount > 1)
            {
                // 複製第一頁內容
                Document firstPageCopy = (Document)doc.Clone(true);
                // 加入頁面，原本已經有一頁要扣掉
                for (int i = 0; i < _pageCount - 1; i++)
                    doc.AppendDocument(firstPageCopy, ImportFormatMode.KeepSourceFormatting);
            }
        }

        public new DepositService Save(string FileName, SaveFormat Format = SaveFormat.Pdf)
        {
            base.Save(FileName, Format);
            return this;
        }

        /// <summary>
        /// 設定範本，繼承了底層，必須再包一次，不然 return 類別不同無法 chainning
        /// </summary>
        /// <param name="path">範本路徑</param>
        public new DepositService SetTemplate(string path)
        {
            base.SetTemplate(path);
            return this;
        }
    }

    /// <summary>
    /// 設定參數結構
    /// </summary>
    /// <param name="MaxPageLines">每頁行數上限</param>
    /// <param name="MaxLineCharacters">每行字元上限</param>
    /// <param name="PaddingCharacter">填充字元</param>
    public record DepositConfig(int MaxPageLines = 10, int MaxLineCharacters = 20, char PaddingCharacter = '\u3000');
}
