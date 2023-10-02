using AutoMapper;
using SGS.LEGAL.DLS.Parameter;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;
using SGS.LEGAL.DLS.ViewModel;

namespace SGS.LEGAL.DLS.Mapping
{
    public class DepositMapping : Profile
    {
        public DepositMapping()
        {
            CreateMap<DepositInfo, DepositParameter>()
                //.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.Id:000}-{src.Name}"))
                //.ForMember(dest => dest.TIME_STAMP, opt => opt.MapFrom(src => $"{src.CRT_DATE:yyyy/MM/dd HH:mm:ss}"))
                .ReverseMap();

            CreateMap<DepositContactInfo, DepositContactParameter>()
                    //.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.Id:000}-{src.Name}"))
                    //.ForMember(dest => dest.TIME_STAMP, opt => opt.MapFrom(src => $"{src.CRT_DATE:yyyy/MM/dd HH:mm:ss}"))
                    .ReverseMap();
        }
    }
}
