using SGS.LEGAL.DLS.Entity;
using System.Collections;
using System.Reflection;
using Aspose.Words;
using Document = Aspose.Words.Document;
using Table = Aspose.Words.Tables.Table;
using Row = Aspose.Words.Tables.Row;
using Cell = Aspose.Words.Tables.Cell;
using System.Data;
using SGS.LIB.Common;

namespace SGS.LEGAL.DLS.Service
{
    public class DunningLetterService : BaseService
    {
        protected Document doc;
        private Table table;
        private Row row;
        private Cell cell;
        // 欲複製的範本資料列索引，通常=1(第二列)
        private int cloneRowIndex = 1;
        // 欲插入範本的資料列索引，通常=2(第三列)
        private int InsertRowIndex = 2;
        // 設定資料寫入(取代)目標，正份文件或單一儲存格
        private WriteTarget target = WriteTarget.Doc;
        // DataTable 降冪排序欄位 (資料集合為 DataTable 時使用)
        private string sortColumn;

        public DunningLetterService(SYS_USER? user) : base(user)
        {
        }

        /// <summary>
        /// 設定來源檔案(通常指範本檔)
        /// </summary>
        /// <param name="FileName">檔案完整路徑</param>
        /// <returns></returns>
        public DunningLetterService SetTemplate(string FileName)
        {
            doc = new Document(FileName);
            return this;
        }

        /// <summary>
        /// 寫入表格之資料列起始編號
        /// </summary>
        public int rowNo { get; set; } = 1;

        /// <summary>
        /// 選擇範本要操作的表格
        /// </summary>
        /// <param name="TableIndex">表格索引</param>
        /// <param name="CloneRowIndex">要複製的資料列索引</param>
        /// <param name="InserRowIndex">插入資料列位置，通常為複製列下一列</param>
        public DunningLetterService SelectTable(int TableIndex, int CloneRowIndex = 1, int? InserRowIndex = null)
        {
            table = (Table)doc.GetChild(NodeType.Table, TableIndex, true);
            SetCloneRowIndex(CloneRowIndex);
            SetInsertRowIndex(InserRowIndex);
            return this;
        }

        private void SetCloneRowIndex(int index)
        {
            cloneRowIndex = index;
        }
        private void SetInsertRowIndex(int? index)
        {
            // 如果未指定插入位置，則預設為複製列下一列
            InsertRowIndex = index ?? cloneRowIndex + 1;
        }

        /// <summary>
        /// 表格建立(複製)新資料列
        /// </summary>
        private DunningLetterService CreateNewRow()
        {
            row = (Row)table.Rows[cloneRowIndex].Clone(true);
            return this;
        }

        /// <summary>
        /// 寫入集合資料，通常為 DataTable 或 List<T>
        /// </summary>
        /// <param name="loopData">資料集合，通常為 DataTable 或 List<T></param>
        /// <param name="tableIndex">Word 要操作表格的索引，人工判斷</param>
        /// <param name="sortColumn">資料集合如為 DataTable，需指定排序欄位</param>
        /// <param name="cloneRowIndex">Word 要操作表格之範本列索引，通常為 1 (第二列)</param>
        /// <param name="insertRowIndex">Word 要操作表格之插入列索引，預設範本列+1</param>
        /// <param name="removeRowIndex">資料填寫完畢要移除之範本列索引，通常為 1 (第二列)</param>
        public DunningLetterService WriteDataLoop(object loopData, int tableIndex, string sortColumn = "", int cloneRowIndex = 1, int? insertRowIndex = null, int removeRowIndex = 1)
        {
            SelectTable(tableIndex, cloneRowIndex, insertRowIndex);
            SetSortColumn(sortColumn);
            WriteData(loopData);
            RemoveRow(removeRowIndex);
            return this;
        }

