using SGS.LEGAL.DLS.Entity;
using System.Collections;

namespace SGS.LEGAL.DLS.Repository
{
    public class BossDailyRepo : BaseRepo
    {
        public BossDailyRepo(SYS_USER? user) : base(user)
        {
        }

        public IList<BOSS_DAILY> Read(BOSS_DAILY model)
        {
			//日期變數處理
			if (model.DATE_S != null && model.DATE_E != null)
			{
				model.DATE_S = model.DATE_S.Value.Date; //只取日期，時分秒會默認 00:00:00
				model.DATE_E = model.DATE_E.Value.Date.AddDays(1).AddSeconds(-1); //時分秒改為 23:59:59
            }

            //where條件組成
            arrParam = new ArrayList
            {
                model.COMPANY == null ? "" : "bd.COMPANY = @COMPANY",
                model.BD_STA == null? "" : "bd.BD_STA = @BD_STA",
				model.KEYWORD == null ? "" : "(bd.CST_NM like '%'+@KEYWORD+'%' or bd.CST_NO like '%'+@KEYWORD+'%' or bd.BOSS_NO like '%'+@KEYWORD+'%')",
				(model.DATE_S == null || model.DATE_E == null) ? "" : "bd.INV_DT >= @DATE_S",
            };

            //sql語法組成
            strSql = string.Format(@"
                select top 200
                    bd.BD_ID
                    ,bd.BOSS_NO
                    ,bd.CST_NO
                    ,bd.CST_NM
                    ,bd.BILL_NO
                    ,bd.RPT_NO
                    ,bd.INV_NO
                    ,bd.INV_DT
                    ,bd.CURR
                    ,bd.INV_AMT
                    ,bd.ACT_BALANCE
                    ,bd.CRT_USER
                    ,bd.CRT_DATE
                    ,p.P_TXT as BD_STA_NM
                    ,com.P_TXT as COMPANY_NM
                    ,cur.EXT_1 as PRECISION
                    -- ,(count(0) over ()) as TOTAL
                from BOSS_DAILY bd
                    left join SYS_PARAM p on p.P_CLS='BD_STA' and p.P_VAL=bd.BD_STA
					left join SYS_PARAM com on com.P_CLS='COMPANY' and com.P_VAL=bd.COMPANY
					left join SYS_PARAM cur on cur.P_CLS='CURRENCY' and cur.P_VAL=bd.CURR
                where CURR = 'TWD' {0}
				order by BD_ID DESC
                -- offset @SKIP rows fetch next @TAKE rows only
            ", ParamStr);

            //執行並回傳
            return ExecuteQuery<BOSS_DAILY>(strSql, model);
        }

        public bool Create(BOSS_DAILY model)
        {
            strSql = @"
                INSERT INTO BOSS_DAILY
				(
					DI_ID
					,COMPANY
					,SEC
					,CC
					,LOC
					,BOSS_NO
					,CST_NO
					,CST_NM
					,INV_NO
					,BILL_NO
					,RPT_NO
					,INV_DT
					,CURR
					,INV_AMT
					,ACT_BALANCE
					,BUYER_NUMBER
					,INVOICE_PAYMENT_TERM
					,CUSTOMER_PAYMENT_TERM
					,BD_STA
					,CRT_USER
					,CRT_DATE
				)
				VALUES
				(
					@DI_ID
					,@COMPANY
					,@SEC
					,@CC
					,@LOC
					,@BOSS_NO
					,@CST_NO
					,@CST_NM
					,@INV_NO
					,@BILL_NO
					,@RPT_NO
					,@INV_DT
					,@CURR
					,@INV_AMT
					,@ACT_BALANCE
					,@BUYER_NUMBER
					,@INVOICE_PAYMENT_TERM
					,@CUSTOMER_PAYMENT_TERM
					,'N'
					,@CRT_USER
					,getdate()
				)
            ";
            return ExecuteCommand(strSql, model);
        }


        /// <summary>
        /// 將特定公司之舊資料設定為過期
        /// 使用匯入時間 IMPORT_TIME 判斷
        /// </summary>
        public bool UpdateOldDataAsExpired(BOSS_DAILY model)
        {
            strSql = @"
				update BOSS_DAILY set 
					BD_STA = 'E',
					MDF_USER = @MDF_USER,
					MDF_DATE = getdate()
				where 
					CRT_DATE < getdate()
					and isnull(BD_STA,'') <> 'E'
					and COMPANY = @COMPANY
			";
            return ExecuteCommand(strSql, model);
        }
        public bool DeleteOldData(BOSS_DAILY model)
        {
            strSql = @"
				delete from BOSS_DAILY
				where 
					CRT_DATE < getdate()
					and COMPANY = @COMPANY
			";
            return ExecuteCommand(strSql, model);
        }

        /// <summary>
        /// 讀取可能異常資料
        /// </summary>
        /// <param name="IsOnlyTWD">是否只抓台幣</param>
        /// <returns></returns>
        public IList<BOSS_DAILY> ReadAbnormal(bool IsOnlyTWD = true)
        {
            //where條件組成
            arrParam = new ArrayList
            {
                IsOnlyTWD ? "bd.CURR = 'TWD'" : ""
            };

            strSql = string.Format(@"
                select top 200
                    bd.*
                    ,p.P_TXT as BD_STA_NM
                    ,com.P_TXT as COMPANY_NM
                    ,cur.EXT_1 as PRECISION
                from BOSS_DAILY bd
                    left join SYS_PARAM p on p.P_CLS='BD_STA' and p.P_VAL=bd.BD_STA
					left join SYS_PARAM com on com.P_CLS='COMPANY' and com.P_VAL=bd.COMPANY
					left join SYS_PARAM cur on cur.P_CLS='CURRENCY' and cur.P_VAL=bd.CURR
                where bd.BD_STA='N' {0}
					and (isnull(BILL_NO,'')='' or isnull(RPT_NO,'')='' or isnull(INV_AMT,0)=0 or isnull(ACT_BALANCE,0)=0)
            ", ParamStr);

            return ExecuteQuery<BOSS_DAILY>(strSql);
        }
    }
}
