using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LIB.Common
{
    public class Utility
    {
        /// <summary>
        /// 讀取為任意型別
        /// 例如 string value = ReadAs<string>(sheet.Cells[row, col].Value, string.Empty);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectValue">輸入值</param>
        /// <param name="defultValue">預設值</param>
        /// <returns></returns>
        public static T? ReadAs<T>(object objectValue, T defultValue)
        {
            // 如果要求日期轉換失敗回傳 null
            if (typeof(T) == typeof(DateTime?))
            {
                if (DateTime.TryParse(objectValue?.ToString(), out var dateTimeValue))
                    return (T?)(object)dateTimeValue;

                return default;
            }

            // 如果遇到 string 類型，回傳 trim 結果
            if (typeof(T) == typeof(string))
            {
                string? s = objectValue?.ToString()?.Trim();
                return (T?)Convert.ChangeType(s, typeof(T));
            }

            object? result = objectValue ?? defultValue;
            return (T?)Convert.ChangeType(result, typeof(T));
        }

        /// <summary>
        /// IList 轉 DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IList<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string[] ignoreCols = new string[] { "TOTAL", "SKIP", "TAKE", "GRD_FLG", "SORT_COL_NAME", "SORT_COL_DIR", "IsForExport" };
            string[] ignoreTypes = new string[] { "IList`1", "Array" };
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                if (!ignoreCols.Contains(prop.Name) && !ignoreTypes.Contains(type.Name))
                {
                    dataTable.Columns.Add(prop.Name, type);
                }
            }
            foreach (T item in items)
            {
                dataTable.Rows.Add(Props.Where(p =>
                {
                    var type = (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(p.PropertyType) : p.PropertyType);
                    return (!ignoreCols.Contains(p.Name) && !ignoreTypes.Contains(type.Name));
                }).Select(p => p.GetValue(item, null)).ToArray());
            }
            return dataTable;
        }

        /// <summary>
        /// 將字串內容 "{屬性}" 取代為物件屬性值
        /// </summary>
        /// <param name="content">內容字串</param>
        /// <param name="obj">物件</param>
        /// <returns>取代完成結果</returns>
        public static string DataReplace(string content, object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo p in props)
            {
                string? val = p.GetValue(obj)?.ToString();
                content = content.Replace($"{{{p.Name}}}", val);
            }
            return content;
        }
    }
}
