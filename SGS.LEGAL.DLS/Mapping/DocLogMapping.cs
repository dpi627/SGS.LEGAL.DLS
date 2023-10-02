using AutoMapper;
using SGS.LEGAL.DLS.Parameter;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;
using SGS.LEGAL.DLS.ViewModel;

namespace SGS.LEGAL.DLS.Mapping
{
    public class DocLogMapping : Profile
    {
        public DocLogMapping()
        {
            CreateMap<DocLogInfo, DocLogParameter>()
                //.ForMember(tar => tar.Status, opt => opt.MapFrom(src => src.IsActive ? "Y" : "N"))
                .ReverseMap();

            CreateMap<DocLogResultModel, DocLogViewModel>()
                //.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.Id:000}-{src.Name}"))
                .ForMember(dest => dest.TIME_STAMP, opt => opt.MapFrom(src => $"{src.CRT_DATE:yyyy/MM/dd HH:mm:ss}"))
                .ReverseMap();

            // ...other mappings
        }
    }
}
