using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LEGAL.DLS
{
    public enum ModelMode
    {
        View = 0,
        Add = 1,
        Edit = 2,
        Delte = 3
    }
    public enum ModelStatus
    {
        None = 0
    }

    public enum OptLogType
    {
        Login,
        Search,
        Create,
        Print,
        Download,
        Import,
        Export
    }

    /// <summary>
    ///  每日轉檔狀態
    /// </summary>
    public static class DataImportStatus
    {
        /// <summary>
        /// 新建
        /// </summary>
        public const string New = "N";
        /// <summary>
        /// 完成
        /// </summary>
        public const string Finished = "F";
        /// <summary>
        /// 異常
        /// </summary>
        public const string Error = "E";
    }

    public static class BossDailyStatus
    {
        /// <summary>
        /// 新建
        /// </summary>
        public const string New = "N";
        /// <summary>
        /// 轉換
        /// </summary>
        public const string Transfer = "T";
        /// <summary>
        /// 失效
        /// </summary>
        public const string Expired = "E";
    }
}
