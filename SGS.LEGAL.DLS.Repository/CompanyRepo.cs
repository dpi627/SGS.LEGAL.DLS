using SGS.LEGAL.DLS.Entity;

namespace SGS.LEGAL.DLS.Repository
{
    public class CompanyRepo : BaseRepo
    {
        public CompanyRepo(SYS_USER? user) : base(user)
        {
        }

        public IList<COMPANY>? Read(string COM_CODE, string BRANCH_CODE = "")
        {
            strSql = @"select * from COMPANY where COM_CODE = @COM_CODE";

            if (!string.IsNullOrWhiteSpace(BRANCH_CODE))
                strSql += " and BRANCH_CODE = @BRANCH_CODE";

            return ExecuteQuery<COMPANY>(strSql, new { COM_CODE, BRANCH_CODE });
        }
    }
}
