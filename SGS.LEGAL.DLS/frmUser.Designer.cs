namespace SGS.LEGAL.DLS
{
    partial class frmUser
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
            grpCurrentUser = new GroupBox();
            labEmpID = new Label();
            labEmail = new Label();
            labName = new Label();
            grpSwitchUser = new GroupBox();
            btnSaveSetting = new FontAwesome.Sharp.IconButton();
            txtPassword = new TextBox();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            grpCurrentUser.SuspendLayout();
            grpSwitchUser.SuspendLayout();
            SuspendLayout();
            // 
            // grpCurrentUser
            // 
            grpCurrentUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpCurrentUser.Controls.Add(labEmpID);
            grpCurrentUser.Controls.Add(labEmail);
            grpCurrentUser.Controls.Add(labName);
            grpCurrentUser.Location = new Point(12, 12);
            grpCurrentUser.Name = "grpCurrentUser";
            grpCurrentUser.Size = new Size(1119, 172);
            grpCurrentUser.TabIndex = 2;
            grpCurrentUser.TabStop = false;
            grpCurrentUser.Text = "Current User";
            // 
            // labEmpID
            // 
            labEmpID.AutoSize = true;
            labEmpID.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labEmpID.ForeColor = Color.Black;
            labEmpID.Location = new Point(54, 49);
            labEmpID.Margin = new Padding(5);
            labEmpID.Name = "labEmpID";
            labEmpID.Size = new Size(64, 20);
            labEmpID.TabIndex = 2;
            labEmpID.Text = "EMP ID";
            // 
            // labEmail
            // 
            labEmail.AutoSize = true;
            labEmail.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labEmail.ForeColor = Color.Tomato;
            labEmail.Location = new Point(54, 117);
            labEmail.Margin = new Padding(5);
            labEmail.Name = "labEmail";
            labEmail.Size = new Size(58, 24);
            labEmail.TabIndex = 1;
            labEmail.Text = "Eamil";
            // 
            // labName
            // 
            labName.AutoSize = true;
            labName.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            labName.ForeColor = Color.DimGray;
            labName.Location = new Point(54, 79);
            labName.Margin = new Padding(5);
            labName.Name = "labName";
            labName.Size = new Size(74, 28);
            labName.TabIndex = 0;
            labName.Text = "Name";
            // 
            // grpSwitchUser
            // 
            grpSwitchUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSwitchUser.Controls.Add(btnSaveSetting);
            grpSwitchUser.Controls.Add(txtPassword);
            grpSwitchUser.Controls.Add(txtName);
            grpSwitchUser.Controls.Add(label2);
            grpSwitchUser.Controls.Add(label3);
            grpSwitchUser.Enabled = false;
            grpSwitchUser.Location = new Point(12, 190);
            grpSwitchUser.Name = "grpSwitchUser";
            grpSwitchUser.Size = new Size(1119, 201);
            grpSwitchUser.TabIndex = 4;
            grpSwitchUser.TabStop = false;
            grpSwitchUser.Text = "Switch User";
            // 
            // btnSaveSetting
            // 
            btnSaveSetting.BackColor = Color.Tomato;
            btnSaveSetting.FlatAppearance.BorderSize = 0;
            btnSaveSetting.FlatStyle = FlatStyle.Flat;
            btnSaveSetting.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveSetting.ForeColor = Color.Transparent;
            btnSaveSetting.IconChar = FontAwesome.Sharp.IconChar.Key;
            btnSaveSetting.IconColor = Color.White;
            btnSaveSetting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveSetting.IconSize = 28;
            btnSaveSetting.ImageAlign = ContentAlignment.BottomLeft;
            btnSaveSetting.Location = new Point(328, 133);
            btnSaveSetting.Margin = new Padding(4, 10, 4, 4);
            btnSaveSetting.Name = "btnSaveSetting";
            btnSaveSetting.Padding = new Padding(3, 0, 0, 0);
            btnSaveSetting.Size = new Size(99, 40);
            btnSaveSetting.TabIndex = 10;
            btnSaveSetting.Text = "Sign in";
            btnSaveSetting.TextAlign = ContentAlignment.MiddleRight;
            btnSaveSetting.UseVisualStyleBackColor = false;
            btnSaveSetting.Click += btnSaveSetting_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(155, 89);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "please enter the password";
            txtPassword.Size = new Size(272, 31);
            txtPassword.TabIndex = 3;
            // 
            // txtName
            // 
            txtName.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(155, 45);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "please enter the account";
            txtName.Size = new Size(272, 31);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(54, 92);
            label2.Name = "label2";
            label2.Size = new Size(95, 24);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(85, 48);
            label3.Name = "label3";
            label3.Size = new Size(64, 24);
            label3.TabIndex = 0;
            label3.Text = "Name";
            // 
            // frmUser
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 600);
            Controls.Add(grpSwitchUser);
            Controls.Add(grpCurrentUser);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmUser";
            Text = "frmUser";
            Load += frmUser_Load;
            grpCurrentUser.ResumeLayout(false);
            grpCurrentUser.PerformLayout();
            grpSwitchUser.ResumeLayout(false);
            grpSwitchUser.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCurrentUser;
        private Label labEmpID;
        private Label labEmail;
        private Label labName;
        private GroupBox grpSwitchUser;
        private FontAwesome.Sharp.IconButton btnSaveSetting;
        private TextBox txtPassword;
        private TextBox txtName;
        private Label label2;
        private Label label3;
    }
}