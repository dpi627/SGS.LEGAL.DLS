using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Repository.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LEGAL.DLS.Repository
{
    public class DataImportRepo : BaseRepo
    {
        public DataImportRepo(SYS_USER? user) : base(user)
        {
        }

        public IList<DataImportDataModel> Read(DATA_IMPORT model)
        {
            //where條件組成
            arrParam = new ArrayList
            {
                model.PROCESS_START == null ? "" : "PROCESS_START >= @PROCESS_START",
                model.PROCESS_END == null? "" : "PROCESS_END <= @PROCESS_END"
            };

            //sql語法組成
            strSql = string.Format(@"
                select top 50
                    u.EMP_ID
                    ,u.USER_NM
                    ,p.P_TXT as DI_STA_NM
                    ,d.*
                    ,(count(0) over ()) as TOTAL
                from DATA_IMPORT d
                    left join SYS_PARAM p on p.P_CLS='DI_STA' and p.P_VAL=d.DI_STA
                    left join SYS_USER u on u.EMP_ID=d.CRT_USER
                where 1=1 {0}
                order by DI_ID desc
                -- offset @SKIP rows fetch next @TAKE rows only
            ", ParamStr);

            //執行並回傳
            return ExecuteQuery<DataImportDataModel>(strSql, model);
        }

        public int Create(DATA_IMPORT model)
        {
            strSql = @"
                insert into DATA_IMPORT
                    (PROCESS_START, DI_STA, IS_MANUAL, CRT_USER)
                values
                    (@PROCESS_START, @DI_STA, @IS_MANUAL, @CRT_USER)
            ";

            return ExecuteGetID(strSql, model);
        }

        public void Update(DATA_IMPORT model)
        {
            strSql = @"
                update DATA_IMPORT
                set
                    PROCESS_END = getdate(),
                    FINISH_REASON = @FINISH_REASON,
                    DI_STA = @DI_STA,
                    MDF_USER = @MDF_USER,
                    MDF_DATE = getdate()
                where DI_ID = @DI_ID
            ";

            ExecuteQuery(strSql, model);
        }
    }
}
