﻿using System.Data;
using System.IO;
using Aspose.Cells;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Repository;
using u = SGS.LIB.Common.Utility;

namespace SGS.LEGAL.DLS.Service
{
    public class BossDailyService : BaseService
    {
        private readonly SYS_USER? user;
        private readonly BOSS_DAILY model;

        public BossDailyService(SYS_USER? user, BOSS_DAILY? model) : base(user)
        {
            this.user = user;
            this.model = model ?? new(); // implement model if null
        }

        public DataTable? Get()
        {
            using BossDailyRepo repo = new(user);
            IList<BOSS_DAILY>? data = repo.Read(model);
            return u.ToDataTable(data);
        }

        /// <summary>
        /// 取得異常資料
        /// </summary>
        /// <param name="IsOnlyTWD">是否僅限台幣</param>
        /// <returns></returns>
        public DataTable? GetAbnormal(bool IsOnlyTWD)
        {
            using BossDailyRepo repo = new(user);
            IList<BOSS_DAILY>? data = repo.ReadAbnormal(IsOnlyTWD);
            return u.ToDataTable(data);
        }

        /// <summary>
        /// 設定舊資料過期
        /// </summary>
        public void UpdateOldDataAsExpired()
        {
            using BossDailyRepo repo = new(user);
            model.MDF_USER = user?.USER_ID;
            repo.UpdateOldDataAsExpired(model);
        }
        public void DeleteOldData()
        {
            using BossDailyRepo repo = new(user);
            repo.DeleteOldData(model);
            Logger.Information($"Delete {model.COMPANY} data");
        }

        /// <summary>
        /// 讀取指定 Excel，逐筆轉換資料並寫入
        /// </summary>
        /// <param name="file"></param>
        public void ReadExcelAndCreateData(string file)
        {
            Workbook? workbook = null;
            BOSS_DAILY? data = null;
            int count = 0;
            try
            {
                Logger.Information("Read Excel: {file}", file);
                workbook = new(file);
                Worksheet worksheet = workbook.Worksheets[0];
                // 資料起始
                int startRowIndex = 1;
                using BossDailyRepo repo = new(user);
                for (int i = startRowIndex; i <= worksheet.Cells.MaxDataRow; i++)
                {
                    // 取得目前資料列
                    Row r = worksheet.Cells.Rows[i];
                    // 建立並取得 BOSS_DAILY 結構化資料
                    data = GetBossDailyData(r);

#if DEBUG
                    if (data.CURR != "TWD") continue; // 只處理台幣
#endif

                    // 寫入資料
                    repo.Create(data);
                    //Logger.Information($"Add {data.COMPANY} {data.BOSS_NO} {data.INV_NO} {data.INV_AMT} {data.CURR}");
                    count++;
                }
                Logger.Information("Add {count} data", count);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Create Data failed: {@data}", data);
                throw;
            }
            finally
            {
                workbook?.Dispose();
            }
        }
        public void ReadExcelAndCreateData(Stream file)
        {
            Workbook? workbook = null;
            try
            {
                workbook = new(file);
                Worksheet worksheet = workbook.Worksheets[0];
                // 資料起始
                int startRowIndex = 1;
                using BossDailyRepo repo = new(user);
                for (int i = startRowIndex; i <= worksheet.Cells.MaxDataRow; i++)
                {
                    // 取得目前資料列
                    Row r = worksheet.Cells.Rows[i];
                    // 建立並取得 BOSS_DAILY 結構化資料
                    BOSS_DAILY data = GetBossDailyData(r);
                    // 寫入資料
                    repo.Create(data);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                workbook?.Dispose();
            }
        }

        /// <summary>
        /// 建立並取得一筆 BOSS_DAILY
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public BOSS_DAILY GetBossDailyData(Row r)
        {
            BOSS_DAILY data = new()
            {
                DI_ID = model.DI_ID,
                COMPANY = model.COMPANY,
                SEC = u.ReadAs(r[0].Value, ""),
                CC = u.ReadAs(r[1].Value, ""),
                LOC = u.ReadAs(r[2].Value, ""),
                BOSS_NO = u.ReadAs(r[3].Value, ""),
                CST_NO = u.ReadAs(r[4].Value, ""),
                CST_NM = u.ReadAs(r[5].Value, ""),
                INV_NO = u.ReadAs(r[6].Value, ""),
                BILL_NO = u.ReadAs(r[7].Value, ""),
                RPT_NO = u.ReadAs(r[8].Value, ""),
                INV_DT = u.ReadAs<DateTime?>(r[9].DisplayStringValue, null),
                CURR = u.ReadAs(r[10].Value, ""),
                INV_AMT = u.ReadAs(r[11].Value, 0),
                ACT_BALANCE = u.ReadAs(r[12].Value, 0),
                BUYER_NUMBER = u.ReadAs(r[13].Value, ""),
                INVOICE_PAYMENT_TERM = u.ReadAs(r[14].Value, ""),
                CUSTOMER_PAYMENT_TERM = u.ReadAs(r[15].Value, ""),
            };

            return data;
        }
    }
}
