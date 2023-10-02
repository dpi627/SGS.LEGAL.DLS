using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Repository.Condition;
using SGS.LEGAL.DLS.Repository.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LEGAL.DLS.Repository
{
    public class DocLogRepo : BaseRepo
    {
        public DocLogRepo(SYS_USER? user) : base(user)
        {
        }

        public IList<DocLogDataModel> Read(DocLogCondition condition)
        {
            //日期變數處理
            if (condition?.START_DATE != null && condition?.END_DATE != null)
            {
                condition.START_DATE = condition.START_DATE.Date; //只取日期，時分秒會默認 00:00:00
                condition.END_DATE = condition.END_DATE.Date.AddDays(1).AddSeconds(-1); //時分秒改為 23:59:59
            }

            arrParam = new ArrayList
            {
                string.IsNullOrWhiteSpace(condition?.COMPANY) ? "" : "bd.COMPANY = @COMPANY",
                (condition?.START_DATE == null || condition?.END_DATE == null) ? "" : "d.CRT_DATE between @START_DATE and @END_DATE",
                string.IsNullOrWhiteSpace(condition?.KEYWORD) ? "" : "(bd.CST_NM like '%'+@KEYWORD+'%' or bd.CST_NO like '%'+@KEYWORD+'%' or bd.BOSS_NO like '%'+@KEYWORD+'%')",
            };

            strSql = $@"
                select top 100
                    d.* 
                    ,bd.COMPANY
                    ,com.P_TXT as COMPANY_NM
                    ,bd.BOSS_NO
                    ,bd.CST_NO
                    ,bd.CST_NM
                    ,p1.P_TXT as FIL_TYP_NM
                    ,p2.P_TXT as LET_TYP_NM
                    ,u.USER_NM
                    ,u.EMP_ID
                from DOC_LOG d
                    left join BOSS_DAILY bd on bd.BD_ID=d.BD_ID_1ST
                    left join SYS_USER u on u.EMP_ID=d.CRT_USER
                    left join SYS_PARAM p1 on p1.P_CLS='FILE' and p1.P_VAL=d.FIL_TYP
                    left join SYS_PARAM p2 on p2.P_CLS='D_LETTER' and p2.P_VAL=d.LET_TYP
                    left join SYS_PARAM com on com.P_CLS='COMPANY' and com.P_VAL=bd.COMPANY
                where 1=1 {ParamStr}
                order by DOC_ID desc
            ";
            return ExecuteQuery<DocLogDataModel>(strSql, condition);
        }

        public DocLogDataModel? Read(string? DOC_ID)
        {
            strSql = @"select * from DOC_LOG where DOC_ID = @DOC_ID";
            return ExecuteQuery<DocLogDataModel>(strSql, new { DOC_ID }).FirstOrDefault();
        }

        public bool Create(DOC_LOG? model)
        {
            strSql = @"
                insert into DOC_LOG (
                    DOC_ID
                    ,BD_ID_1ST
                    ,FIL_TYP
                    ,LET_TYP
                    ,BAK_PATH
                    ,CRT_USER
                ) values (
                    @DOC_ID
                    ,@BD_ID_1ST
                    ,@FIL_TYP
                    ,@LET_TYP
                    ,@BAK_PATH
                    ,@CRT_USER
                )
            ";
            return ExecuteCommand(strSql, model);
        }
    }
}
