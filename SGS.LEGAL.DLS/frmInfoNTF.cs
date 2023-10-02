using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Model;
using SGS.LEGAL.DLS.Service;
using u = SGS.LEGAL.DLS.Utility;

namespace SGS.LEGAL.DLS
{
    public partial class frmInfoNTF : Form
    {
        public Customer _cst;
        private LetterType _type;
        private IList<SYS_PARAM> _notices;

        public frmInfoNTF(Customer cst, LetterType type = LetterType.NTF)
        {
            InitializeComponent();
            this._cst = cst;
            this._type = type;
            txtCST_DEPT.KeyDown += CheckKeyDown;
            txtCST_ADDR.KeyDown += CheckKeyDown;
        }

        private void frmNTF_Load(object sender, EventArgs e)
        {
            InitData();

            if (_type == LetterType.NTF)
            {
                // 通知函需要設定通知事項
                SetNotices();
                SetRadioButtons();
            }
            else
            {
                // 催收函隱藏通知事項，並扣除視窗高度
                groupBox2.Visible = false;
                int offset = groupBox2.Height;
                MinimumSize = new Size(MinimumSize.Width, MinimumSize.Height - offset);
                Size = new Size(MinimumSize.Width, MinimumSize.Height - offset);
            }
        }

        private void frmInfoNTF_Shown(object sender, EventArgs e)
        {
            txtCST_ADDR.Focus();
        }

        /// <summary>
        /// 設定通知事項 from 參數表
        /// </summary>
        private void SetNotices()
        {
            using SysParamService svc = new(null);
            this._notices = svc.Get("NTF_NOTICE")!;
        }

        /// <summary>
        /// 動態產生 RadioButton，並加入到 FlowLayoutPanel
        /// </summary>
        private void SetRadioButtons()
        {
            // 沒有資料就離開
            if (_notices.Count <= 0) return;
            // 動態產生 RadioButton，並加入到 FlowLayoutPanel
            foreach (SYS_PARAM notice in _notices)
            {
                RadioButton rb = new()
                {
                    Text = notice.P_VAL,
                    Name = $"rb{notice.P_VAL}",
                    AutoSize = true,
                    Checked = false
                };
                rb.CheckedChanged += new EventHandler(RadioButton_CheckedChanged!);
                flowPanel.Controls.Add(rb);
            }
            // 預設選取第一個
            flowPanel.Controls.OfType<RadioButton>().FirstOrDefault()!.Checked = true;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton btnSelected && btnSelected.Checked)
            {
                labNotice.Text = _notices
                    .Where(x => x.P_VAL == btnSelected.Text)
                    .FirstOrDefault()?
                    .EXT_1;
            }
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
            if (string.IsNullOrWhiteSpace(txtCST_DEPT.Text))
            {
                txtCST_DEPT.Focus();
                return u.ShowMsg("請填寫客戶部門");
            }

            if (string.IsNullOrWhiteSpace(txtCST_ADDR.Text))
            {
                txtCST_ADDR.Focus();
                return u.ShowMsg("請填寫客戶地址");
            }

            return true;
        }

        private void InitData()
        {
            txtCST_NM.Text = _cst.CST_NM;
            txtCST_DEPT.Text = _cst.CST_DEPT;
            txtCST_ADDR.Text = _cst.CST_ADDR;
            txtCST_NO.Text = _cst.CST_NO;
            txtBOSS_NO.Text = _cst.BOSS_NO;
        }

        private void SetData()
        {
            _cst.CST_NM = txtCST_NM.Text;
            _cst.CST_DEPT = txtCST_DEPT.Text;
            _cst.CST_ADDR = txtCST_ADDR.Text;
            _cst.CST_NO = txtCST_NO.Text;
            _cst.BOSS_NO = txtBOSS_NO.Text;
            _cst.NOTICE = labNotice.Text;
        }

    }
}
