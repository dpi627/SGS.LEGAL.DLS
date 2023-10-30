using AutoMapper;
using SGS.LEGAL.DLS.Model;
using SGS.LEGAL.DLS.Parameter;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service;
using SGS.LEGAL.DLS.ViewModel;
using SGS.LEGAL.DLS.Entity;
using u = SGS.LIB.Common.Utility;
using SGS.LEGAL.DLS.Mapping;

namespace SGS.LEGAL.DLS
{
    public partial class frmOptLog : Form
    {
        private IMapper? _mapper;
        private readonly FormConfig? config;
        private SYS_USER? CurrentUser => config?.CurrentUser;

        public frmOptLog() { }
        public frmOptLog(FormConfig config)
        {
            InitializeComponent();
            this.config = config;
            var configMap = new MapperConfiguration(cfg => cfg.AddProfile<OptLogMapping>());
            _mapper = configMap.CreateMapper();
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetDocLog();
        }

        private void GetDocLog()
        {
            OptLogParameter? param = GetParameter();

            Utility.AddLog(
                OptLogType.Search,
                CurrentUser!,
                this.GetType().Name,
                param.ToString()
                );

            // convert DTO => Parameter to Info
            var info = _mapper.Map<OptLogInfo>(param);
            // create Service
            using OptLogService svc = new OptLogService(CurrentUser);
            // get data from Service
            var result = svc.Get(info);
            // convert DTO => ResultModel to ViewModel
            var dataSource = _mapper.Map<IList<OptLogViewModel>>(result);
            // convert DTO to DataTable
            // 非必要，但 DataGridView 有時候設定 DataTable 比較好操作
            dgvOptLog.DataSource = u.ToDataTable(dataSource);
        }

        private OptLogParameter GetParameter()
        {
            return new OptLogParameter()
            {
                DATE_START = dtpStartDate.Value, //DateTime.Now.AddDays(-7),
                DATE_END = dtpEndDate.Value
            };
        }
    }
}
