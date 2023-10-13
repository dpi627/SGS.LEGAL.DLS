using Dapper;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using SGS.LIB.Common;
using SGS.LEGAL.DLS.Entity;

namespace SGS.LEGAL.DLS.Repository
{
    public class BaseRepo : IDisposable
    {
        private bool disposed = false;
        protected string? strConn;
        protected string? strSql;
        protected object? objParam;
        /// <summary>
        /// SQL參數陣列
        /// </summary>
        protected ArrayList? arrParam;
        protected string? strParam;
        //private ConfigReader? config = new();
        protected SYS_USER? logiinUser;

        public BaseRepo(SYS_USER? user)
        {
            //strConn = new ConfigReader().GetConnStr("UAT");
            logiinUser = user ?? new SYS_USER();
            SetConnectionString();
        }

        /// <summary>
        /// 設定資料庫連線字串
        /// </summary>
        private void SetConnectionString()
        {
            // TODO: 要改抓資料庫
            if (!string.IsNullOrEmpty(strConn)) return;
            using ConfigReader? cr = new();
            strConn = cr.GetConnStr("UAT");
        }

        /// <summary>
        /// SQL參數組成字串
        /// </summary>
        public string ParamStr
        {
            get
            {
                //參數之間用 and 分隔，組成一個字串，空陣列得到空字串
                strParam = string.Join(" and ", arrParam.ToArray().Where(p => !string.IsNullOrWhiteSpace(p.ToString())));
                //回傳字串結果
                return string.IsNullOrEmpty(strParam) ? "" : string.Format(" and {0} ", strParam);
            }
            set { }
        }

        #region 實作 Dapper
        protected IList<IDictionary<string, object>> ExecuteQuery(string sql, object? param = null)
        {
            using (var conn = new SqlConnection(strConn))
            {
                return ToIList(conn.Query(sql, param, commandTimeout: 600) as IEnumerable<IDictionary<string, object>>);
            }
        }

        protected IList<T> ExecuteQuery<T>(string sql, object? param = null)
        {
            using SqlConnection? conn = new(strConn);
                return conn.Query<T>(sql, param, commandTimeout: 600).ToList<T>();
                //return ToIList(conn.Query<T>(sql, param, commandTimeout: 600));
        }

        protected bool ExecuteCommand(string sql, object? param = null)
        {
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Execute(sql, param, commandTimeout: 600) > 0;
            }
        }

        /// <summary>
        /// 執行 SQL 後，取得目前 identity 值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected int ExecuteGetID(string sql, object? param = null)
        {
            sql = $"{sql}; SELECT SCOPE_IDENTITY();"; // 取得 identity 值
            using SqlConnection? conn = new(strConn);
            object? id = conn.ExecuteScalar(sql, param, commandTimeout: 600);
            return Convert.ToInt32(id);
        }
        #endregion

        #region 資料轉換
        /// <summary>
        /// IEnumerable 轉 IList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        private IList<T> ToIList<T>(IEnumerable<T> result)
        {
            if (result.Count() > 0)
            {
                if (typeof(T) == typeof(string))
                {
                    //return result.Select(p => (T)Convert.ChangeType(HttpUtility.HtmlEncode(p.ToString().Trim()), typeof(T))).ToList();
                    return result.Select(p => (T)Convert.ChangeType(p?.ToString()?.Trim(), typeof(T))).ToList();
                }
                else if (typeof(T) == typeof(IDictionary<string, object>))
                {
                    return result.Select(p =>
                    {
                        foreach (KeyValuePair<string, object> keyValue in p as IDictionary<string, object>)
                        {
                            if (keyValue.Key.ToUpper() != keyValue.Key)
                            {
                                //(p as IDictionary<string, object>).Add(keyValue.Key.ToUpper(), (keyValue.Value != null && keyValue.Value is string) ? HttpUtility.HtmlEncode(keyValue.Value.ToString().Trim()) : keyValue.Value);
                                (p as IDictionary<string, object>).Add(keyValue.Key.ToUpper(), (keyValue.Value != null && keyValue.Value is string) ? keyValue.Value.ToString().Trim() : keyValue.Value);
                                (p as IDictionary<string, object>).Remove(keyValue.Key);
                            }
                            else
                            {
                                if (keyValue.Value != null && keyValue.Value is string)
                                {
                                    //(p as IDictionary<string, object>)[keyValue.Key] = HttpUtility.HtmlEncode(keyValue.Value.ToString().Trim());
                                    (p as IDictionary<string, object>)[keyValue.Key] = keyValue.Value.ToString().Trim();
                                }
                                else if (keyValue.Value == null && keyValue.Value is string)
                                {
                                    (p as IDictionary<string, object>)[keyValue.Key] = string.Empty;
                                }
                            }
                        }
                        return (T)p;
                    }).ToList();
                }
                else
                {
                    return result.Select(p =>
                    {
                        if (p != null)
                        {
                            //string[] lstIgnore = new string[] { @"SDO.MODELS.LM05.QUO_M+EDITVIEW", @"SDO.MODELS.LM05.QUO_S+EDITVIEW", @"SDO.MODELS.LM05.QUO_SL+EDITVIEW", @"SDO.MODELS.LM05.QUO_SLA+EDITVIEW", @"SDO.MODELS.LM05.QUO_S_INFO+EDITVIEW", @"SDO.MODELS.LM05.QUO_MO+EDITVIEW", @"SDO.MODELS.LM05.QUO_PAY_REC+EDITVIEW" };
                            foreach (var prop in p.GetType().GetProperties())
                            {
                                if (prop.PropertyType == typeof(string) && prop.GetValue(p) != null)
                                {
                                    //prop.SetValue(p, HttpUtility.HtmlEncode(prop.GetValue(p).ToString().Trim()));
                                    if (prop.GetSetMethod() != null) // 有 setter 才能設值
                                        prop.SetValue(p, prop.GetValue(p).ToString().Trim());
                                }
                                else if (prop.PropertyType == typeof(string) && prop.GetValue(p) == null)
                                {
                                    if (prop.GetSetMethod() != null) // 有 setter 才能設值
                                        prop.SetValue(p, string.Empty);
                                    //if (!lstIgnore.Contains(typeof(T).FullName.ToUpper()))
                                    //{
                                    //    prop.SetValue(p, string.Empty);
                                    //}
                                }
                            }
                        }
                        return p;
                    }).ToList();
                }
            }
            return result.ToList();
        }

        /// <summary>
        /// IList 轉 DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        protected static DataTable ToDataTable<T>(IList<T> items)
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
        #endregion

        #region dispose synax
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseRepo()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //SetProfilerLog();
                }
                disposed = true;
            }
        }
        #endregion
    }
}
