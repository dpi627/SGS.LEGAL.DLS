namespace SGS.LEGAL.DLS
{
    partial class frmInfoNTF
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtCST_NM = new TextBox();
            txtCST_DEPT = new TextBox();
            txtCST_ADDR = new TextBox();
            txtCST_NO = new TextBox();
            txtBOSS_NO = new TextBox();
            btnSave = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            txtCST_POST_CODE = new TextBox();
            flowPanel = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            labNotice = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 27);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "客戶名稱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 61);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "客戶部門";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 95);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "客戶地址";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 129);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 3;
            label4.Text = "統一編號";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(338, 129);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 4;
            label5.Text = "客戶編號";
            // 
            // txtCST_NM
            // 
            txtCST_NM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCST_NM.Location = new Point(92, 24);
            txtCST_NM.Name = "txtCST_NM";
            txtCST_NM.ReadOnly = true;
            txtCST_NM.Size = new Size(485, 28);
            txtCST_NM.TabIndex = 7;
            // 
            // txtCST_DEPT
            // 
            txtCST_DEPT.Location = new Point(92, 58);
            txtCST_DEPT.Name = "txtCST_DEPT";
            txtCST_DEPT.PlaceholderText = "客戶部門";
            txtCST_DEPT.ReadOnly = true;
            txtCST_DEPT.Size = new Size(160, 28);
            txtCST_DEPT.TabIndex = 1;
            // 
            // txtCST_ADDR
            // 
            txtCST_ADDR.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCST_ADDR.Location = new Point(184, 92);
            txtCST_ADDR.Name = "txtCST_ADDR";
            txtCST_ADDR.PlaceholderText = "客戶地址";
            txtCST_ADDR.Size = new Size(393, 28);
            txtCST_ADDR.TabIndex = 3;
            // 
            // txtCST_NO
            // 
            txtCST_NO.Location = new Point(92, 126);
            txtCST_NO.Name = "txtCST_NO";
            txtCST_NO.ReadOnly = true;
            txtCST_NO.Size = new Size(160, 28);
            txtCST_NO.TabIndex = 10;
            // 
            // txtBOSS_NO
            // 
            txtBOSS_NO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBOSS_NO.Location = new Point(417, 126);
            txtBOSS_NO.Name = "txtBOSS_NO";
            txtBOSS_NO.PlaceholderText = "(Boss No)";
            txtBOSS_NO.ReadOnly = true;
            txtBOSS_NO.Size = new Size(160, 28);
            txtBOSS_NO.TabIndex = 11;
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
            btnSave.Location = new Point(502, 379);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(3, 0, 0, 0);
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 14;
            btnSave.Text = "預覽";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtCST_POST_CODE);
            groupBox1.Controls.Add(txtCST_NM);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBOSS_NO);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCST_NO);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCST_ADDR);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtCST_DEPT);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(590, 174);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "客戶資料";
            // 
            // txtCST_POST_CODE
            // 
            txtCST_POST_CODE.Location = new Point(92, 92);
            txtCST_POST_CODE.Name = "txtCST_POST_CODE";
            txtCST_POST_CODE.PlaceholderText = "郵遞區號";
            txtCST_POST_CODE.Size = new Size(86, 28);
            txtCST_POST_CODE.TabIndex = 2;
            txtCST_POST_CODE.TextAlign = HorizontalAlignment.Center;
            // 
            // flowPanel
            // 
            flowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowPanel.Location = new Point(13, 34);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(564, 32);
            flowPanel.TabIndex = 16;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(labNotice);
            groupBox2.Controls.Add(flowPanel);
            groupBox2.Location = new Point(12, 192);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10);
            groupBox2.Size = new Size(590, 181);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "通知事項";
            // 
            // labNotice
            // 
            labNotice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labNotice.BackColor = Color.White;
            labNotice.Location = new Point(13, 74);
            labNotice.Margin = new Padding(3, 10, 3, 5);
            labNotice.Name = "labNotice";
            labNotice.Padding = new Padding(5);
            labNotice.Size = new Size(564, 92);
            labNotice.TabIndex = 17;
            labNotice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmInfoNTF
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 431);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnSave);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MinimumSize = new Size(630, 470);
            Name = "frmInfoNTF";
            StartPosition = FormStartPosition.CenterParent;
            Text = "資料設定";
            TopMost = true;
            Load += frmNTF_Load;
            Shown += frmInfoNTF_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCST_NM;
        private TextBox txtCST_DEPT;
        private TextBox txtCST_ADDR;
        private TextBox txtCST_NO;
        private TextBox txtBOSS_NO;
        private FontAwesome.Sharp.IconButton btnSave;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowPanel;
        private GroupBox groupBox2;
        private Label labNotice;
        private TextBox txtCST_POST_CODE;
    }
}