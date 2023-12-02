namespace SGS.LEGAL.DLS
{
    partial class frmSplash
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
            components = new System.ComponentModel.Container();
            labTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            circularProgressBar1 = new CircularProgressBar_NET5.CircularProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            panel2 = new Panel();
            panel1 = new Panel();
            lnkUserManual = new LinkLabel();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            btnClose = new Button();
            labMsg = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labTitle
            // 
            labTitle.AutoSize = true;
            labTitle.BackColor = Color.Transparent;
            labTitle.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labTitle.ForeColor = Color.Coral;
            labTitle.Location = new Point(12, 115);
            labTitle.Name = "labTitle";
            labTitle.Size = new Size(259, 18);
            labTitle.TabIndex = 2;
            labTitle.Text = "Dunning Letter Management System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(9, 80);
            label1.Name = "label1";
            label1.Size = new Size(348, 35);
            label1.TabIndex = 3;
            label1.Text = "催 款 函 製 作 暨 管 理 系 統";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(323, 346);
            label2.Name = "label2";
            label2.Size = new Size(319, 13);
            label2.TabIndex = 4;
            label2.Text = "Copyright © 2023 SGS Taiwan Ltd. All Right Reserved.";
            // 
            // circularProgressBar1
            // 
            circularProgressBar1.AnimationFunction = WinFormAnimation_NET5.KnownAnimationFunctions.Linear;
            circularProgressBar1.AnimationSpeed = 500;
            circularProgressBar1.BackColor = Color.Transparent;
            circularProgressBar1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            circularProgressBar1.ForeColor = Color.White;
            circularProgressBar1.InnerColor = Color.Transparent;
            circularProgressBar1.InnerMargin = 2;
            circularProgressBar1.InnerWidth = -1;
            circularProgressBar1.Location = new Point(577, 272);
            circularProgressBar1.MarqueeAnimationSpeed = 2000;
            circularProgressBar1.Name = "circularProgressBar1";
            circularProgressBar1.OuterColor = Color.White;
            circularProgressBar1.OuterMargin = -25;
            circularProgressBar1.OuterWidth = 5;
            circularProgressBar1.ProgressColor = Color.DarkOrange;
            circularProgressBar1.ProgressWidth = 5;
            circularProgressBar1.SecondaryFont = new Font("Microsoft JhengHei UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            circularProgressBar1.Size = new Size(50, 50);
            circularProgressBar1.StartAngle = 270;
            circularProgressBar1.Step = 1;
            circularProgressBar1.SubscriptColor = Color.FromArgb(166, 166, 166);
            circularProgressBar1.SubscriptMargin = new Padding(10, -35, 0, 0);
            circularProgressBar1.SubscriptText = "";
            circularProgressBar1.SuperscriptColor = Color.FromArgb(166, 166, 166);
            circularProgressBar1.SuperscriptMargin = new Padding(10, 35, 0, 0);
            circularProgressBar1.SuperscriptText = "";
            circularProgressBar1.TabIndex = 0;
            circularProgressBar1.TextMargin = new Padding(0);
            circularProgressBar1.Value = 68;
            // 
            // timer1
            // 
            timer1.Interval = 350;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Tomato;
            panel2.Location = new Point(12, 153);
            panel2.Name = "panel2";
            panel2.Size = new Size(5, 68);
            panel2.TabIndex = 7;
            panel2.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(lnkUserManual);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label5);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(21, 153);
            panel1.Name = "panel1";
            panel1.Size = new Size(129, 68);
            panel1.TabIndex = 6;
            panel1.Visible = false;
            // 
            // lnkUserManual
            // 
            lnkUserManual.ActiveLinkColor = Color.Gold;
            lnkUserManual.AutoSize = true;
            lnkUserManual.LinkColor = Color.Tomato;
            lnkUserManual.Location = new Point(0, 51);
            lnkUserManual.Name = "lnkUserManual";
            lnkUserManual.Size = new Size(109, 15);
            lnkUserManual.TabIndex = 4;
            lnkUserManual.TabStop = true;
            lnkUserManual.Text = "下載使用手冊(PDF)";
            lnkUserManual.VisitedLinkColor = Color.FromArgb(214, 118, 25);
            lnkUserManual.LinkClicked += lnkUserManual_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(0, 18);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 3;
            label4.Text = "Brian, Li #1429";
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Gold;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Tomato;
            linkLabel1.Location = new Point(0, 33);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(103, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "brian.li@sgs.com";
            linkLabel1.VisitedLinkColor = Color.FromArgb(214, 118, 25);
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(72, 18);
            label5.TabIndex = 1;
            label5.Text = "Call Help";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(598, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.TabIndex = 8;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Visible = false;
            btnClose.Click += button1_Click;
            // 
            // labMsg
            // 
            labMsg.AutoSize = true;
            labMsg.BackColor = Color.Transparent;
            labMsg.ForeColor = SystemColors.ControlDarkDark;
            labMsg.Location = new Point(12, 336);
            labMsg.Name = "labMsg";
            labMsg.Size = new Size(40, 15);
            labMsg.TabIndex = 9;
            labMsg.Text = "msg...";
            // 
            // frmSplash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.splash;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(640, 360);
            Controls.Add(labMsg);
            Controls.Add(btnClose);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(circularProgressBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labTitle);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(640, 360);
            Name = "frmSplash";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSplash";
            TopMost = true;
            Load += frmSplash_Load;
            Shown += frmSplash_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labTitle;
        private Label label1;
        private Label label2;
        private CircularProgressBar_NET5.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Timer timer1;
        private Panel panel2;
        private Panel panel1;
        private Label label4;
        private LinkLabel linkLabel1;
        private Label label5;
        private Button btnClose;
        private Label labMsg;
        private LinkLabel lnkUserManual;
    }
}