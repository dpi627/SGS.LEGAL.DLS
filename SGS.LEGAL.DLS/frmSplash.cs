using SGS.LEGAL.DLS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGS.LEGAL.DLS
{
    public partial class frmSplash : Form
    {
        private FormConfig _config;
        Random _r = new();
        bool _IsCount = false;
        frmMain _frmMain;
        int i = 0;

        public frmSplash(FormConfig config, bool isCount = true)
        {
            InitializeComponent();
            this._config = config;
            _IsCount = isCount;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //circularProgressBar1.Increment(_r.Next(3,5)); //隨機增加變量
            circularProgressBar1.Step = _r.Next(7, 11);
            i += circularProgressBar1.Step;
            circularProgressBar1.Value = i < circularProgressBar1.Maximum ? i : circularProgressBar1.Maximum;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();


            if (circularProgressBar1.Value == circularProgressBar1.Maximum)
            {
                timer1.Enabled = false;
                this.Hide();
                _frmMain.Show();
                _frmMain.FormClosed += (sender, e) => this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = "mailto:brian.li@sgs.com";
            Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSplash_Shown(object sender, EventArgs e)
        {
            if (_IsCount)
            {
                timer1_Tick(sender, e);
                this.UseWaitCursor = true;
            }
            else
                //DoubleClick += (sender, e) => this.Close();

                btnClose.Visible = !_IsCount;
            panel1.Visible = panel2.Visible = !_IsCount;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            // set splash-form size equals to background image size
            Width = BackgroundImage.Width;
            Height = BackgroundImage.Height;

            circularProgressBar1.Value = 0;
            circularProgressBar1.Step = 1;
            circularProgressBar1.StartAngle = 270;
            circularProgressBar1.ForeColor = Color.White; //.FromArgb(210, 255, 255, 255);
            circularProgressBar1.ProgressColor = Color.Tomato; //.FromArgb(210, 214, 118, 25);

            // load main-form
            if (_IsCount)
                _frmMain = new frmMain(_config);
        }
    }
}
