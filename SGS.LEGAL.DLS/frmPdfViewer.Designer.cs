namespace SGS.LEGAL.DLS
{
    partial class frmPdfViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPdfViewer));
            pdfViewer1 = new PdfiumViewer.PdfViewer();
            btnApprove = new Button();
            btnCancel = new Button();
            btnFitWidth = new FontAwesome.Sharp.IconButton();
            btnFitHeight = new FontAwesome.Sharp.IconButton();
            btnZoomIn = new FontAwesome.Sharp.IconButton();
            btnZoomOut = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            txtLetterType = new TextBox();
            txtFileType = new TextBox();
            btnReprint = new Button();
            btnDownload = new Button();
            SuspendLayout();
            // 
            // pdfViewer1
            // 
            pdfViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pdfViewer1.BackColor = SystemColors.ActiveBorder;
            pdfViewer1.Location = new Point(-1, -2);
            pdfViewer1.Margin = new Padding(0, 0, 0, 10);
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.ShowToolbar = false;
            pdfViewer1.Size = new Size(1010, 499);
            pdfViewer1.TabIndex = 0;
            // 
            // btnApprove
            // 
            btnApprove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApprove.BackColor = Color.Tomato;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(806, 510);
            btnApprove.Name = "btnApprove";
            btnApprove.Padding = new Padding(3);
            btnApprove.Size = new Size(107, 39);
            btnApprove.TabIndex = 1;
            btnApprove.Text = "確定產出";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.Tomato;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(919, 510);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(3);
            btnCancel.Size = new Size(78, 39);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnFitWidth
            // 
            btnFitWidth.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFitWidth.BackColor = Color.CadetBlue;
            btnFitWidth.FlatStyle = FlatStyle.Flat;
            btnFitWidth.ForeColor = Color.White;
            btnFitWidth.IconChar = FontAwesome.Sharp.IconChar.TextWidth;
            btnFitWidth.IconColor = Color.White;
            btnFitWidth.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFitWidth.IconSize = 30;
            btnFitWidth.Location = new Point(12, 510);
            btnFitWidth.Name = "btnFitWidth";
            btnFitWidth.Padding = new Padding(0, 5, 0, 0);
            btnFitWidth.Size = new Size(46, 39);
            btnFitWidth.TabIndex = 3;
            btnFitWidth.UseVisualStyleBackColor = false;
            btnFitWidth.Click += btnFitWidth_Click;
            // 
            // btnFitHeight
            // 
            btnFitHeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFitHeight.BackColor = Color.CadetBlue;
            btnFitHeight.FlatStyle = FlatStyle.Flat;
            btnFitHeight.ForeColor = Color.White;
            btnFitHeight.IconChar = FontAwesome.Sharp.IconChar.TextHeight;
            btnFitHeight.IconColor = Color.White;
            btnFitHeight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFitHeight.IconSize = 30;
            btnFitHeight.Location = new Point(64, 510);
            btnFitHeight.Name = "btnFitHeight";
            btnFitHeight.Padding = new Padding(1, 3, 0, 0);
            btnFitHeight.Size = new Size(46, 39);
            btnFitHeight.TabIndex = 4;
            btnFitHeight.UseVisualStyleBackColor = false;
            btnFitHeight.Click += btnFitHeight_Click;
            // 
            // btnZoomIn
            // 
            btnZoomIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnZoomIn.BackColor = Color.CadetBlue;
            btnZoomIn.FlatStyle = FlatStyle.Flat;
            btnZoomIn.ForeColor = Color.White;
            btnZoomIn.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            btnZoomIn.IconColor = Color.White;
            btnZoomIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnZoomIn.IconSize = 30;
            btnZoomIn.Location = new Point(116, 510);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Padding = new Padding(1, 3, 0, 0);
            btnZoomIn.Size = new Size(46, 39);
            btnZoomIn.TabIndex = 5;
            btnZoomIn.UseVisualStyleBackColor = false;
            btnZoomIn.Click += btnZoomIn_Click;
            // 
            // btnZoomOut
            // 
            btnZoomOut.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnZoomOut.BackColor = Color.CadetBlue;
            btnZoomOut.FlatStyle = FlatStyle.Flat;
            btnZoomOut.ForeColor = Color.White;
            btnZoomOut.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassMinus;
            btnZoomOut.IconColor = Color.White;
            btnZoomOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnZoomOut.IconSize = 30;
            btnZoomOut.Location = new Point(168, 510);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Padding = new Padding(1, 3, 0, 0);
            btnZoomOut.Size = new Size(46, 39);
            btnZoomOut.TabIndex = 6;
            btnZoomOut.UseVisualStyleBackColor = false;
            btnZoomOut.Click += btnZoomOut_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(227, 512);
            label1.Margin = new Padding(10, 0, 0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(8, 9, 0, 8);
            label1.Size = new Size(97, 37);
            label1.TabIndex = 9;
            label1.Text = "催款函類型";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Location = new Point(504, 511);
            label2.Margin = new Padding(10, 0, 0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(8, 9, 0, 8);
            label2.Size = new Size(81, 37);
            label2.TabIndex = 10;
            label2.Text = "檔案類型";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtLetterType
            // 
            txtLetterType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtLetterType.BackColor = Color.White;
            txtLetterType.Location = new Point(327, 517);
            txtLetterType.Name = "txtLetterType";
            txtLetterType.ReadOnly = true;
            txtLetterType.Size = new Size(164, 28);
            txtLetterType.TabIndex = 11;
            txtLetterType.Text = "應收帳款催款函";
            txtLetterType.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFileType
            // 
            txtFileType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtFileType.BackColor = Color.White;
            txtFileType.Location = new Point(588, 516);
            txtFileType.Name = "txtFileType";
            txtFileType.ReadOnly = true;
            txtFileType.Size = new Size(92, 28);
            txtFileType.TabIndex = 12;
            txtFileType.Text = "收件回執";
            txtFileType.TextAlign = HorizontalAlignment.Center;
            // 
            // btnReprint
            // 
            btnReprint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReprint.BackColor = Color.Tomato;
            btnReprint.FlatStyle = FlatStyle.Flat;
            btnReprint.ForeColor = Color.White;
            btnReprint.Location = new Point(835, 510);
            btnReprint.Name = "btnReprint";
            btnReprint.Padding = new Padding(3);
            btnReprint.Size = new Size(78, 39);
            btnReprint.TabIndex = 13;
            btnReprint.Text = "補印";
            btnReprint.UseVisualStyleBackColor = false;
            btnReprint.Visible = false;
            btnReprint.Click += btnReprint_Click;
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDownload.BackColor = Color.Tomato;
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(835, 511);
            btnDownload.Name = "btnDownload";
            btnDownload.Padding = new Padding(3);
            btnDownload.Size = new Size(78, 39);
            btnDownload.TabIndex = 14;
            btnDownload.Text = "下載";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Visible = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // frmPdfViewer
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 561);
            Controls.Add(btnDownload);
            Controls.Add(btnReprint);
            Controls.Add(txtFileType);
            Controls.Add(txtLetterType);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnZoomOut);
            Controls.Add(btnZoomIn);
            Controls.Add(btnFitHeight);
            Controls.Add(btnFitWidth);
            Controls.Add(btnCancel);
            Controls.Add(btnApprove);
            Controls.Add(pdfViewer1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimizeBox = false;
            Name = "frmPdfViewer";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Preview";
            Load += frmPdfViewer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PdfiumViewer.PdfViewer pdfViewer1;
        private Button btnApprove;
        private Button btnCancel;
        private FontAwesome.Sharp.IconButton btnFitWidth;
        private FontAwesome.Sharp.IconButton btnFitHeight;
        private FontAwesome.Sharp.IconButton btnZoomIn;
        private FontAwesome.Sharp.IconButton btnZoomOut;
        private Label label1;
        private Label label2;
        private TextBox txtLetterType;
        private TextBox txtFileType;
        private Button btnReprint;
        private Button btnDownload;
    }
}