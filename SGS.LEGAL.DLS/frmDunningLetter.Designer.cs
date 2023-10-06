namespace SGS.LEGAL.DLS
{
    partial class frmDunningLetter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtKeyword = new TextBox();
            dgvBossDaily = new DataGridView();
            BD_ID = new DataGridViewTextBoxColumn();
            Company = new DataGridViewTextBoxColumn();
            BossNo = new DataGridViewTextBoxColumn();
            CustmerNo = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            BillNo = new DataGridViewTextBoxColumn();
            ReportNo = new DataGridViewTextBoxColumn();
            InvoiceNo = new DataGridViewTextBoxColumn();
            InvoiceDate = new DataGridViewTextBoxColumn();
            Currency = new DataGridViewTextBoxColumn();
            InvoiceAmount = new DataGridViewTextBoxColumn();
            AcountBalance = new DataGridViewTextBoxColumn();
            CreateUser = new DataGridViewTextBoxColumn();
            CreateDate = new DataGridViewTextBoxColumn();
            btnSearch = new FontAwesome.Sharp.IconButton();
            btnNTF = new FontAwesome.Sharp.IconButton();
            btnDUN = new FontAwesome.Sharp.IconButton();
            btnDPS = new FontAwesome.Sharp.IconButton();
            cbbCompany = new ComboBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            btnAbnormal = new FontAwesome.Sharp.IconButton();
            chkOnlyTWD = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvBossDaily).BeginInit();
            SuspendLayout();
            // 
            // txtKeyword
            // 
            txtKeyword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyword.Location = new Point(461, 12);
            txtKeyword.Margin = new Padding(0, 3, 0, 3);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Boss、統編或客戶名稱";
            txtKeyword.Size = new Size(474, 28);
            txtKeyword.TabIndex = 0;
            txtKeyword.KeyDown += txtKeyword_KeyDown;
            // 
            // dgvBossDaily
            // 
            dgvBossDaily.AllowUserToAddRows = false;
            dgvBossDaily.AllowUserToDeleteRows = false;
            dgvBossDaily.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBossDaily.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBossDaily.Columns.AddRange(new DataGridViewColumn[] { BD_ID, Company, BossNo, CustmerNo, CustomerName, BillNo, ReportNo, InvoiceNo, InvoiceDate, Currency, InvoiceAmount, AcountBalance, CreateUser, CreateDate });
            dgvBossDaily.Location = new Point(12, 53);
            dgvBossDaily.Margin = new Padding(3, 10, 3, 10);
            dgvBossDaily.Name = "dgvBossDaily";
            dgvBossDaily.ReadOnly = true;
            dgvBossDaily.RowHeadersWidth = 30;
            dgvBossDaily.RowTemplate.Height = 32;
            dgvBossDaily.Size = new Size(990, 576);
            dgvBossDaily.TabIndex = 1;
            dgvBossDaily.TabStop = false;
            // 
            // BD_ID
            // 
            BD_ID.DataPropertyName = "BD_ID";
            BD_ID.HeaderText = "BD_ID";
            BD_ID.Name = "BD_ID";
            BD_ID.ReadOnly = true;
            BD_ID.Visible = false;
            // 
            // Company
            // 
            Company.DataPropertyName = "COMPANY_NM";
            Company.HeaderText = "公司";
            Company.Name = "Company";
            Company.ReadOnly = true;
            // 
            // BossNo
            // 
            BossNo.DataPropertyName = "BOSS_NO";
            BossNo.HeaderText = "Boss No";
            BossNo.Name = "BossNo";
            BossNo.ReadOnly = true;
            // 
            // CustmerNo
            // 
            CustmerNo.DataPropertyName = "CST_NO";
            CustmerNo.HeaderText = "統編";
            CustmerNo.Name = "CustmerNo";
            CustmerNo.ReadOnly = true;
            // 
            // CustomerName
            // 
            CustomerName.DataPropertyName = "CST_NM";
            CustomerName.HeaderText = "客戶名稱";
            CustomerName.Name = "CustomerName";
            CustomerName.ReadOnly = true;
            // 
            // BillNo
            // 
            BillNo.DataPropertyName = "BILL_NO";
            BillNo.HeaderText = "帳單";
            BillNo.Name = "BillNo";
            BillNo.ReadOnly = true;
            // 
            // ReportNo
            // 
            ReportNo.DataPropertyName = "RPT_NO";
            ReportNo.HeaderText = "報告";
            ReportNo.Name = "ReportNo";
            ReportNo.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            InvoiceNo.DataPropertyName = "INV_NO";
            InvoiceNo.HeaderText = "發票";
            InvoiceNo.Name = "InvoiceNo";
            InvoiceNo.ReadOnly = true;
            // 
            // InvoiceDate
            // 
            InvoiceDate.DataPropertyName = "INV_DT";
            InvoiceDate.HeaderText = "發票日期";
            InvoiceDate.Name = "InvoiceDate";
            InvoiceDate.ReadOnly = true;
            // 
            // Currency
            // 
            Currency.DataPropertyName = "CURR";
            Currency.HeaderText = "幣別";
            Currency.Name = "Currency";
            Currency.ReadOnly = true;
            // 
            // InvoiceAmount
            // 
            InvoiceAmount.DataPropertyName = "INV_AMT_DISP";
            InvoiceAmount.HeaderText = "發票金額";
            InvoiceAmount.Name = "InvoiceAmount";
            InvoiceAmount.ReadOnly = true;
            // 
            // AcountBalance
            // 
            AcountBalance.DataPropertyName = "ACT_BALANCE_DISP";
            AcountBalance.HeaderText = "帳上餘額";
            AcountBalance.Name = "AcountBalance";
            AcountBalance.ReadOnly = true;
            // 
            // CreateUser
            // 
            CreateUser.DataPropertyName = "CRT_USER";
            CreateUser.HeaderText = "建檔人";
            CreateUser.Name = "CreateUser";
            CreateUser.ReadOnly = true;
            // 
            // CreateDate
            // 
            CreateDate.DataPropertyName = "CRT_DATE";
            CreateDate.HeaderText = "建檔時間";
            CreateDate.Name = "CreateDate";
            CreateDate.ReadOnly = true;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.Tomato;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.Transparent;
            btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            btnSearch.IconColor = Color.White;
            btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSearch.IconSize = 20;
            btnSearch.ImageAlign = ContentAlignment.BottomLeft;
            btnSearch.Location = new Point(935, 12);
            btnSearch.Margin = new Padding(0, 3, 3, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(3, 0, 0, 0);
            btnSearch.Size = new Size(67, 28);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "搜尋";
            btnSearch.TextAlign = ContentAlignment.MiddleRight;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnNTF
            // 
            btnNTF.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNTF.BackColor = Color.Tomato;
            btnNTF.FlatAppearance.BorderSize = 0;
            btnNTF.FlatStyle = FlatStyle.Flat;
            btnNTF.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNTF.ForeColor = Color.Transparent;
            btnNTF.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            btnNTF.IconColor = Color.White;
            btnNTF.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNTF.IconSize = 28;
            btnNTF.ImageAlign = ContentAlignment.BottomLeft;
            btnNTF.Location = new Point(676, 642);
            btnNTF.Name = "btnNTF";
            btnNTF.Padding = new Padding(3, 0, 0, 0);
            btnNTF.Size = new Size(100, 40);
            btnNTF.TabIndex = 13;
            btnNTF.Text = "通知函";
            btnNTF.TextAlign = ContentAlignment.MiddleRight;
            btnNTF.UseVisualStyleBackColor = false;
            btnNTF.Click += btnNTF_Click;
            // 
            // btnDUN
            // 
            btnDUN.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDUN.BackColor = Color.Tomato;
            btnDUN.FlatAppearance.BorderSize = 0;
            btnDUN.FlatStyle = FlatStyle.Flat;
            btnDUN.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDUN.ForeColor = Color.Transparent;
            btnDUN.IconChar = FontAwesome.Sharp.IconChar.Warning;
            btnDUN.IconColor = Color.White;
            btnDUN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDUN.IconSize = 28;
            btnDUN.ImageAlign = ContentAlignment.BottomLeft;
            btnDUN.Location = new Point(784, 642);
            btnDUN.Name = "btnDUN";
            btnDUN.Padding = new Padding(3, 0, 0, 0);
            btnDUN.Size = new Size(100, 40);
            btnDUN.TabIndex = 14;
            btnDUN.Text = "催收函";
            btnDUN.TextAlign = ContentAlignment.MiddleRight;
            btnDUN.UseVisualStyleBackColor = false;
            btnDUN.Click += btnDUN_Click;
            // 
            // btnDPS
            // 
            btnDPS.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDPS.BackColor = Color.Tomato;
            btnDPS.FlatAppearance.BorderSize = 0;
            btnDPS.FlatStyle = FlatStyle.Flat;
            btnDPS.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDPS.ForeColor = Color.Transparent;
            btnDPS.IconChar = FontAwesome.Sharp.IconChar.Legal;
            btnDPS.IconColor = Color.White;
            btnDPS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDPS.IconSize = 28;
            btnDPS.ImageAlign = ContentAlignment.BottomLeft;
            btnDPS.Location = new Point(892, 642);
            btnDPS.Name = "btnDPS";
            btnDPS.Padding = new Padding(3, 0, 0, 0);
            btnDPS.Size = new Size(110, 40);
            btnDPS.TabIndex = 15;
            btnDPS.Text = "存證信函";
            btnDPS.TextAlign = ContentAlignment.MiddleRight;
            btnDPS.UseVisualStyleBackColor = false;
            btnDPS.Click += btnDPS_Click;
            // 
            // cbbCompany
            // 
            cbbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCompany.FormattingEnabled = true;
            cbbCompany.Location = new Point(12, 12);
            cbbCompany.Margin = new Padding(3, 3, 0, 3);
            cbbCompany.Name = "cbbCompany";
            cbbCompany.Size = new Size(183, 28);
            cbbCompany.TabIndex = 2;
            cbbCompany.SelectedIndexChanged += cbbCompany_SelectedIndexChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(198, 12);
            dtpStartDate.Margin = new Padding(3, 3, 0, 3);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(130, 28);
            dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(328, 12);
            dtpEndDate.Margin = new Padding(0, 3, 3, 3);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(130, 28);
            dtpEndDate.TabIndex = 4;
            // 
            // btnAbnormal
            // 
            btnAbnormal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAbnormal.BackColor = Color.Gray;
            btnAbnormal.FlatAppearance.BorderSize = 0;
            btnAbnormal.FlatStyle = FlatStyle.Flat;
            btnAbnormal.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAbnormal.ForeColor = Color.Transparent;
            btnAbnormal.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
            btnAbnormal.IconColor = Color.White;
            btnAbnormal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAbnormal.IconSize = 28;
            btnAbnormal.ImageAlign = ContentAlignment.BottomLeft;
            btnAbnormal.Location = new Point(12, 642);
            btnAbnormal.Name = "btnAbnormal";
            btnAbnormal.Padding = new Padding(3, 0, 0, 0);
            btnAbnormal.Size = new Size(114, 40);
            btnAbnormal.TabIndex = 16;
            btnAbnormal.Text = "異常資料";
            btnAbnormal.TextAlign = ContentAlignment.MiddleRight;
            btnAbnormal.UseVisualStyleBackColor = false;
            btnAbnormal.Click += btnAbnormal_Click;
            // 
            // chkOnlyTWD
            // 
            chkOnlyTWD.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkOnlyTWD.AutoSize = true;
            chkOnlyTWD.Checked = true;
            chkOnlyTWD.CheckState = CheckState.Checked;
            chkOnlyTWD.Location = new Point(132, 658);
            chkOnlyTWD.Name = "chkOnlyTWD";
            chkOnlyTWD.Size = new Size(92, 24);
            chkOnlyTWD.TabIndex = 17;
            chkOnlyTWD.Text = "僅限台幣";
            chkOnlyTWD.UseVisualStyleBackColor = true;
            // 
            // frmDunningLetter
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 694);
            Controls.Add(chkOnlyTWD);
            Controls.Add(btnAbnormal);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(cbbCompany);
            Controls.Add(btnDPS);
            Controls.Add(btnDUN);
            Controls.Add(btnNTF);
            Controls.Add(btnSearch);
            Controls.Add(dgvBossDaily);
            Controls.Add(txtKeyword);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmDunningLetter";
            Text = "frmDunningLetter";
            Load += frmDunningLetter_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBossDaily).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKeyword;
        private DataGridView dgvBossDaily;
        private FontAwesome.Sharp.IconButton btnSearch;
        private FontAwesome.Sharp.IconButton btnNTF;
        private FontAwesome.Sharp.IconButton btnDUN;
        private FontAwesome.Sharp.IconButton btnDPS;
        private ComboBox cbbCompany;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private FontAwesome.Sharp.IconButton btnAbnormal;
        private CheckBox chkOnlyTWD;
        private DataGridViewTextBoxColumn BD_ID;
        private DataGridViewTextBoxColumn Company;
        private DataGridViewTextBoxColumn BossNo;
        private DataGridViewTextBoxColumn CustmerNo;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn BillNo;
        private DataGridViewTextBoxColumn ReportNo;
        private DataGridViewTextBoxColumn InvoiceNo;
        private DataGridViewTextBoxColumn InvoiceDate;
        private DataGridViewTextBoxColumn Currency;
        private DataGridViewTextBoxColumn InvoiceAmount;
        private DataGridViewTextBoxColumn AcountBalance;
        private DataGridViewTextBoxColumn CreateUser;
        private DataGridViewTextBoxColumn CreateDate;
    }
}