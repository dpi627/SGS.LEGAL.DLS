namespace SGS.LEGAL.DLS
{
    partial class frmPrint
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
            grpLetter = new GroupBox();
            cbbLetterPaper = new ComboBox();
            cbbLetterPrinter = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            grpReceipt = new GroupBox();
            cbbReceiptPaper = new ComboBox();
            cbbReceiptPrinter = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            grpEnvelope = new GroupBox();
            cbbEnvelopePaper = new ComboBox();
            cbbEnvelopePrinter = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            btnPrint = new Button();
            btnCancel = new Button();
            statusStrip1 = new StatusStrip();
            labMsg = new ToolStripStatusLabel();
            grpLetter.SuspendLayout();
            grpReceipt.SuspendLayout();
            grpEnvelope.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpLetter
            // 
            grpLetter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpLetter.Controls.Add(cbbLetterPaper);
            grpLetter.Controls.Add(cbbLetterPrinter);
            grpLetter.Controls.Add(label2);
            grpLetter.Controls.Add(label1);
            grpLetter.Location = new Point(14, 14);
            grpLetter.Margin = new Padding(5);
            grpLetter.Name = "grpLetter";
            grpLetter.Padding = new Padding(5);
            grpLetter.Size = new Size(456, 111);
            grpLetter.TabIndex = 0;
            grpLetter.TabStop = false;
            grpLetter.Tag = "L";
            grpLetter.Text = "催款函";
            // 
            // cbbLetterPaper
            // 
            cbbLetterPaper.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbLetterPaper.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLetterPaper.FormattingEnabled = true;
            cbbLetterPaper.Location = new Point(71, 63);
            cbbLetterPaper.Name = "cbbLetterPaper";
            cbbLetterPaper.Size = new Size(377, 28);
            cbbLetterPaper.TabIndex = 3;
            // 
            // cbbLetterPrinter
            // 
            cbbLetterPrinter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbLetterPrinter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLetterPrinter.FormattingEnabled = true;
            cbbLetterPrinter.Location = new Point(71, 29);
            cbbLetterPrinter.Name = "cbbLetterPrinter";
            cbbLetterPrinter.Size = new Size(377, 28);
            cbbLetterPrinter.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 66);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 1;
            label2.Text = "紙匣";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 32);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "印表機";
            // 
            // grpReceipt
            // 
            grpReceipt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpReceipt.Controls.Add(cbbReceiptPaper);
            grpReceipt.Controls.Add(cbbReceiptPrinter);
            grpReceipt.Controls.Add(label3);
            grpReceipt.Controls.Add(label4);
            grpReceipt.Location = new Point(14, 135);
            grpReceipt.Margin = new Padding(5);
            grpReceipt.Name = "grpReceipt";
            grpReceipt.Padding = new Padding(5);
            grpReceipt.Size = new Size(456, 111);
            grpReceipt.TabIndex = 4;
            grpReceipt.TabStop = false;
            grpReceipt.Tag = "R";
            grpReceipt.Text = "收件回執";
            // 
            // cbbReceiptPaper
            // 
            cbbReceiptPaper.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbReceiptPaper.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbReceiptPaper.FormattingEnabled = true;
            cbbReceiptPaper.Location = new Point(71, 63);
            cbbReceiptPaper.Name = "cbbReceiptPaper";
            cbbReceiptPaper.Size = new Size(377, 28);
            cbbReceiptPaper.TabIndex = 3;
            // 
            // cbbReceiptPrinter
            // 
            cbbReceiptPrinter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbReceiptPrinter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbReceiptPrinter.FormattingEnabled = true;
            cbbReceiptPrinter.Location = new Point(71, 29);
            cbbReceiptPrinter.Name = "cbbReceiptPrinter";
            cbbReceiptPrinter.Size = new Size(377, 28);
            cbbReceiptPrinter.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 66);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 1;
            label3.Text = "紙匣";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 32);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 0;
            label4.Text = "印表機";
            // 
            // grpEnvelope
            // 
            grpEnvelope.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpEnvelope.Controls.Add(cbbEnvelopePaper);
            grpEnvelope.Controls.Add(cbbEnvelopePrinter);
            grpEnvelope.Controls.Add(label5);
            grpEnvelope.Controls.Add(label6);
            grpEnvelope.Location = new Point(14, 256);
            grpEnvelope.Margin = new Padding(5);
            grpEnvelope.Name = "grpEnvelope";
            grpEnvelope.Padding = new Padding(5);
            grpEnvelope.Size = new Size(456, 111);
            grpEnvelope.TabIndex = 5;
            grpEnvelope.TabStop = false;
            grpEnvelope.Tag = "E";
            grpEnvelope.Text = "信封";
            // 
            // cbbEnvelopePaper
            // 
            cbbEnvelopePaper.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbEnvelopePaper.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbEnvelopePaper.FormattingEnabled = true;
            cbbEnvelopePaper.Location = new Point(73, 65);
            cbbEnvelopePaper.Name = "cbbEnvelopePaper";
            cbbEnvelopePaper.Size = new Size(375, 28);
            cbbEnvelopePaper.TabIndex = 3;
            // 
            // cbbEnvelopePrinter
            // 
            cbbEnvelopePrinter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbEnvelopePrinter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbEnvelopePrinter.FormattingEnabled = true;
            cbbEnvelopePrinter.Location = new Point(73, 31);
            cbbEnvelopePrinter.Name = "cbbEnvelopePrinter";
            cbbEnvelopePrinter.Size = new Size(375, 28);
            cbbEnvelopePrinter.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 68);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 1;
            label5.Text = "紙匣";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 34);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 0;
            label6.Text = "印表機";
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrint.BackColor = Color.Tomato;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(281, 390);
            btnPrint.Margin = new Padding(3, 3, 3, 10);
            btnPrint.Name = "btnPrint";
            btnPrint.Padding = new Padding(3);
            btnPrint.Size = new Size(107, 39);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "列印";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.Tomato;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(394, 390);
            btnCancel.Margin = new Padding(3, 3, 3, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(3);
            btnCancel.Size = new Size(78, 39);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labMsg });
            statusStrip1.Location = new Point(0, 439);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(484, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // labMsg
            // 
            labMsg.Name = "labMsg";
            labMsg.Size = new Size(39, 17);
            labMsg.Text = "{msg}";
            // 
            // frmPrint
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 461);
            Controls.Add(statusStrip1);
            Controls.Add(btnPrint);
            Controls.Add(btnCancel);
            Controls.Add(grpEnvelope);
            Controls.Add(grpReceipt);
            Controls.Add(grpLetter);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MinimumSize = new Size(500, 500);
            Name = "frmPrint";
            StartPosition = FormStartPosition.CenterParent;
            Text = "列印設定";
            Load += frmPrint_Load;
            grpLetter.ResumeLayout(false);
            grpLetter.PerformLayout();
            grpReceipt.ResumeLayout(false);
            grpReceipt.PerformLayout();
            grpEnvelope.ResumeLayout(false);
            grpEnvelope.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpLetter;
        private ComboBox cbbLetterPaper;
        private ComboBox cbbLetterPrinter;
        private Label label2;
        private Label label1;
        private GroupBox grpReceipt;
        private ComboBox cbbReceiptPaper;
        private ComboBox cbbReceiptPrinter;
        private Label label3;
        private Label label4;
        private GroupBox grpEnvelope;
        private ComboBox cbbEnvelopePaper;
        private ComboBox cbbEnvelopePrinter;
        private Label label5;
        private Label label6;
        private Button btnPrint;
        private Button btnCancel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labMsg;
    }
}