using AutoMapper;
using SGS.LEGAL.DLS.Repository.Condition;
using SGS.LEGAL.DLS.Repository.DataModel;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;

namespace SGS.LEGAL.DLS.Service.Mapping
{
    public class DocLogMapping : Profile
    {
        public DocLogMapping()
        {
            CreateMap<DocLogCondition, DocLogInfo>()
                //.ForMember(tar => tar.Status, opt => opt.MapFrom(src => src.IsActive ? "Y" : "N"))
                .ReverseMap();

            CreateMap<DocLogDataModel, DocLogResultModel>()
                //.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.Id:000}-{src.Name}"))
                //.ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => $"{src.CreateTime:yyyyMMddHHmmss}"))
                .ReverseMap();

            // ...other mappings
        }
    }
}
