namespace SGS.LEGAL.DLS
{
    partial class frmInfoDUN
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
            txtBOSS_NO = new TextBox();
            txtCST_NO = new TextBox();
            txtCST_ADDR = new TextBox();
            txtCST_DEPT = new TextBox();
            txtCST_NM = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            chkIsEnvelope = new CheckBox();
            chkIsReceipt = new CheckBox();
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
            btnSave.Location = new Point(572, 330);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(3, 0, 0, 0);
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 29;
            btnSave.Text = "儲存";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtBOSS_NO
            // 
            txtBOSS_NO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBOSS_NO.Location = new Point(442, 114);
            txtBOSS_NO.Name = "txtBOSS_NO";
            txtBOSS_NO.PlaceholderText = "(Boss No)";
            txtBOSS_NO.Size = new Size(230, 28);
            txtBOSS_NO.TabIndex = 26;
            // 
            // txtCST_NO
            // 
            txtCST_NO.Location = new Point(91, 114);
            txtCST_NO.Name = "txtCST_NO";
            txtCST_NO.Size = new Size(230, 28);
            txtCST_NO.TabIndex = 25;
            // 
            // txtCST_ADDR
            // 
            txtCST_ADDR.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCST_ADDR.Location = new Point(91, 80);
            txtCST_ADDR.Name = "txtCST_ADDR";
            txtCST_ADDR.Size = new Size(581, 28);
            txtCST_ADDR.TabIndex = 24;
            // 
            // txtCST_DEPT
            // 
            txtCST_DEPT.Location = new Point(91, 46);
            txtCST_DEPT.Name = "txtCST_DEPT";
            txtCST_DEPT.Size = new Size(230, 28);
            txtCST_DEPT.TabIndex = 23;
            // 
            // txtCST_NM
            // 
            txtCST_NM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCST_NM.Location = new Point(91, 12);
            txtCST_NM.Name = "txtCST_NM";
            txtCST_NM.Size = new Size(581, 28);
            txtCST_NM.TabIndex = 22;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(363, 117);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 19;
            label5.Text = "客戶編號";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 117);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 18;
            label4.Text = "統一編號";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 83);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 17;
            label3.Text = "客戶地址";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 16;
            label2.Text = "客戶部門";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 15;
            label1.Text = "客戶名稱";
            // 
            // chkIsEnvelope
            // 
            chkIsEnvelope.AutoSize = true;
            chkIsEnvelope.Checked = true;
            chkIsEnvelope.CheckState = CheckState.Checked;
            chkIsEnvelope.Location = new Point(91, 238);
            chkIsEnvelope.Name = "chkIsEnvelope";
            chkIsEnvelope.Size = new Size(92, 24);
            chkIsEnvelope.TabIndex = 30;
            chkIsEnvelope.Text = "包含信封";
            chkIsEnvelope.UseVisualStyleBackColor = true;
            // 
            // chkIsReceipt
            // 
            chkIsReceipt.AutoSize = true;
            chkIsReceipt.Checked = true;
            chkIsReceipt.CheckState = CheckState.Checked;
            chkIsReceipt.Location = new Point(189, 238);
            chkIsReceipt.Name = "chkIsReceipt";
            chkIsReceipt.Size = new Size(92, 24);
            chkIsReceipt.TabIndex = 31;
            chkIsReceipt.Text = "收件回執";
            chkIsReceipt.UseVisualStyleBackColor = true;
            // 
            // frmInfoDUN
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 382);
            Controls.Add(chkIsReceipt);
            Controls.Add(chkIsEnvelope);
            Controls.Add(btnSave);
            Controls.Add(txtBOSS_NO);
            Controls.Add(txtCST_NO);
            Controls.Add(txtCST_ADDR);
            Controls.Add(txtCST_DEPT);
            Controls.Add(txtCST_NM);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MinimumSize = new Size(700, 320);
            Name = "frmInfoDUN";
            StartPosition = FormStartPosition.CenterParent;
            Text = "資料設定(催款函)";
            TopMost = true;
            Load += frmInfoDUN_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnSave;
        private TextBox txtBOSS_NO;
        private TextBox txtCST_NO;
        private TextBox txtCST_ADDR;
        private TextBox txtCST_DEPT;
        private TextBox txtCST_NM;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox chkIsEnvelope;
        private CheckBox chkIsReceipt;
    }
}