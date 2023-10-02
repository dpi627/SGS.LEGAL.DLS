namespace SGS.LEGAL.DLS
{
    partial class frmDataImport
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
            btnDataImport = new FontAwesome.Sharp.IconButton();
            dataGridView1 = new DataGridView();
            DiID = new DataGridViewTextBoxColumn();
            ProcessStart = new DataGridViewTextBoxColumn();
            ProcessEnd = new DataGridViewTextBoxColumn();
            DataImportStatus = new DataGridViewTextBoxColumn();
            IsManual = new DataGridViewCheckBoxColumn();
            CreateUser = new DataGridViewTextBoxColumn();
            CreateDate = new DataGridViewTextBoxColumn();
            ModifyUser = new DataGridViewTextBoxColumn();
            ModifyDate = new DataGridViewTextBoxColumn();
            FinishReason = new DataGridViewTextBoxColumn();
            cbbCompany = new ComboBox();
            btnReload = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDataImport
            // 
            btnDataImport.BackColor = Color.Tomato;
            btnDataImport.FlatAppearance.BorderSize = 0;
            btnDataImport.FlatStyle = FlatStyle.Flat;
            btnDataImport.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDataImport.ForeColor = Color.Transparent;
            btnDataImport.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            btnDataImport.IconColor = Color.White;
            btnDataImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDataImport.IconSize = 20;
            btnDataImport.ImageAlign = ContentAlignment.BottomLeft;
            btnDataImport.Location = new Point(199, 12);
            btnDataImport.Margin = new Padding(4);
            btnDataImport.Name = "btnDataImport";
            btnDataImport.Size = new Size(91, 28);
            btnDataImport.TabIndex = 11;
            btnDataImport.Text = "手動匯入";
            btnDataImport.TextAlign = ContentAlignment.MiddleRight;
            btnDataImport.UseVisualStyleBackColor = false;
            btnDataImport.Click += btnDataImport_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { DiID, ProcessStart, ProcessEnd, DataImportStatus, IsManual, CreateUser, CreateDate, ModifyUser, ModifyDate, FinishReason });
            dataGridView1.Location = new Point(12, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 30;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1010, 427);
            dataGridView1.TabIndex = 12;
            // 
            // DiID
            // 
            DiID.DataPropertyName = "DI_ID";
            DiID.HeaderText = "轉檔ID";
            DiID.Name = "DiID";
            DiID.ReadOnly = true;
            // 
            // ProcessStart
            // 
            ProcessStart.DataPropertyName = "PROCESS_START";
            ProcessStart.HeaderText = "起";
            ProcessStart.Name = "ProcessStart";
            ProcessStart.ReadOnly = true;
            // 
            // ProcessEnd
            // 
            ProcessEnd.DataPropertyName = "PROCESS_END";
            ProcessEnd.HeaderText = "訖";
            ProcessEnd.Name = "ProcessEnd";
            ProcessEnd.ReadOnly = true;
            // 
            // DataImportStatus
            // 
            DataImportStatus.DataPropertyName = "DI_STA_NM";
            DataImportStatus.HeaderText = "狀態";
            DataImportStatus.Name = "DataImportStatus";
            DataImportStatus.ReadOnly = true;
            // 
            // IsManual
            // 
            IsManual.DataPropertyName = "IS_MANUAL";
            IsManual.HeaderText = "手動轉檔";
            IsManual.Name = "IsManual";
            IsManual.ReadOnly = true;
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
            // ModifyUser
            // 
            ModifyUser.DataPropertyName = "MDF_USER";
            ModifyUser.HeaderText = "修改人";
            ModifyUser.Name = "ModifyUser";
            ModifyUser.ReadOnly = true;
            // 
            // ModifyDate
            // 
            ModifyDate.DataPropertyName = "MDF_DATE";
            ModifyDate.HeaderText = "修改時間";
            ModifyDate.Name = "ModifyDate";
            ModifyDate.ReadOnly = true;
            // 
            // FinishReason
            // 
            FinishReason.DataPropertyName = "FINISH_REASON";
            FinishReason.HeaderText = "備註";
            FinishReason.Name = "FinishReason";
            FinishReason.ReadOnly = true;
            // 
            // cbbCompany
            // 
            cbbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCompany.FormattingEnabled = true;
            cbbCompany.Location = new Point(12, 12);
            cbbCompany.Margin = new Padding(3, 3, 0, 3);
            cbbCompany.Name = "cbbCompany";
            cbbCompany.Size = new Size(183, 28);
            cbbCompany.TabIndex = 13;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReload.BackColor = Color.Tomato;
            btnReload.FlatAppearance.BorderSize = 0;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnReload.ForeColor = Color.Transparent;
            btnReload.IconChar = FontAwesome.Sharp.IconChar.Rotate;
            btnReload.IconColor = Color.White;
            btnReload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReload.IconSize = 20;
            btnReload.ImageAlign = ContentAlignment.BottomLeft;
            btnReload.Location = new Point(931, 13);
            btnReload.Margin = new Padding(4);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(91, 28);
            btnReload.TabIndex = 14;
            btnReload.Text = "重新整理";
            btnReload.TextAlign = ContentAlignment.MiddleRight;
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;
            // 
            // frmDataImport
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 486);
            Controls.Add(btnReload);
            Controls.Add(cbbCompany);
            Controls.Add(dataGridView1);
            Controls.Add(btnDataImport);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmDataImport";
            Text = "frmDataImport";
            Load += frmDataImport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnDataImport;
        private DataGridView dataGridView1;
        private ComboBox cbbCompany;
        private DataGridViewTextBoxColumn DiID;
        private DataGridViewTextBoxColumn ProcessStart;
        private DataGridViewTextBoxColumn ProcessEnd;
        private DataGridViewTextBoxColumn DataImportStatus;
        private DataGridViewCheckBoxColumn IsManual;
        private DataGridViewTextBoxColumn CreateUser;
        private DataGridViewTextBoxColumn CreateDate;
        private DataGridViewTextBoxColumn ModifyUser;
        private DataGridViewTextBoxColumn ModifyDate;
        private DataGridViewTextBoxColumn FinishReason;
        private FontAwesome.Sharp.IconButton btnReload;
    }
}