using AutoMapper;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Repository;
using SGS.LEGAL.DLS.Repository.Condition;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.Mapping;
using SGS.LEGAL.DLS.Service.ResultModel;
using System.Data;
using u = SGS.LIB.Common.Utility;

namespace SGS.LEGAL.DLS.Service
{
    public class DocLogService : BaseService
    {
        private readonly SYS_USER _user;
        private readonly IMapper _mapper;

        public DocLogService(SYS_USER? user) : base(user)
        {
            _user = user ?? new SYS_USER();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<DocLogMapping>());
            _mapper = config.CreateMapper();
        }

        public IList<DocLogResultModel> Get(DocLogInfo Info)
        {
            var condition = _mapper.Map<DocLogCondition>(Info);
            using DocLogRepo repo = new DocLogRepo(_user);
            var result = repo.Read(condition);
            var data = _mapper.Map<IList<DocLogResultModel>>(result);
            return data;
        }

        public DocLogResultModel? Get(string DOC_ID)
        {
            using DocLogRepo repo = new DocLogRepo(_user);
            var data = _mapper.Map<DocLogResultModel>(repo.Read(DOC_ID));
            return data;
        }

        public string? Add(DOC_LOG? model)
        {
            if (model == default)
                return null;

            model.DOC_ID = Ulid.NewUlid().ToString();
            model.CRT_USER = _user.EMP_ID;

            using DocLogRepo repo = new DocLogRepo(_user);
            bool result = repo.Create(model);

            return result ? model.DOC_ID : null;
        }
    }
}
