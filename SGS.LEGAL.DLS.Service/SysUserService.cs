using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Repository;

namespace SGS.LEGAL.DLS.Service
{
    public class SysUserService : BaseService
    {
        private readonly SYS_USER? user;

        public SysUserService(SYS_USER? user = default) : base(user)
        {
            this.user = user;
        }

        public SYS_USER? Get(string? EMP_ID)
        {
            using SysUserReop repo = new(user);
            return repo.Read(EMP_ID);
        }
    }
}
