using SGS.LEGAL.DLS.Entity;

namespace SGS.LEGAL.DLS.Repository
{
    public class SysUserReop : BaseRepo
    {
        public SysUserReop(SYS_USER? user) : base(user)
        {
        }

        public SYS_USER? Read(string? EMP_ID)
        {
            strSql = @"
                select 
                    u.*
                    ,p.P_TXT as DEPT_NM
                from SYS_USER u
                    left join SYS_PARAM p on p.P_CLS='DEPT' and p.P_VAL=u.DEPT_ID
                where u.EMP_ID=@EMP_ID
            ";
            return ExecuteQuery<SYS_USER>(strSql, new { EMP_ID }).FirstOrDefault();
        }
    }
}
