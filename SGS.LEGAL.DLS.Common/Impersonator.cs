using System.Security.Principal;
using System.Runtime.InteropServices;

namespace SGS.LIB.Common
{
    #region Enum
    // ref http://msdn.microsoft.com/en-us/library/windows/desktop/aa378184.aspx
    public enum LogonType
    {
        Interactive = 2,
        Network = 3,
        Batch = 4,
        Service = 5,
        Unlock = 7,
        NetworkCleartext = 8,
        NewCredentials = 9
    }

    // ref http://msdn.microsoft.com/en-us/library/windows/desktop/aa378184.aspx
    public enum LogonProvider
    {
        Default = 0,
        NTLM = 2,
        Negotiate = 3
    }
    #endregion

    public class Impersonator : IDisposable
    {
        public WindowsIdentity? Identity = null;
        private IntPtr accessToken = IntPtr.Zero;

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword,
            int dwLogonType, int dwLogonProvider, out IntPtr phToken);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private extern static bool CloseHandle(IntPtr handle);

        public Impersonator(string UserID, string Password, string Domain = "APAC")
        {
            Login(UserID, Password, Domain);
        }
        public Impersonator(string UserID, string Password, string Domain, LogonType Type = LogonType.Interactive, LogonProvider Provider = LogonProvider.Default)
        {
            Login(UserID, Password, Domain, Type, Provider);
        }

        private void Login(string username, string password, string domain,
            LogonType type = LogonType.Interactive,
            LogonProvider provider = LogonProvider.Default)
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
                    type.GetHashCode(),
                    provider.GetHashCode(),
                    out accessToken);

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

        public void Run(Action action)
        {
            if (Identity == null)
                throw new Exception("Identity is null");
            WindowsIdentity.RunImpersonated(Identity.AccessToken, action);
        }
        public T Run<T>(Func<T> func)
        {
            if (Identity == null)
                throw new Exception("Identity is null");
            return WindowsIdentity.RunImpersonated(Identity.AccessToken, func);
        }

        public async Task RunAsync(Action action)
        {
            if (Identity == null)
                throw new Exception("Identity is null");
            await WindowsIdentity.RunImpersonatedAsync(Identity.AccessToken, () =>
            {
                action();
                return Task.CompletedTask;
            });
        }
        public async Task<T> RunAsync<T>(Func<Task<T>> func)
        {
            if (Identity == null)
                throw new Exception("Identity is null");
            return await WindowsIdentity.RunImpersonatedAsync(Identity.AccessToken, func);
        }

        #region 釋放資源相關
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

        public void Dispose() => Logout();
        ~Impersonator() => Logout();
        #endregion
    }
}
