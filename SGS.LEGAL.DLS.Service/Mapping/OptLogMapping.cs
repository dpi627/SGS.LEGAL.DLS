using AutoMapper;
using SGS.LEGAL.DLS.Repository.DataModel;
using SGS.LEGAL.DLS.Service.ResultModel;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;

namespace SGS.LEGAL.DLS.Service.Mapping
{
    internal class OptLogMapping : Profile
    {
        public OptLogMapping()
        {
            CreateMap<OptLogDataModel, OptLogResultModel>()
                //.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.Id:000}-{src.Name}"))
                //.ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => $"{src.CreateTime:yyyyMMddHHmmss}"))
                .ReverseMap();
        }
    }
}