        /// <summary>
        /// 寫入一到多個資料或資料集合，以逗點分隔傳入
        /// 例如 object, List<T>, DataTable 等
        /// </summary>
        /// <param name="datas">各種資料，以逗點分隔</param>
        public DunningLetterService WriteDataOneTime(params object[] datas)
        {
            foreach (var data in datas)
            {
                WriteData(data);
            }
            return this;
        }

        /// <summary>
        /// 判斷資料類型，決定寫入方式
        /// </summary>
        private DunningLetterService WriteData(object data)
        {
            Type type = data.GetType();
            //Console.WriteLine(data);

            if (type == typeof(DataTable))
            {
                Console.WriteLine("T is a DataTable.");
                WriteLoop(data as DataTable);
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                Console.WriteLine("T is a List.");
                WriteLoop(data);
            }
            else
            {
                Console.WriteLine("T is not a List.");
                WriteOnce(data);
            }

            return this;
        }

        /// <summary>
        /// 寫入一次性資料
        /// </summary>
        private DunningLetterService WriteOnce<T>(T data)
        {
            Write(data);
            return this;
        }

        /// <summary>
        /// 寫入 List<T> 資料集合(迴圈)
        /// </summary>
        private DunningLetterService WriteLoop<T>(T loopData)
        {
            // 設定寫入目標為儲存格
            target = WriteTarget.Cell;

            // 使用匹配表達式，判斷是否為 IEnumerable 類型
            if (loopData is not IEnumerable datas)
                return this;

            // 資料反轉
            List<object> reverse = datas.Cast<object>().ToList();
            reverse.Reverse();
            // 因為反轉了，編號也要倒過來
            rowNo = reverse.Count;
            foreach (var data in datas)
            {
                CreateNewRow();

                foreach (Cell c in row.Cast<Cell>())
                {
                    // 設定儲存格
                    cell = c;
                    // 寫入資料列編號 (如不須編號可註解
                    ReplaceData("{#}", rowNo.ToString("D2"));
                    // 寫入資料
                    Write(data);
                }

                table.Rows.Insert(InsertRowIndex, row);
                rowNo--;
            }
            return this;
        }
        /// <summary>
        /// 寫入 DataTable 資料集合(迴圈)
        /// </summary>
        private DunningLetterService WriteLoop(DataTable dataTable)
        {
            // 設定寫入目標為儲存格
            target = WriteTarget.Cell;

            DataView dataView = dataTable.DefaultView;
            dataView.Sort = $"{this.sortColumn} DESC"; // 將排序方式設定為遞減排序
            dataTable = dataView.ToTable();

            rowNo = dataTable.Rows.Count;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                CreateNewRow();

                foreach (Cell c in row.Cast<Cell>())
                {
                    // 設定儲存格
                    cell = c;
                    // 寫入資料列編號 (如不須編號可註解
                    ReplaceData("{#}", rowNo.ToString("D2"));
                    // 寫入資料
                    Write(dataTable.Columns, dataRow);
                }

                table.Rows.Insert(InsertRowIndex, row);
                rowNo--;
            }
            return this;
        }

        /// <summary>
        /// 因資料會降冪排序寫入，當資料集合為 DataTable 時，需設定排序欄位
        /// </summary>
        /// <param name="ColumnName">排序欄位名稱</param>
        public DunningLetterService SetSortColumn(string ColumnName)
        {
            this.sortColumn = ColumnName;
            return this;
        }

        /// <summary>
        /// 資料寫入(取代)目標
        /// </summary>
        private enum WriteTarget
        {
            /// <summary>
            /// 整份文件
            /// </summary>
            Doc,
            /// <summary>
            /// 單一儲存格
            /// </summary>
            Cell
        }

