using Aspose.Words.XAttr;
using SGS.LEGAL.DLS.Model;

namespace SGS.LEGAL.DLS
{
    public partial class frmInfoDUN : Form
    {
        public Customer _cst;

        public frmInfoDUN(Customer cst)
        {
            InitializeComponent();
            this._cst = cst;
        }

        private void frmInfoDUN_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetData();

            if (!CheckData())
                return;

            this.Close();
        }

        private bool CheckData()
        {
            bool vaild = _cst.IsValid();

            if (!vaild)
            {
                MessageBox.Show(_cst.ErrorMsg, "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return vaild;
        }

        private void InitData()
        {
            txtCST_NM.Text = _cst.CST_NM;
            txtCST_DEPT.Text = _cst.CST_DEPT;
            txtCST_ADDR.Text = _cst.CST_ADDR;
            txtCST_NO.Text = _cst.CST_NO;
            txtBOSS_NO.Text = _cst.BOSS_NO;
            //txtCST_FAX.Text = _cst.CST_FAX;
            //txtCST_MAIL.Text = _cst.CST_MAIL;
        }

        private void SetData()
        {
            _cst.CST_NM = txtCST_NM.Text;
            _cst.CST_DEPT = txtCST_DEPT.Text;
            _cst.CST_ADDR = txtCST_ADDR.Text;
            _cst.CST_NO = txtCST_NO.Text;
            _cst.BOSS_NO = txtBOSS_NO.Text;
            //_cst.CST_FAX = txtCST_FAX.Text;
            //_cst.CST_MAIL = txtCST_MAIL.Text;
        }
    }
}
