using SGS.LEGAL.DLS.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LEGAL.DLS.Repository
{
    public class SysParamRepo : BaseRepo
    {
        public SysParamRepo(SYS_USER user) : base(user)
        {
        }

        public IList<SYS_PARAM> Read(SYS_PARAM model)
        {
            //where條件組成
            arrParam = new ArrayList
            {
                model.IS_DEL ? "" : "IS_DEL=0",
                string.IsNullOrEmpty(model.P_CLS) ? "" : "P_CLS = @P_CLS",
                string.IsNullOrEmpty(model.P_TXT) ? "" : "P_TXT = @P_TXT"
            };

            //sql語法組成
            strSql = string.Format(@"
                select *, (count(0) over ()) as TOTAL 
                from SYS_PARAM
                where 1=1 {0}
                order by P_SEQ, P_ID
                offset @SKIP rows fetch next @TAKE rows only
            ", ParamStr);

            //執行並回傳
            return ExecuteQuery<SYS_PARAM>(strSql, model);
        }

        public IList<SYS_PARAM> Read(string P_CLS)
        {
            strSql = @"
                select * 
                from SYS_PARAM 
                where IS_DEL=0 and P_CLS = @P_CLS
                order by P_SEQ, P_ID
            ";
            return ExecuteQuery<SYS_PARAM>(strSql, new { P_CLS });
        }

        public SYS_PARAM Read(int P_ID)
        {
            strSql = @"select * from SYS_PARAM where P_ID = @P_ID";
            return ExecuteQuery<SYS_PARAM>(strSql, new { P_ID }).FirstOrDefault();
        }

        public SYS_PARAM Read(string P_CLS, string P_TXT)
        {
            strSql = @"select * from SYS_PARAM where P_CLS = @P_CLS and P_TXT=@P_TXT";
            return ExecuteQuery<SYS_PARAM>(strSql, new { P_CLS, P_TXT }).FirstOrDefault();
        }
    }
}
