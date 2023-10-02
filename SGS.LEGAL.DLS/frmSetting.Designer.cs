namespace SGS.LEGAL.DLS
{
    partial class frmSetting
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
            tabControl1 = new TabControl();
            tabDataImport = new TabPage();
            txtFileFormat = new TextBox();
            labFileFormat = new Label();
            btnBossPathCCS = new FontAwesome.Sharp.IconButton();
            txtBossPathCCS = new TextBox();
            btnBossPathFET = new FontAwesome.Sharp.IconButton();
            txtBossPathFET = new TextBox();
            btnBossPathTIS = new FontAwesome.Sharp.IconButton();
            txtBossPathTIS = new TextBox();
            btnBossPathSGS = new FontAwesome.Sharp.IconButton();
            txtBossPathSGS = new TextBox();
            labCCS = new Label();
            labBossPathFET = new Label();
            labTIS = new Label();
            labSGS = new Label();
            btnSaveSetting = new FontAwesome.Sharp.IconButton();
            tabControl1.SuspendLayout();
            tabDataImport.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabDataImport);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(660, 414);
            tabControl1.TabIndex = 2;
            // 
            // tabDataImport
            // 
            tabDataImport.BackColor = SystemColors.ButtonHighlight;
            tabDataImport.Controls.Add(txtFileFormat);
            tabDataImport.Controls.Add(labFileFormat);
            tabDataImport.Controls.Add(btnBossPathCCS);
            tabDataImport.Controls.Add(txtBossPathCCS);
            tabDataImport.Controls.Add(btnBossPathFET);
            tabDataImport.Controls.Add(txtBossPathFET);
            tabDataImport.Controls.Add(btnBossPathTIS);
            tabDataImport.Controls.Add(txtBossPathTIS);
            tabDataImport.Controls.Add(btnBossPathSGS);
            tabDataImport.Controls.Add(txtBossPathSGS);
            tabDataImport.Controls.Add(labCCS);
            tabDataImport.Controls.Add(labBossPathFET);
            tabDataImport.Controls.Add(labTIS);
            tabDataImport.Controls.Add(labSGS);
            tabDataImport.Location = new Point(4, 29);
            tabDataImport.Name = "tabDataImport";
            tabDataImport.Padding = new Padding(20);
            tabDataImport.Size = new Size(652, 381);
            tabDataImport.TabIndex = 0;
            tabDataImport.Text = "資料匯入";
            // 
            // txtFileFormat
            // 
            txtFileFormat.Location = new Point(23, 286);
            txtFileFormat.Margin = new Padding(3, 3, 0, 10);
            txtFileFormat.Name = "txtFileFormat";
            txtFileFormat.ReadOnly = true;
            txtFileFormat.Size = new Size(581, 28);
            txtFileFormat.TabIndex = 15;
            // 
            // labFileFormat
            // 
            labFileFormat.AutoSize = true;
            labFileFormat.Location = new Point(23, 263);
            labFileFormat.Name = "labFileFormat";
            labFileFormat.Size = new Size(73, 20);
            labFileFormat.TabIndex = 14;
            labFileFormat.Text = "檔案格式";
            // 
            // btnBossPathCCS
            // 
            btnBossPathCCS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBossPathCCS.BackColor = Color.Tomato;
            btnBossPathCCS.FlatAppearance.BorderSize = 0;
            btnBossPathCCS.FlatStyle = FlatStyle.Flat;
            btnBossPathCCS.Font = new Font("Microsoft JhengHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnBossPathCCS.ForeColor = Color.Transparent;
            btnBossPathCCS.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnBossPathCCS.IconColor = Color.White;
            btnBossPathCCS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBossPathCCS.IconSize = 24;
            btnBossPathCCS.Location = new Point(604, 225);
            btnBossPathCCS.Margin = new Padding(0);
            btnBossPathCCS.Name = "btnBossPathCCS";
            btnBossPathCCS.Size = new Size(28, 28);
            btnBossPathCCS.TabIndex = 13;
            btnBossPathCCS.TextAlign = ContentAlignment.MiddleRight;
            btnBossPathCCS.UseVisualStyleBackColor = false;
            btnBossPathCCS.Click += btnBossPathCCS_Click;
            // 
            // txtBossPathCCS
            // 
            txtBossPathCCS.Location = new Point(23, 225);
            txtBossPathCCS.Margin = new Padding(3, 3, 0, 10);
            txtBossPathCCS.Name = "txtBossPathCCS";
            txtBossPathCCS.ReadOnly = true;
            txtBossPathCCS.Size = new Size(581, 28);
            txtBossPathCCS.TabIndex = 12;
            // 
            // btnBossPathFET
            // 
            btnBossPathFET.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBossPathFET.BackColor = Color.Tomato;
            btnBossPathFET.FlatAppearance.BorderSize = 0;
            btnBossPathFET.FlatStyle = FlatStyle.Flat;
            btnBossPathFET.Font = new Font("Microsoft JhengHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnBossPathFET.ForeColor = Color.Transparent;
            btnBossPathFET.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnBossPathFET.IconColor = Color.White;
            btnBossPathFET.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBossPathFET.IconSize = 24;
            btnBossPathFET.Location = new Point(604, 164);
            btnBossPathFET.Margin = new Padding(0);
            btnBossPathFET.Name = "btnBossPathFET";
            btnBossPathFET.Size = new Size(28, 28);
            btnBossPathFET.TabIndex = 11;
            btnBossPathFET.TextAlign = ContentAlignment.MiddleRight;
            btnBossPathFET.UseVisualStyleBackColor = false;
            btnBossPathFET.Click += btnBossPathFET_Click;
            // 
            // txtBossPathFET
            // 
            txtBossPathFET.Location = new Point(23, 164);
            txtBossPathFET.Margin = new Padding(3, 3, 0, 10);
            txtBossPathFET.Name = "txtBossPathFET";
            txtBossPathFET.ReadOnly = true;
            txtBossPathFET.Size = new Size(581, 28);
            txtBossPathFET.TabIndex = 10;
            // 
            // btnBossPathTIS
            // 
            btnBossPathTIS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBossPathTIS.BackColor = Color.Tomato;
            btnBossPathTIS.FlatAppearance.BorderSize = 0;
            btnBossPathTIS.FlatStyle = FlatStyle.Flat;
            btnBossPathTIS.Font = new Font("Microsoft JhengHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnBossPathTIS.ForeColor = Color.Transparent;
            btnBossPathTIS.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnBossPathTIS.IconColor = Color.White;
            btnBossPathTIS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBossPathTIS.IconSize = 24;
            btnBossPathTIS.Location = new Point(604, 103);
            btnBossPathTIS.Margin = new Padding(0);
            btnBossPathTIS.Name = "btnBossPathTIS";
            btnBossPathTIS.Size = new Size(28, 28);
            btnBossPathTIS.TabIndex = 9;
            btnBossPathTIS.TextAlign = ContentAlignment.MiddleRight;
            btnBossPathTIS.UseVisualStyleBackColor = false;
            btnBossPathTIS.Click += btnBossPathTIS_Click;
            // 
            // txtBossPathTIS
            // 
            txtBossPathTIS.Location = new Point(23, 103);
            txtBossPathTIS.Margin = new Padding(3, 3, 0, 10);
            txtBossPathTIS.Name = "txtBossPathTIS";
            txtBossPathTIS.ReadOnly = true;
            txtBossPathTIS.Size = new Size(581, 28);
            txtBossPathTIS.TabIndex = 8;
            // 
            // btnBossPathSGS
            // 
            btnBossPathSGS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBossPathSGS.BackColor = Color.Tomato;
            btnBossPathSGS.FlatAppearance.BorderSize = 0;
            btnBossPathSGS.FlatStyle = FlatStyle.Flat;
            btnBossPathSGS.Font = new Font("Microsoft JhengHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnBossPathSGS.ForeColor = Color.Transparent;
            btnBossPathSGS.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnBossPathSGS.IconColor = Color.White;
            btnBossPathSGS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBossPathSGS.IconSize = 24;
            btnBossPathSGS.Location = new Point(604, 42);
            btnBossPathSGS.Margin = new Padding(0);
            btnBossPathSGS.Name = "btnBossPathSGS";
            btnBossPathSGS.Size = new Size(28, 28);
            btnBossPathSGS.TabIndex = 7;
            btnBossPathSGS.TextAlign = ContentAlignment.MiddleRight;
            btnBossPathSGS.UseVisualStyleBackColor = false;
            btnBossPathSGS.Click += btnBossPathSGS_Click;
            // 
            // txtBossPathSGS
            // 
            txtBossPathSGS.Location = new Point(23, 42);
            txtBossPathSGS.Margin = new Padding(3, 3, 0, 10);
            txtBossPathSGS.Name = "txtBossPathSGS";
            txtBossPathSGS.ReadOnly = true;
            txtBossPathSGS.Size = new Size(581, 28);
            txtBossPathSGS.TabIndex = 4;
            // 
            // labCCS
            // 
            labCCS.AutoSize = true;
            labCCS.Location = new Point(23, 202);
            labCCS.Name = "labCCS";
            labCCS.Size = new Size(41, 20);
            labCCS.TabIndex = 3;
            labCCS.Text = "程智";
            // 
            // labBossPathFET
            // 
            labBossPathFET.AutoSize = true;
            labBossPathFET.Location = new Point(23, 141);
            labBossPathFET.Name = "labBossPathFET";
            labBossPathFET.Size = new Size(41, 20);
            labBossPathFET.TabIndex = 2;
            labBossPathFET.Text = "遠東";
            // 
            // labTIS
            // 
            labTIS.AutoSize = true;
            labTIS.Location = new Point(23, 80);
            labTIS.Name = "labTIS";
            labTIS.Size = new Size(41, 20);
            labTIS.TabIndex = 1;
            labTIS.Text = "台工";
            // 
            // labSGS
            // 
            labSGS.AutoSize = true;
            labSGS.Location = new Point(23, 20);
            labSGS.Name = "labSGS";
            labSGS.Size = new Size(41, 20);
            labSGS.TabIndex = 0;
            labSGS.Text = "台檢";
            // 
            // btnSaveSetting
            // 
            btnSaveSetting.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveSetting.BackColor = Color.Tomato;
            btnSaveSetting.FlatAppearance.BorderSize = 0;
            btnSaveSetting.FlatStyle = FlatStyle.Flat;
            btnSaveSetting.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveSetting.ForeColor = Color.Transparent;
            btnSaveSetting.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnSaveSetting.IconColor = Color.White;
            btnSaveSetting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveSetting.IconSize = 28;
            btnSaveSetting.ImageAlign = ContentAlignment.BottomLeft;
            btnSaveSetting.Location = new Point(571, 433);
            btnSaveSetting.Margin = new Padding(4);
            btnSaveSetting.Name = "btnSaveSetting";
            btnSaveSetting.Padding = new Padding(3, 0, 0, 0);
            btnSaveSetting.Size = new Size(100, 40);
            btnSaveSetting.TabIndex = 10;
            btnSaveSetting.Text = "Save";
            btnSaveSetting.TextAlign = ContentAlignment.MiddleRight;
            btnSaveSetting.UseVisualStyleBackColor = false;
            btnSaveSetting.Click += btnSaveSetting_Click;
            // 
            // frmSetting
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 486);
            Controls.Add(btnSaveSetting);
            Controls.Add(tabControl1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmSetting";
            Text = "frmSetting";
            Load += frmSetting_Load;
            tabControl1.ResumeLayout(false);
            tabDataImport.ResumeLayout(false);
            tabDataImport.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabDataImport;
        private FontAwesome.Sharp.IconButton btnSaveSetting;
        private Label labSGS;
        private Label labCCS;
        private Label labBossPathFET;
        private Label labTIS;
        private FontAwesome.Sharp.IconButton btnBossPathSGS;
        private TextBox txtBossPathSGS;
        private FontAwesome.Sharp.IconButton btnBossPathCCS;
        private TextBox txtBossPathCCS;
        private FontAwesome.Sharp.IconButton btnBossPathFET;
        private TextBox txtBossPathFET;
        private FontAwesome.Sharp.IconButton btnBossPathTIS;
        private TextBox txtBossPathTIS;
        private TextBox txtFileFormat;
        private Label labFileFormat;
    }
}