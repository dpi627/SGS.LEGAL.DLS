
using PdfiumViewer;
using SGS.LEGAL.DLS.Model;
using System.Diagnostics;
using System.Windows.Forms;

namespace SGS.LEGAL.DLS
{
    public partial class frmDemo : Form
    {
        private readonly FormConfig? _config;

        public frmDemo() { }
        public frmDemo(FormConfig config)
        {
            InitializeComponent();
            this._config = config;
        }

        private void frmDemo_Load(object sender, EventArgs e)
        {
        }

        private void frmDemo_Shown(object sender, EventArgs e)
        {
        }

    }
}
