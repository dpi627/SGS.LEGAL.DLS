using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Model;

namespace SGS.LEGAL.DLS
{
    public partial class frmUser : Form
    {
        private readonly FormConfig? config;
        private SYS_USER? CurrentUser => config?.CurrentUser;

        public frmUser() { }
        public frmUser(FormConfig config)
        {
            InitializeComponent();
            this.config = config;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            SetUserInfo();
        }

        private void SetUserInfo()
        {
            if (CurrentUser != null)
            {
                labName.Text = CurrentUser.USER_ID;
                labEmail.Text = CurrentUser.EMAIL;
                labEmpID.Text = CurrentUser.EMP_ID;
            }
            else
            {
                labName.Text = labEmpID.Text = labEmpID.Text = "";
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Construct....", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //CurrentUser.Name = "XXX";
            // TODO: ldap login
            SetUserInfo();
        }


    }
}
