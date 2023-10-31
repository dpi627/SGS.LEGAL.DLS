using AutoMapper;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service.Mapping;
using SGS.LEGAL.DLS.Repository.Condition;
using SGS.LEGAL.DLS.Repository;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;
using SGS.LEGAL.DLS.Repository.DataModel;

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
            // convert DTO => Info to Condition
            var condition = _mapper.Map<OptLogCondition>(Info);
            // create Repository, then get data (DTO collection)
            using OptLogRepo repo = new(_user);
            IList<OptLogDataModel>? result = repo.Read(condition);
            // convert DTO => DataModel to ResultModel
            IList<OptLogResultModel>? data = _mapper.Map<IList<OptLogResultModel>>(result);
            // return DTO collection
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