        /// <summary>
        /// 依序讀取物件屬性，將 {屬性名稱} 取代為 屬性值
        /// </summary>
        private void Write<T>(T obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                string pattern = $"{{{prop.Name}}}";
                ReplaceData(pattern, prop.GetValue(obj));
            }
        }
        /// <summary>
        /// 依序讀取資料欄名稱，將 {資料欄名稱} 取代為 資料欄值
        /// </summary>
        private void Write(DataColumnCollection cols, DataRow row)
        {
            foreach (DataColumn col in cols)
            {
                string pattern = $"{{{col.ColumnName}}}";
                ReplaceData(pattern, row[col]);
            }
        }

        /// <summary>
        /// 寫入(取代)目標資料
        /// </summary>
        /// <param name="pattern">搜尋樣本</param>
        /// <param name="value">取代值</param>
        private void ReplaceData<T>(string pattern, T value)
        {
            /// 目標是儲存格，則取代第一段落內容(符合pattern者)
            /// 目標是文件，則搜尋整份文件內容(符合pattern者)

            if (target == WriteTarget.Cell)
                cell.FirstParagraph
                    .Range
                    .Replace(pattern, Convert.ToString(value));
            else
                doc.Range
                   .Replace(pattern, Convert.ToString(value));
        }

        /// <summary>
        /// 移除範本資料列，通常是第二列 (index=1)
        /// </summary>
        public DunningLetterService RemoveRow(int index = 1)
        {
            table.Rows.Remove(table.Rows[index]);
            return this;
        }

        /// <summary>
        /// 制定特定儲存格，設定內容等於欄寬
        /// </summary>
        /// <param name="FitColumnsIndex">需要設定的欄索引陣列</param>
        /// <param name="StartRowIndex">起始列(含)索引</param>
        /// <param name="IgnoreLastRowCount">忽略倒數N列不處理</param>
        /// <returns></returns>
        public DunningLetterService FitText(List<int> FitColumnsIndex, int StartRowIndex = 1, int IgnoreLastRowCount = 0)
        {
            int EndRowIndex = table.Rows.Count - 1 - IgnoreLastRowCount;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (i >= StartRowIndex && i <= EndRowIndex)
                {
                    row = table.Rows[i];
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        if (FitColumnsIndex.Contains(j))
                        {
                            row.Cells[j].CellFormat.FitText = true;
                        }
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// 儲存文件，默認存為 pdf
        /// </summary>
        /// <param name="FileName">儲存檔案(完整路徑)</param>
        /// <param name="Format">指定副檔名</param>
        private void SaveFile(string FileName, SaveFormat Format)
        {
            /// 如檔名已經包含副檔名，即便指定格式，副檔名也不會變更
            /// 會出現例如 SaveFormat 指定 pdf，但仍儲存為 xxx.docx
            string ext = Path.GetExtension(FileName); // 取得副檔名，例如 .docx
            string format = $".{Format.ToString().ToLower()}"; // 取得指定格式的副檔名，例如 .pdf
            if (ext != format) // 如指定格式與檔名副檔名不同，則取代副檔名。如原本無副檔名則加上
                FileName = "".Equals(ext) ?
                    $"{FileName}{format}" :
                    FileName.Replace(ext, format);
            doc.Save(FileName);
        }

        /// <summary>
        /// 儲存文件，默認存為 pdf
        /// </summary>
        /// <param name="FileName">儲存檔案(完整路徑)</param>
        /// <param name="Format">指定副檔名</param>
        public DunningLetterService Save(string FileName, SaveFormat Format = SaveFormat.Pdf)
        {
            SaveFile(FileName, Format);
            return this;
        }

        /// <summary>
        /// 切換AD帳號儲存文件，通常是因為權限不同
        /// </summary>
        /// <param name="Impersonator">特定AD帳號</param>
        /// <param name="password">特定AD帳號密碼</param>
        /// <param name="FileName">儲存檔案(完整路徑)</param>
        /// <param name="Format">指定副檔名</param>
        public DunningLetterService Save(string Impersonator, string password, string FileName, SaveFormat Format = SaveFormat.Pdf)
        {
            using Impersonator? imp = new(Impersonator, password);
            imp.Run(() => { SaveFile(FileName, Format); });
            return this;
        }

        public void Release()
        {
            base.Dispose();
        }
    }
}
