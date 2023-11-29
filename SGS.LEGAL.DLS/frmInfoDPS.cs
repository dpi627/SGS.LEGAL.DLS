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
            txtReceiverPostCode.KeyDown += CheckKeyDown;
            txtReceiverAddress.KeyDown += CheckKeyDown;
            txtCcName.KeyDown += CheckKeyDown;
            txtCcPostCode.KeyDown += CheckKeyDown;
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
            // 如果有填寫任一副本欄位，就需要檢查所有副本資料
            if (!string.IsNullOrWhiteSpace(txtCcName.Text) ||
                !string.IsNullOrWhiteSpace(txtCcPostCode.Text) ||
                !string.IsNullOrWhiteSpace(txtCcAddress.Text))
            {
                u.IsVaild(ref txtCcName);
                u.IsVaild(ref txtCcPostCode, @"^[0-9]{3,6}$");
                u.IsVaild(ref txtCcAddress);
            }

            if (u.IsVaild(ref txtReceiverCEO) &&
                u.IsVaild(ref txtReceiverPostCode, @"^[0-9]{3,6}$") && // 檢查是否匹配 3-6 碼數字
                u.IsVaild(ref txtReceiverAddress))
                return true;

            return false;
        }

        //private bool CheckTextBox(ref TextBox textBox)
        //{
        //    if (string.IsNullOrWhiteSpace(textBox.Text))
        //    {
        //        textBox.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        private void SetData()
        {
            DepositContact.SND_NM = txtSenderName.Text;
            DepositContact.SND_POST_CODE = txtSenderPostCode.Text;
            DepositContact.SND_ADDR = txtSenderAddress.Text;
            DepositContact.SND_CEO = txtSenderCEO.Text;
            DepositContact.RCV_NM = txtReceiverName.Text;
            DepositContact.RCV_POST_CODE = txtReceiverPostCode.Text;
            DepositContact.RCV_ADDR = txtReceiverAddress.Text;
            DepositContact.RCV_CEO = txtReceiverCEO.Text;
            DepositContact.CC_NM = txtCcName.Text;
            DepositContact.CC_POST_CODE = txtCcPostCode.Text;
            DepositContact.CC_ADDR = txtCcAddress.Text;
            DepositContact.CC_CEO = txtCcCEO.Text;

            /// 無論總公司或分公司，收件回執之收件地址皆為總公司地址
            /// 總公司抓公司列表中，"無"分公司代碼(BRANCH_CODE)之資料
            COMPANY com = lstCompany
                .Where(x => string.IsNullOrWhiteSpace(x.BRANCH_CODE))
                .FirstOrDefault()!;
            DepositContact.COM_POST_CODE = com.COM_POST_CODE;
            DepositContact.COM_ADDR = com.COM_ADDR;
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
                    txtSenderPostCode.Text = com.BUS_POST_CODE;
                    txtSenderAddress.Text = com.BUS_REG_ADDR;
                }
            }
        }


    }
}
