using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Parameter;
using SGS.LEGAL.DLS.Service;
using System.Data;
using u = SGS.LEGAL.DLS.Utility;

namespace SGS.LEGAL.DLS
{
    public partial class frmInfoDPS : Form
    {
        IList<COMPANY>? lstCompany;

        public DepositContactParameter DepositContact { get; set; } = new();

        public frmInfoDPS(DepositContactParameter contact)
        {
            this.DepositContact = contact;
            InitializeComponent();
            InitData();
            SetCompany();
        }

        private void frmInfoDPS_Load(object sender, EventArgs e)
        {
            ccbCompany_SelectedIndexChanged(null, null);
            txtReceiverCEO.KeyDown += CheckKeyDown;
            txtReceiverAddress.KeyDown += CheckKeyDown;
            txtCcName.KeyDown += CheckKeyDown;
            txtCcAddress.KeyDown += CheckKeyDown;
        }

        private void frmInfoDPS_Shown(object sender, EventArgs e)
        {
            txtReceiverCEO.Focus();
        }

        private void SetCompany()
        {
            using CompanyService svc = new(null);
            lstCompany = svc.GetAll(DepositContact.COM_CODE);

            ccbCompany.DataSource = lstCompany;
            ccbCompany.DisplayMember = "COM_NM";
            ccbCompany.ValueMember = "BRANCH_CODE";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetData();
            if (!IsDataVaild())
                return;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CheckKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is TextBox)
                {
                    btnSave_Click(sender, e);
                }
            }
        }

        private bool IsDataVaild()
        {
            if (string.IsNullOrWhiteSpace(txtReceiverCEO.Text))
            {
                txtReceiverCEO.Focus();
                return u.ShowMsg("請填寫收件人公司代表人");
            }

            if (string.IsNullOrWhiteSpace(txtReceiverAddress.Text))
            {
                txtReceiverAddress.Focus();
                return u.ShowMsg("請填寫收件人地址");
            }

            return true;
        }

        private bool CheckTextBox(ref TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Focus();
                return false;
            }
            return true;
        }

        private void SetData()
        {
            DepositContact.SND_NM = txtSenderName.Text;
            DepositContact.SND_ADDR = txtSenderAddress.Text;
            DepositContact.SND_CEO = txtSenderCEO.Text;
            DepositContact.RCV_NM = txtReceiverName.Text;
            DepositContact.RCV_ADDR = txtReceiverAddress.Text;
            DepositContact.RCV_CEO = txtReceiverCEO.Text;
            DepositContact.CC_NM = txtCcName.Text;
            DepositContact.CC_ADDR = txtCcAddress.Text;

            /// 無論總公司或分公司，收件回執之收件地址皆為總公司地址
            /// 總公司抓公司列表中，"無"分公司代碼(BRANCH_CODE)之資料
            DepositContact.COM_ADDR = lstCompany
                .Where(x => string.IsNullOrWhiteSpace(x.BRANCH_CODE))
                .FirstOrDefault()!
                .COM_ADDR!;
        }

        private void InitData()
        {
            //txtSenderName.Text = DepositContact.SND_NM;
            //txtSenderAddress.Text = DepositContact.SND_ADDR;
            txtReceiverName.Text = DepositContact.RCV_NM;
            //txtReceiverAddress.Text = DepositContact.RCV_ADDR;
            //txtCcName.Text = DepositContact.CC_NM;
            //txtCcAddress.Text = DepositContact.CC_ADDR;
            //cbbExt1.Text = DepositContact.AMT_NM;
        }

        private void ccbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ccbCompany.SelectedIndex != -1)
            {
                string selectedValue = ccbCompany.SelectedValue.ToString();
                COMPANY com = lstCompany.Where(x => x.BRANCH_CODE == selectedValue).FirstOrDefault();
                if (com != null)
                {
                    txtSenderName.Text = com.COM_NM;
                    txtSenderCEO.Text = com.CEO;
                    txtSenderAddress.Text = com.BUS_REG_ADDR;
                }
            }
        }


    }
}
