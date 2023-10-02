using System.Security.Principal;
using System.Runtime.InteropServices;

namespace SGS.LIB.Common
{
    public class Impersonator : IDisposable
    {
        public WindowsIdentity? Identity = null;
        private IntPtr accessToken = new(0);
        protected const int LOGON32_PROVIDER_DEFAULT = 0;
        protected const int LOGON32_LOGON_INTERACTIVE = 2;

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private extern static bool CloseHandle(IntPtr handle);

        public Impersonator(string UserID, string Password, string Domain = "APAC")
        {
            Login(UserID, Password, Domain);
        }

        private void Login(string username, string password, string domain)
        {
            ReleaseIdentity();

            try
            {
                Logout();
                accessToken = IntPtr.Zero;

                bool isSuccess = LogonUser(
                    username,
                    domain,
                    password,
                    LOGON32_LOGON_INTERACTIVE,
                    LOGON32_PROVIDER_DEFAULT,
                    ref accessToken);

                if (!isSuccess)
                {
                    int error = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(error);
                }

                Identity = new WindowsIdentity(accessToken);
            }
            catch
            {
                throw;
            }
        }

        private void Logout()
        {
            if (accessToken != IntPtr.Zero)
                CloseHandle(accessToken);
            accessToken = IntPtr.Zero;
            ReleaseIdentity();
        }

        private void ReleaseIdentity()
        {
            if (Identity != null)
            {
                Identity.Dispose();
                Identity = null;
            }
        }

        public void Run(Action action)
        {
            if (Identity == null)
                throw new Exception("Identity is null");
            WindowsIdentity.RunImpersonated(Identity.AccessToken, action);
        }

        public void Dispose() => Logout();
        ~Impersonator() => Logout();
    }
}
