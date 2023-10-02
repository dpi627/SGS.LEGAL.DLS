using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Repository;

namespace SGS.LEGAL.DLS.Service
{
    public class CompanyService : BaseService
    {
        private SYS_USER? user;
        public CompanyService(SYS_USER? user) : base(user)
        {
            this.user = user;
        }

        public COMPANY? Get(string COM_CODE, string BRANCH_CODE = "")
        {
            using CompanyRepo repo = new(user);
            return repo.Read(COM_CODE, BRANCH_CODE).FirstOrDefault();
        }
        public IList<COMPANY>? GetAll(string COM_CODE)
        {
            using CompanyRepo repo = new(user);
            return repo.Read(COM_CODE);
        }
    }
}
