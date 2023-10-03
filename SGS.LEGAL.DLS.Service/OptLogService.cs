using AutoMapper;
using SGS.LEGAL.DLS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var condition = _mapper.Map<OptLogCondition>(Info);
            using OptLogRepo repo = new(_user);
            var result = repo.Read(condition);
            var data = _mapper.Map<IList<OptLogResultModel>>(result);
            return data;
        }
    }
}
