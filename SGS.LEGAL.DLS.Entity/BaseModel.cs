using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Entity
{
    public record BaseModel
    {
        //public ModelMode MODE { get; set; } = ModelMode.View;

        ///// <summary>
        ///// 資料狀態 (避免使用 DATA_STATE 保留字)
        ///// </summary>
        //public ModelStatus DATA_STA { get; set; } = ModelStatus.None;

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime CRT_DATE { get; set; } = DateTime.Now;
        /// <summary>
        /// 建立者
        /// </summary>
        public string CRT_USER { get; set; } = "SYSOP";
        /// <summary>
        /// 更新日期
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime? MDF_DATE { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        public string? MDF_USER { get; set; }

        //#region 分頁相關
        ///// <summary>
        ///// 查詢資料總數
        ///// </summary>
        //public int TOTAL { get; set; }
        ///// <summary>
        ///// 查詢資料分頁跳過筆數
        ///// </summary>
        //public int SKIP { get; set; }
        ///// <summary>
        ///// 查詢資料分頁取得筆數
        ///// </summary>
        //public int TAKE
        //{
        //    get
        //    {
        //        return _take > -1 ? _take : 20;
        //    }
        //    set
        //    {
        //        _take = value;
        //    }
        //}
        //private int _take = -1;     //初始化一定要設為-1

        ///// <summary>
        ///// 是否分頁，預設是。
        ///// 如匯出報表共用搜尋函式，可以次判斷SQL是否加入分頁語法
        ///// </summary>
        //public bool IsPage { get; set; } = true;
        //#endregion
    }
}
