namespace SGS.LEGAL.DLS
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            panMenu = new Panel();
            btnDemo = new FontAwesome.Sharp.IconButton();
            btnDataImport = new FontAwesome.Sharp.IconButton();
            panLogo = new Panel();
            btnHistory = new FontAwesome.Sharp.IconButton();
            btnUsage = new FontAwesome.Sharp.IconButton();
            btnUserInfo = new FontAwesome.Sharp.IconButton();
            btnNotify = new FontAwesome.Sharp.IconButton();
            panTitle = new Panel();
            labTitle = new Label();
            statusStrip1 = new StatusStrip();
            labVersion = new ToolStripStatusLabel();
            labSapce = new ToolStripStatusLabel();
            labUser = new ToolStripStatusLabel();
            progressBar1 = new CustomProgressBar();
            panContent = new Panel();
            panMenu.SuspendLayout();
            panTitle.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panMenu
            // 
            panMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panMenu.BackColor = Color.Gainsboro;
            panMenu.Controls.Add(btnDemo);
            panMenu.Controls.Add(btnDataImport);
            panMenu.Controls.Add(panLogo);
            panMenu.Controls.Add(btnHistory);
            panMenu.Controls.Add(btnUsage);
            panMenu.Controls.Add(btnUserInfo);
            panMenu.Controls.Add(btnNotify);
            panMenu.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panMenu.Location = new Point(0, 3);
            panMenu.Margin = new Padding(0);
            panMenu.Name = "panMenu";
            panMenu.Size = new Size(200, 536);
            panMenu.TabIndex = 0;
            // 
            // btnDemo
            // 
            btnDemo.AccessibleRole = AccessibleRole.None;
            btnDemo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDemo.BackColor = Color.DarkGray;
            btnDemo.FlatAppearance.BorderSize = 0;
            btnDemo.FlatAppearance.MouseOverBackColor = Color.Tomato;
            btnDemo.FlatStyle = FlatStyle.Flat;
            btnDemo.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDemo.ForeColor = Color.White;
            btnDemo.IconChar = FontAwesome.Sharp.IconChar.LaptopCode;
            btnDemo.IconColor = Color.White;
            btnDemo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnDemo.IconSize = 36;
            btnDemo.ImageAlign = ContentAlignment.BottomLeft;
            btnDemo.Location = new Point(0, 436);
            btnDemo.Margin = new Padding(0);
            btnDemo.Name = "btnDemo";
            btnDemo.Padding = new Padding(10, 0, 10, 0);
            btnDemo.Size = new Size(200, 50);
            btnDemo.TabIndex = 13;
            btnDemo.Text = "測試用";
            btnDemo.TextAlign = ContentAlignment.MiddleRight;
            btnDemo.UseVisualStyleBackColor = false;
            btnDemo.Click += btnDemo_Click;
            // 
            // btnDataImport
            // 
            btnDataImport.AccessibleRole = AccessibleRole.None;
            btnDataImport.BackColor = Color.DarkGray;
            btnDataImport.FlatAppearance.BorderSize = 0;
            btnDataImport.FlatAppearance.MouseOverBackColor = Color.Tomato;
            btnDataImport.FlatStyle = FlatStyle.Flat;
            btnDataImport.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDataImport.ForeColor = Color.White;
            btnDataImport.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnDataImport.IconColor = Color.White;
            btnDataImport.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnDataImport.IconSize = 36;
            btnDataImport.ImageAlign = ContentAlignment.BottomLeft;
            btnDataImport.Location = new Point(0, 50);
            btnDataImport.Margin = new Padding(0);
            btnDataImport.Name = "btnDataImport";
            btnDataImport.Padding = new Padding(10, 0, 10, 0);
            btnDataImport.Size = new Size(200, 50);
            btnDataImport.TabIndex = 12;
            btnDataImport.Text = "資料匯入";
            btnDataImport.TextAlign = ContentAlignment.MiddleRight;
            btnDataImport.UseVisualStyleBackColor = false;
            btnDataImport.Click += btnDataImport_Click;
            // 
            // panLogo
            // 
            panLogo.BackColor = Color.White;
            panLogo.Location = new Point(0, 0);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(200, 50);
            panLogo.TabIndex = 11;
            // 
            // btnHistory
            // 
            btnHistory.AccessibleRole = AccessibleRole.None;
            btnHistory.BackColor = Color.DarkGray;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatAppearance.MouseOverBackColor = Color.Tomato;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnHistory.ForeColor = Color.White;
            btnHistory.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            btnHistory.IconColor = Color.White;
            btnHistory.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnHistory.IconSize = 36;
            btnHistory.ImageAlign = ContentAlignment.BottomLeft;
            btnHistory.Location = new Point(0, 150);
            btnHistory.Margin = new Padding(0);
            btnHistory.Name = "btnHistory";
            btnHistory.Padding = new Padding(10, 0, 10, 0);
            btnHistory.Size = new Size(200, 50);
            btnHistory.TabIndex = 10;
            btnHistory.Text = "歷程記錄";
            btnHistory.TextAlign = ContentAlignment.MiddleRight;
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnUsage
            // 
            btnUsage.AccessibleRole = AccessibleRole.None;
            btnUsage.BackColor = Color.DarkGray;
            btnUsage.Enabled = false;
            btnUsage.FlatAppearance.BorderSize = 0;
            btnUsage.FlatAppearance.MouseOverBackColor = Color.Tomato;
            btnUsage.FlatStyle = FlatStyle.Flat;
            btnUsage.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsage.ForeColor = Color.White;
            btnUsage.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            btnUsage.IconColor = Color.White;
            btnUsage.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnUsage.IconSize = 36;
            btnUsage.ImageAlign = ContentAlignment.BottomLeft;
            btnUsage.Location = new Point(0, 200);
            btnUsage.Margin = new Padding(0);
            btnUsage.Name = "btnUsage";
            btnUsage.Padding = new Padding(10, 0, 10, 0);
            btnUsage.Size = new Size(200, 50);
            btnUsage.TabIndex = 9;
            btnUsage.Text = "使用狀況";
            btnUsage.TextAlign = ContentAlignment.MiddleRight;
            btnUsage.UseVisualStyleBackColor = false;
            // 
            // btnUserInfo
            // 
            btnUserInfo.AccessibleRole = AccessibleRole.None;
            btnUserInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUserInfo.BackColor = Color.DarkGray;
            btnUserInfo.FlatAppearance.BorderSize = 0;
            btnUserInfo.FlatAppearance.MouseOverBackColor = Color.Tomato;
            btnUserInfo.FlatStyle = FlatStyle.Flat;
            btnUserInfo.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUserInfo.ForeColor = Color.White;
            btnUserInfo.IconChar = FontAwesome.Sharp.IconChar.User;
            btnUserInfo.IconColor = Color.White;
            btnUserInfo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnUserInfo.IconSize = 36;
            btnUserInfo.ImageAlign = ContentAlignment.BottomLeft;
            btnUserInfo.Location = new Point(0, 486);
            btnUserInfo.Margin = new Padding(0);
            btnUserInfo.Name = "btnUserInfo";
            btnUserInfo.Padding = new Padding(10, 0, 10, 0);
            btnUserInfo.Size = new Size(200, 50);
            btnUserInfo.TabIndex = 6;
            btnUserInfo.Text = "使用者";
            btnUserInfo.TextAlign = ContentAlignment.MiddleRight;
            btnUserInfo.UseVisualStyleBackColor = false;
            btnUserInfo.Click += btnUserInfo_Click;
            // 
            // btnNotify
            // 
            btnNotify.AccessibleRole = AccessibleRole.None;
            btnNotify.BackColor = Color.DarkGray;
            btnNotify.FlatAppearance.BorderSize = 0;
            btnNotify.FlatAppearance.MouseOverBackColor = Color.Tomato;
            btnNotify.FlatStyle = FlatStyle.Flat;
            btnNotify.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNotify.ForeColor = Color.White;
            btnNotify.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            btnNotify.IconColor = Color.White;
            btnNotify.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnNotify.IconSize = 36;
            btnNotify.ImageAlign = ContentAlignment.BottomLeft;
            btnNotify.Location = new Point(0, 100);
            btnNotify.Margin = new Padding(0);
            btnNotify.Name = "btnNotify";
            btnNotify.Padding = new Padding(10, 0, 10, 0);
            btnNotify.Size = new Size(200, 50);
            btnNotify.TabIndex = 1;
            btnNotify.Text = "催款函";
            btnNotify.TextAlign = ContentAlignment.MiddleRight;
            btnNotify.UseVisualStyleBackColor = false;
            btnNotify.Click += btnNotify_Click;
            // 
            // panTitle
            // 
            panTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panTitle.BackColor = Color.White;
            panTitle.Controls.Add(labTitle);
            panTitle.Location = new Point(200, 3);
            panTitle.Margin = new Padding(0);
            panTitle.Name = "panTitle";
            panTitle.Size = new Size(684, 50);
            panTitle.TabIndex = 1;
            // 
            // labTitle
            // 
            labTitle.AutoSize = true;
            labTitle.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labTitle.ForeColor = SystemColors.ControlDarkDark;
            labTitle.Location = new Point(6, 9);
            labTitle.Name = "labTitle";
            labTitle.Size = new Size(84, 30);
            labTitle.TabIndex = 1;
            labTitle.Text = "Home";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { labVersion, labSapce, labUser });
            statusStrip1.Location = new Point(0, 539);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(884, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // labVersion
            // 
            labVersion.BackColor = Color.Transparent;
            labVersion.ForeColor = SystemColors.ControlDarkDark;
            labVersion.Name = "labVersion";
            labVersion.Size = new Size(34, 17);
            labVersion.Text = "0.0.0";
            labVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labSapce
            // 
            labSapce.BackColor = Color.Transparent;
            labSapce.Name = "labSapce";
            labSapce.Size = new Size(804, 17);
            labSapce.Spring = true;
            // 
            // labUser
            // 
            labUser.BackColor = Color.Transparent;
            labUser.Name = "labUser";
            labUser.Size = new Size(31, 17);
            labUser.Text = "XXX";
            labUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(0, 0);
            progressBar1.Margin = new Padding(0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(884, 3);
            progressBar1.TabIndex = 3;
            progressBar1.Value = 100;
            // 
            // panContent
            // 
            panContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panContent.Location = new Point(200, 53);
            panContent.Margin = new Padding(0);
            panContent.Name = "panContent";
            panContent.Size = new Size(684, 486);
            panContent.TabIndex = 4;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(panContent);
            Controls.Add(progressBar1);
            Controls.Add(statusStrip1);
            Controls.Add(panTitle);
            Controls.Add(panMenu);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(900, 600);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SGS.LEGAL.DLS";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            panMenu.ResumeLayout(false);
            panTitle.ResumeLayout(false);
            panTitle.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panMenu;
        private Panel panTitle;
        private StatusStrip statusStrip1;
        private CustomProgressBar progressBar1;
        private Panel panContent;
        private FontAwesome.Sharp.IconButton btnUserInfo;
        private FontAwesome.Sharp.IconButton btnNotify;
        private FontAwesome.Sharp.IconButton btnHistory;
        private FontAwesome.Sharp.IconButton btnUsage;
        private Panel panLogo;
        private Label labTitle;
        private FontAwesome.Sharp.IconButton btnDataImport;
        private ToolStripStatusLabel labVersion;
        private ToolStripStatusLabel labSapce;
        private ToolStripStatusLabel labUser;
        private FontAwesome.Sharp.IconButton btnDemo;
    }
}