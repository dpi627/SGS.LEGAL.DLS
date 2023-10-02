using SGS.LEGAL.DLS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LEGAL.DLS.Repository
{
    public class OptLogRepo:BaseRepo
    {
        public OptLogRepo(SYS_USER? user) : base(user)
        {
        }

        public IList<OPT_LOG> Read()
        {
            strSql = @"
                select * from OPT_LOG 
                where 1=1
                order by LOG_ID desc
            ";
            return ExecuteQuery<OPT_LOG>(strSql);
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
