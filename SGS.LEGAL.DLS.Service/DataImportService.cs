using Serilog;
using SGS.LIB.Common;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Repository;
using System.Data;
using System.Diagnostics;
using SGS.LEGAL.DLS.Repository.DataModel;

namespace SGS.LEGAL.DLS.Service
{
    public class DataImportService : BaseService
    {
        private readonly SYS_USER user;
        private readonly DATA_IMPORT model;

        public DataImportService(SYS_USER? user, DATA_IMPORT model = default) : base(user)
        {
            this.user = user ?? new SYS_USER();
            this.model = model;
        }

        public DataTable? Get()
        {
            using DataImportRepo repo = new(user);
            IList<DataImportDataModel>? data = repo.Read(model);
            //IList<vm> vm = data.Select(x => new vm(x)).ToList();
            return Utility.ToDataTable(data);
        }

        /// <summary>
        /// 執行資料匯入
        /// </summary>
        /// <param name="IsManual"></param>
        public void ImportData(bool IsManual = false, string? CompanyID = "")
        {
            Logger.Information("Start {ImportType} import", IsManual ? "Manual" : "Auto");
            model.IS_MANUAL = IsManual;
            CreateDataImport(IsManual);
            Logger.Information($"Create Import ID: {model.DI_ID}");

            // 取得公司資料
            using SysParamRepo p = new(user);
            IList<SYS_PARAM>? coms = p.Read("COMPANY");
            // 取得 Excel 檔案格式
            string? format = p.Read("FORMAT")?.FirstOrDefault()?.EXT_1;
            // 逐個公司處理 (TODO: 可以改為多執行緒+平行處理)
            string? fileName, filePath;
            // 紀錄單檔處理時間
            Stopwatch stopwatch = new();
            // 處理過程備註
            string final_reason = "";

            try
            {
                List<string> finishMsg = new();
                foreach (SYS_PARAM com in coms)
                {
                    // 如果有指定公司，只處理該公司
                    if (!"".Equals(CompanyID) && !CompanyID.Equals(com.P_VAL))
                        continue;

                    stopwatch.Restart(); // 開始計時

                    // 取得EXCEL路徑
                    fileName = string.Format(format, com.EXT_2, DateTime.Now.ToString("yyyyMMdd"));
                    filePath = Path.Combine(com.EXT_1, fileName);

                    #region 檔案不存在 => log & pass
                    if (!File.Exists(filePath))
                    {
                        string msg = $"File Not Exist: {fileName}";
                        final_reason+=$"{msg}. ";
                        Logger.Warning(msg);
                        continue; // next company
                    }
                    #endregion

                    using BossDailyService boss = new(user, new BOSS_DAILY() { DI_ID = model.DI_ID, COMPANY = com.P_VAL });
                    boss.UpdateOldDataAsExpired();　// 更新舊資料 (設定為失效)
                    //boss.DeleteOldData();　// 刪除舊資料 (不建議，因為可能會有其他資料參考到)
                    // 讀取 Excel，建立資料
                    boss.ReadExcelAndCreateData(filePath);

                    stopwatch.Stop(); // 停止計時
                    TimeSpan elapsedTime = stopwatch.Elapsed; // 取得經過時間
                    string formattedTime = elapsedTime.ToString(@"hh\:mm\:ss\.fff");
                    finishMsg.Add($"{com.P_VAL} cost time {formattedTime}");
                }

                finishMsg.ForEach(msg => Logger.Information(msg));

                UpdateDataImportAsFinished(DataImportStatus.Finished, final_reason);
                Logger.Information("Ended {ImportType} import", IsManual ? "Manual" : "Auto");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error");
                UpdateDataImportAsFinished(DataImportStatus.Error, ex.Message);
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// 建立一筆匯入資料並取得 ID
        /// </summary>
        /// <param name="IsManual">是否為手動匯入，預設否 (大部分應該都是每日自動轉入)</param>
        /// <returns></returns>
        public int CreateDataImport(bool IsManual)
        {
            model.IS_MANUAL = IsManual;
            model.CRT_USER = user.EMP_ID;
            model.PROCESS_START = DateTime.Now;
            using DataImportRepo di = new(user);
            model.DI_ID = di.Create(model);
            return model.DI_ID;
        }

        /// <summary>
        /// 更新每日匯入紀錄狀態
        /// </summary>
        /// <param name="DailyImportID"></param>
        /// <param name="DailyImportStatus">資料狀態狀態，預設完成</param>
        /// <param name="FinishReason">寫入完成或異常訊息</param>
        public void UpdateDataImportAsFinished(string DailyImportStatus = DataImportStatus.Finished, string? FinishReason = null)
        {
            //model.PROCESS_END = DateTime.Now;
            model.MDF_USER = user.EMP_ID;
            model.DI_STA = DailyImportStatus;
            model.FINISH_REASON = FinishReason;

            using DataImportRepo di = new(user);
            di.Update(model);
        }
    }
}