using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service;
using System.DirectoryServices.AccountManagement;
using LoadingIndicator.WinForms;


namespace SGS.LEGAL.DLS
{
    public class frmBase : Form
    {
        protected readonly LongOperation _loader;
        protected UserPrincipal? AdUser;

        protected SYS_USER? CurrentUser { get; set; }

        public frmBase()
        {
            _loader = new LongOperation(this);
            SetAdUser();
            SetCurrentUser();
        }

        private void SetAdUser()
        {
            AdUser = Utility.GetCurrentAdUser();
        }

        private void SetCurrentUser()
        {
            if (this.CurrentUser != null) return;

            using SysUserService svc = new();
            this.CurrentUser = svc.Get(AdUser?.EmployeeId);
        }
    }
}
