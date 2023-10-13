using AutoMapper;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service.Mapping;
using SGS.LEGAL.DLS.Repository.Condition;
using SGS.LEGAL.DLS.Repository;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;

namespace SGS.LEGAL.DLS.Service
{
    public class OptLogService : BaseService
    {
        private readonly SYS_USER _user;
        private readonly IMapper _mapper;

        public OptLogService(SYS_USER? user) : base(user)
        {
            _user = user ?? new SYS_USER();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<OptLogMapping>());
            _mapper = config.CreateMapper();
        }

        public IList<OptLogResultModel> Get(OptLogInfo Info)
        {
            // Info 轉為搜尋條件 Condition
            var condition = _mapper.Map<OptLogCondition>(Info);
            using OptLogRepo repo = new(_user);
            // 使用搜尋條件 Condition 取得底層 repo 資料集合 DataModel
            var result = repo.Read(condition);
            // DataModel 轉為 Service 層的資料集合 ResultModel
            var data = _mapper.Map<IList<OptLogResultModel>>(result);
            return data;
        }

        public bool Add(OptLogInfo model)
        {
            if (model == default)
                return false;

            model.CRT_USER = _user.EMP_ID;

            using OptLogRepo repo = new(_user);
            bool result = repo.Create(model);

            return result;
        }
    }
}
