namespace SGS.LEGAL.DLS
{
    partial class frmInfoDPS
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
            btnSave = new FontAwesome.Sharp.IconButton();
            groupBox2 = new GroupBox();
            txtSenderCEO = new TextBox();
            label10 = new Label();
            ccbCompany = new ComboBox();
            label4 = new Label();
            txtSenderAddress = new TextBox();
            txtSenderName = new TextBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            txtReceiverCEO = new TextBox();
            label2 = new Label();
            txtReceiverAddress = new TextBox();
            txtReceiverName = new TextBox();
            label3 = new Label();
            groupBox4 = new GroupBox();
            label5 = new Label();
            txtCcAddress = new TextBox();
            txtCcName = new TextBox();
            label6 = new Label();
            txtCcPostCode = new TextBox();
            txtReceiverPostCode = new TextBox();
            txtSenderPostCode = new TextBox();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.Tomato;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.Transparent;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnSave.IconColor = Color.White;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 28;
            btnSave.ImageAlign = ContentAlignment.BottomLeft;
            btnSave.Location = new Point(472, 419);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(3, 0, 0, 0);
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 15;
            btnSave.Text = "預覽";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtSenderPostCode);
            groupBox2.Controls.Add(txtSenderCEO);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(ccbCompany);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtSenderAddress);
            groupBox2.Controls.Add(txtSenderName);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10);
            groupBox2.Size = new Size(560, 145);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "寄件人";
            // 
            // txtSenderCEO
            // 
            txtSenderCEO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSenderCEO.Location = new Point(444, 68);
            txtSenderCEO.Name = "txtSenderCEO";
            txtSenderCEO.PlaceholderText = "(公司負責人)";
            txtSenderCEO.ReadOnly = true;
            txtSenderCEO.Size = new Size(103, 28);
            txtSenderCEO.TabIndex = 19;
            txtSenderCEO.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 37);
            label10.Name = "label10";
            label10.Size = new Size(41, 20);
            label10.TabIndex = 20;
            label10.Text = "選取";
            // 
            // ccbCompany
            // 
            ccbCompany.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ccbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            ccbCompany.FormattingEnabled = true;
            ccbCompany.Location = new Point(60, 34);
            ccbCompany.Name = "ccbCompany";
            ccbCompany.Size = new Size(487, 28);
            ccbCompany.TabIndex = 3;
            ccbCompany.SelectedIndexChanged += ccbCompany_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 105);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 18;
            label4.Text = "地址";
            // 
            // txtSenderAddress
            // 
            txtSenderAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSenderAddress.Location = new Point(152, 102);
            txtSenderAddress.Name = "txtSenderAddress";
            txtSenderAddress.ReadOnly = true;
            txtSenderAddress.Size = new Size(395, 28);
            txtSenderAddress.TabIndex = 18;
            // 
            // txtSenderName
            // 
            txtSenderName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSenderName.Location = new Point(60, 68);
            txtSenderName.Name = "txtSenderName";
            txtSenderName.ReadOnly = true;
            txtSenderName.Size = new Size(378, 28);
            txtSenderName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 71);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 17;
            label1.Text = "名稱";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(txtReceiverPostCode);
            groupBox3.Controls.Add(txtReceiverCEO);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtReceiverAddress);
            groupBox3.Controls.Add(txtReceiverName);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(12, 163);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(10);
            groupBox3.Size = new Size(560, 120);
            groupBox3.TabIndex = 21;
            groupBox3.TabStop = false;
            groupBox3.Text = "收件人";
            // 
            // txtReceiverCEO
            // 
            txtReceiverCEO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtReceiverCEO.Location = new Point(444, 34);
            txtReceiverCEO.Name = "txtReceiverCEO";
            txtReceiverCEO.PlaceholderText = "公司代表人";
            txtReceiverCEO.Size = new Size(103, 28);
            txtReceiverCEO.TabIndex = 1;
            txtReceiverCEO.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 71);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 18;
            label2.Text = "地址";
            // 
            // txtReceiverAddress
            // 
            txtReceiverAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReceiverAddress.Location = new Point(152, 68);
            txtReceiverAddress.Name = "txtReceiverAddress";
            txtReceiverAddress.PlaceholderText = "收件人地址";
            txtReceiverAddress.Size = new Size(395, 28);
            txtReceiverAddress.TabIndex = 3;
            // 
            // txtReceiverName
            // 
            txtReceiverName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReceiverName.Location = new Point(60, 34);
            txtReceiverName.Name = "txtReceiverName";
            txtReceiverName.ReadOnly = true;
            txtReceiverName.Size = new Size(378, 28);
            txtReceiverName.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 37);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 17;
            label3.Text = "名稱";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(txtCcPostCode);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(txtCcAddress);
            groupBox4.Controls.Add(txtCcName);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(12, 289);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(10);
            groupBox4.Size = new Size(560, 120);
            groupBox4.TabIndex = 22;
            groupBox4.TabStop = false;
            groupBox4.Text = "副本";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 71);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 18;
            label5.Text = "地址";
            // 
            // txtCcAddress
            // 
            txtCcAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCcAddress.Location = new Point(152, 68);
            txtCcAddress.Name = "txtCcAddress";
            txtCcAddress.PlaceholderText = "副本收件地址";
            txtCcAddress.Size = new Size(395, 28);
            txtCcAddress.TabIndex = 6;
            // 
            // txtCcName
            // 
            txtCcName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCcName.Location = new Point(60, 34);
            txtCcName.Name = "txtCcName";
            txtCcName.PlaceholderText = "副本收件人";
            txtCcName.Size = new Size(487, 28);
            txtCcName.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 37);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 17;
            label6.Text = "姓名";
            // 
            // txtCcPostCode
            // 
            txtCcPostCode.Location = new Point(60, 68);
            txtCcPostCode.Name = "txtCcPostCode";
            txtCcPostCode.PlaceholderText = "郵遞區號";
            txtCcPostCode.Size = new Size(86, 28);
            txtCcPostCode.TabIndex = 5;
            txtCcPostCode.TextAlign = HorizontalAlignment.Center;
            // 
            // txtReceiverPostCode
            // 
            txtReceiverPostCode.Location = new Point(60, 68);
            txtReceiverPostCode.Name = "txtReceiverPostCode";
            txtReceiverPostCode.PlaceholderText = "郵遞區號";
            txtReceiverPostCode.Size = new Size(86, 28);
            txtReceiverPostCode.TabIndex = 2;
            txtReceiverPostCode.TextAlign = HorizontalAlignment.Center;
            // 
            // txtSenderPostCode
            // 
            txtSenderPostCode.Location = new Point(60, 102);
            txtSenderPostCode.Name = "txtSenderPostCode";
            txtSenderPostCode.PlaceholderText = "郵遞區號";
            txtSenderPostCode.ReadOnly = true;
            txtSenderPostCode.Size = new Size(86, 28);
            txtSenderPostCode.TabIndex = 21;
            txtSenderPostCode.TextAlign = HorizontalAlignment.Center;
            // 
            // frmInfoDPS
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 471);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btnSave);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MinimumSize = new Size(600, 510);
            Name = "frmInfoDPS";
            StartPosition = FormStartPosition.CenterParent;
            Text = "資料設定";
            Load += frmInfoDPS_Load;
            Shown += frmInfoDPS_Shown;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnSave;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox txtSenderAddress;
        private TextBox txtSenderName;
        private Label label1;
        private GroupBox groupBox3;
        private Label label2;
        private TextBox txtReceiverAddress;
        private TextBox txtReceiverName;
        private Label label3;
        private GroupBox groupBox4;
        private Label label5;
        private TextBox txtCcAddress;
        private TextBox txtCcName;
        private Label label6;
        private ComboBox ccbCompany;
        private Label label10;
        private TextBox txtReceiverCEO;
        private TextBox txtSenderCEO;
        private TextBox txtSenderPostCode;
        private TextBox txtReceiverPostCode;
        private TextBox txtCcPostCode;
    }
}