using AutoMapper;
using StrategyGame.Api.ViewModels.AAAViewModels;
using StrategyGame.Api.ViewModels.EgysegViewModels;
using StrategyGame.Api.ViewModels.EpuletViewModels;
using StrategyGame.Api.ViewModels.OrszagViewModels;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.AAADTOs;
using StrategyGame.Bll.DTOs.DTOEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.Mappers
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<LoginDTO, LoginViewModel>().ReverseMap();
            CreateMap<RegistrationDTO, RegisterViewModel>().ReverseMap();
            CreateMap<SeregInfoDTO, SeregInfoViewModel>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.GetName(typeof(EgysegTipus), y.Tipus)))
                .ReverseMap();
            CreateMap<EpuletInfoDTO, EpuletInfoViewModel>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.GetName(typeof(EpuletTipus), y.Tipus)))
                .ReverseMap();
            CreateMap<OrszagDTO, OrszagInfoViewModel>()
                .ForMember(x => x.SeregInfo, opt => opt.MapFrom(y => y.SeregInfoDTOs))
                .ForMember(x => x.EpuletInfo, opt => opt.MapFrom(y => y.EpuletInfoDTOs))
                .ReverseMap();
                
        }
    }
}
