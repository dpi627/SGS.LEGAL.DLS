using AutoMapper;
using SGS.LEGAL.DLS.Parameter;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;
using SGS.LEGAL.DLS.ViewModel;

namespace SGS.LEGAL.DLS.Mapping
{
    public class OptLogMapping : Profile
    {
        public OptLogMapping()
        {
            CreateMap<OptLogInfo, OptLogParameter>()
                //.ForMember(tar => tar.Status, opt => opt.MapFrom(src => src.IsActive ? "Y" : "N"))
                .ReverseMap();

            CreateMap<OptLogResultModel, OptLogViewModel>()
                .ForMember(dest => dest.EMP_ID, opt => opt.MapFrom(src => src.CRT_USER))
                .ForMember(dest => dest.LOG_DATE, opt => opt.MapFrom(src => $"{src.CRT_DATE:yyyy/MM/dd HH:mm:ss}"))
                .ReverseMap();

            // ...other mappings
        }
    }
}
