namespace SGS.LEGAL.DLS
{
    partial class frmDocLog
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
            dgvDocLog = new DataGridView();
            View = new DataGridViewButtonColumn();
            CompanyName = new DataGridViewTextBoxColumn();
            BossNo = new DataGridViewTextBoxColumn();
            CustomerNo = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            FileTypeName = new DataGridViewTextBoxColumn();
            LetterTypeName = new DataGridViewTextBoxColumn();
            EmployeeId = new DataGridViewTextBoxColumn();
            CreateUser = new DataGridViewTextBoxColumn();
            CreateTime = new DataGridViewTextBoxColumn();
            BackupPath = new DataGridViewTextBoxColumn();
            LetterType = new DataGridViewTextBoxColumn();
            FileType = new DataGridViewTextBoxColumn();
            btnSearch = new FontAwesome.Sharp.IconButton();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            cbbCompany = new ComboBox();
            txtKeyword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDocLog).BeginInit();
            SuspendLayout();
            // 
            // dgvDocLog
            // 
            dgvDocLog.AllowUserToAddRows = false;
            dgvDocLog.AllowUserToDeleteRows = false;
            dgvDocLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDocLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDocLog.Columns.AddRange(new DataGridViewColumn[] { View, CompanyName, BossNo, CustomerNo, CustomerName, FileTypeName, LetterTypeName, EmployeeId, CreateUser, CreateTime, BackupPath, LetterType, FileType });
            dgvDocLog.Location = new Point(12, 53);
            dgvDocLog.Name = "dgvDocLog";
            dgvDocLog.ReadOnly = true;
            dgvDocLog.RowTemplate.Height = 25;
            dgvDocLog.Size = new Size(893, 507);
            dgvDocLog.TabIndex = 0;
            dgvDocLog.CellContentClick += dgvDocLog_CellContentClick;
            // 
            // View
            // 
            View.HeaderText = "";
            View.Name = "View";
            View.ReadOnly = true;
            View.Text = "檢視";
            View.UseColumnTextForButtonValue = true;
            // 
            // CompanyName
            // 
            CompanyName.DataPropertyName = "COMPANY_NM";
            CompanyName.HeaderText = "公司";
            CompanyName.Name = "CompanyName";
            CompanyName.ReadOnly = true;
            // 
            // BossNo
            // 
            BossNo.DataPropertyName = "BOSS_NO";
            BossNo.HeaderText = "BOSS No.";
            BossNo.Name = "BossNo";
            BossNo.ReadOnly = true;
            // 
            // CustomerNo
            // 
            CustomerNo.DataPropertyName = "CST_NO";
            CustomerNo.HeaderText = "統編";
            CustomerNo.Name = "CustomerNo";
            CustomerNo.ReadOnly = true;
            // 
            // CustomerName
            // 
            CustomerName.DataPropertyName = "CST_NM";
            CustomerName.HeaderText = "客戶名稱";
            CustomerName.Name = "CustomerName";
            CustomerName.ReadOnly = true;
            // 
            // FileTypeName
            // 
            FileTypeName.DataPropertyName = "FIL_TYP_NM";
            FileTypeName.HeaderText = "檔案類型";
            FileTypeName.Name = "FileTypeName";
            FileTypeName.ReadOnly = true;
            // 
            // LetterTypeName
            // 
            LetterTypeName.DataPropertyName = "LET_TYP_NM";
            LetterTypeName.HeaderText = "信函類型";
            LetterTypeName.Name = "LetterTypeName";
            LetterTypeName.ReadOnly = true;
            // 
            // EmployeeId
            // 
            EmployeeId.DataPropertyName = "EMP_ID";
            EmployeeId.HeaderText = "員工編號";
            EmployeeId.Name = "EmployeeId";
            EmployeeId.ReadOnly = true;
            // 
            // CreateUser
            // 
            CreateUser.DataPropertyName = "USER_NM";
            CreateUser.HeaderText = "建檔人";
            CreateUser.Name = "CreateUser";
            CreateUser.ReadOnly = true;
            // 
            // CreateTime
            // 
            CreateTime.DataPropertyName = "TIME_STAMP";
            CreateTime.HeaderText = "建檔時間";
            CreateTime.Name = "CreateTime";
            CreateTime.ReadOnly = true;
            // 
            // BackupPath
            // 
            BackupPath.DataPropertyName = "BAK_PATH";
            BackupPath.HeaderText = "備份路徑";
            BackupPath.Name = "BackupPath";
            BackupPath.ReadOnly = true;
            BackupPath.Visible = false;
            // 
            // LetterType
            // 
            LetterType.DataPropertyName = "LET_TYP";
            LetterType.HeaderText = "Letter Type";
            LetterType.Name = "LetterType";
            LetterType.ReadOnly = true;
            LetterType.Visible = false;
            // 
            // FileType
            // 
            FileType.DataPropertyName = "FIL_TYP";
            FileType.HeaderText = "File Type";
            FileType.Name = "FileType";
            FileType.ReadOnly = true;
            FileType.Visible = false;
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
            btnSearch.Location = new Point(840, 12);
            btnSearch.Margin = new Padding(0, 3, 3, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(3, 0, 0, 0);
            btnSearch.Size = new Size(65, 28);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "搜尋";
            btnSearch.TextAlign = ContentAlignment.MiddleRight;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(328, 12);
            dtpEndDate.Margin = new Padding(0, 3, 3, 3);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(130, 28);
            dtpEndDate.TabIndex = 6;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(198, 12);
            dtpStartDate.Margin = new Padding(3, 3, 0, 3);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(130, 28);
            dtpStartDate.TabIndex = 5;
            // 
            // cbbCompany
            // 
            cbbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCompany.FormattingEnabled = true;
            cbbCompany.Location = new Point(12, 13);
            cbbCompany.Margin = new Padding(3, 3, 0, 3);
            cbbCompany.Name = "cbbCompany";
            cbbCompany.Size = new Size(183, 28);
            cbbCompany.TabIndex = 7;
            // 
            // txtKeyword
            // 
            txtKeyword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyword.Location = new Point(461, 12);
            txtKeyword.Margin = new Padding(0, 3, 0, 3);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Boss、統編或客戶名稱";
            txtKeyword.Size = new Size(379, 28);
            txtKeyword.TabIndex = 8;
            // 
            // frmDocLog
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 572);
            Controls.Add(txtKeyword);
            Controls.Add(cbbCompany);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(btnSearch);
            Controls.Add(dgvDocLog);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmDocLog";
            Text = "frmDocLog";
            Load += frmDocLog_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDocLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDocLog;
        private FontAwesome.Sharp.IconButton btnSearch;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private DataGridViewButtonColumn View;
        private DataGridViewTextBoxColumn CompanyName;
        private DataGridViewTextBoxColumn BossNo;
        private DataGridViewTextBoxColumn CustomerNo;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn FileTypeName;
        private DataGridViewTextBoxColumn LetterTypeName;
        private DataGridViewTextBoxColumn EmployeeId;
        private DataGridViewTextBoxColumn CreateUser;
        private DataGridViewTextBoxColumn CreateTime;
        private DataGridViewTextBoxColumn BackupPath;
        private DataGridViewTextBoxColumn LetterType;
        private DataGridViewTextBoxColumn FileType;
        private ComboBox cbbCompany;
        private TextBox txtKeyword;
    }
}