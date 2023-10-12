using AutoMapper;
using SGS.LEGAL.DLS.Repository.DataModel;
using SGS.LEGAL.DLS.Service.ResultModel;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Repository.Condition;

namespace SGS.LEGAL.DLS.Service.Mapping
{
    internal class OptLogMapping : Profile
    {
        public OptLogMapping()
        {
            CreateMap<OptLogCondition, OptLogInfo>()
            //.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.Id:000}-{src.Name}"))
            //.ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => $"{src.CreateTime:yyyyMMddHHmmss}"))
            .ReverseMap();

            CreateMap<OptLogDataModel, OptLogResultModel>()
                //.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.Id:000}-{src.Name}"))
                //.ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => $"{src.CreateTime:yyyyMMddHHmmss}"))
                .ReverseMap();
        }
    }
}
