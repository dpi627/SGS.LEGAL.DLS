namespace SGS.LEGAL.DLS
{
    partial class frmOptLog
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
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            btnSearch = new FontAwesome.Sharp.IconButton();
            dgvOptLog = new DataGridView();
            Action = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            EmpId = new DataGridViewTextBoxColumn();
            UserName = new DataGridViewTextBoxColumn();
            LogTime = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvOptLog).BeginInit();
            SuspendLayout();
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(142, 12);
            dtpEndDate.Margin = new Padding(0, 3, 3, 3);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(130, 28);
            dtpEndDate.TabIndex = 10;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(12, 12);
            dtpStartDate.Margin = new Padding(3, 3, 0, 3);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(130, 28);
            dtpStartDate.TabIndex = 9;
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
            btnSearch.TabIndex = 8;
            btnSearch.Text = "搜尋";
            btnSearch.TextAlign = ContentAlignment.MiddleRight;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvOptLog
            // 
            dgvOptLog.AllowUserToAddRows = false;
            dgvOptLog.AllowUserToDeleteRows = false;
            dgvOptLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOptLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOptLog.Columns.AddRange(new DataGridViewColumn[] { Action, Message, EmpId, UserName, LogTime });
            dgvOptLog.Location = new Point(12, 46);
            dgvOptLog.Name = "dgvOptLog";
            dgvOptLog.ReadOnly = true;
            dgvOptLog.RowTemplate.Height = 25;
            dgvOptLog.Size = new Size(893, 514);
            dgvOptLog.TabIndex = 7;
            // 
            // Action
            // 
            Action.DataPropertyName = "ACT_ID";
            Action.HeaderText = "操作";
            Action.Name = "Action";
            Action.ReadOnly = true;
            // 
            // Message
            // 
            Message.DataPropertyName = "MSG";
            Message.HeaderText = "訊息";
            Message.Name = "Message";
            Message.ReadOnly = true;
            // 
            // EmpId
            // 
            EmpId.DataPropertyName = "CRT_USER";
            EmpId.HeaderText = "工號";
            EmpId.Name = "EmpId";
            EmpId.ReadOnly = true;
            // 
            // UserName
            // 
            UserName.DataPropertyName = "USER_NM";
            UserName.HeaderText = "姓名";
            UserName.Name = "UserName";
            UserName.ReadOnly = true;
            // 
            // LogTime
            // 
            LogTime.DataPropertyName = "CRT_DATE";
            LogTime.HeaderText = "時間";
            LogTime.Name = "LogTime";
            LogTime.ReadOnly = true;
            // 
            // frmOptLog
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 572);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(btnSearch);
            Controls.Add(dgvOptLog);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmOptLog";
            Text = "frmOptLog";
            ((System.ComponentModel.ISupportInitialize)dgvOptLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private FontAwesome.Sharp.IconButton btnSearch;
        private DataGridView dgvOptLog;
        private DataGridViewTextBoxColumn Action;
        private DataGridViewTextBoxColumn Message;
        private DataGridViewTextBoxColumn EmpId;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn LogTime;
    }
}