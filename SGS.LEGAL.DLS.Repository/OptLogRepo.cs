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
    public class OptLogRepo : BaseRepo
    {
        public OptLogRepo(SYS_USER? user) : base(user)
        {
        }

        public IList<OptLogDataModel> Read(OptLogCondition condition)
        {
            arrParam = new ArrayList
            {
                condition.DATE_START == null ? "" : "o.CRT_DATE >= @DATE_START",
                condition.DATE_END == null? "" : "o.CRT_DATE <= @DATE_END"
            };

            strSql = $@"
                select top 100
                    o.*
                    ,p0.P_TXT as ACT_NM
                    ,p1.P_TXT as FUNC_NM
                    ,u.USER_NM as USER_NM
                from OPT_LOG o 
                    left join SYS_PARAM p0 on p0.P_CLS='ACTION' and p0.P_VAL=o.ACT_ID
                    left join SYS_PARAM p1 on p1.P_CLS='FUNCTION' and p1.P_VAL=o.MSG
                    left join SYS_USER u on u.EMP_ID=o.CRT_USER
                where 1=1 {ParamStr}
                order by o.LOG_ID desc
            ";

            return ExecuteQuery<OptLogDataModel>(strSql, condition);
        }

        public bool Create(OPT_LOG? model)
        {
            strSql = @"
                insert into OPT_LOG (
                    ACT_ID
                    ,MSG
                    ,MEMO
                    ,CRT_USER
                ) values (
                    @ACT_ID
                    ,@MSG
                    ,@MEMO
                    ,@CRT_USER
                )
            ";
            return ExecuteCommand(strSql, model);
        }
    }
}
