using AutoMapper;
using StrategyGame.Api.ViewModels;
using StrategyGame.Api.ViewModels.AAAViewModels;
using StrategyGame.Api.ViewModels.EgysegViewModels;
using StrategyGame.Api.ViewModels.EpuletViewModels;
using StrategyGame.Api.ViewModels.FejlesztesViewModels;
using StrategyGame.Api.ViewModels.GlobalViewModels;
using StrategyGame.Api.ViewModels.OrszagViewModels;
using StrategyGame.Api.ViewModels.TamadasViewModels;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.AAADTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Enums;
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
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.GetName(typeof(EpuletTipus), y.Tipus)));
            CreateMap<EpuletInfoViewModel, EpuletInfoDTO>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.Parse(typeof(EpuletTipus), y.Tipus)));
            CreateMap<OrszagDTO, OrszagInfoViewModel>()
                .ForMember(x => x.SeregInfo, opt => opt.MapFrom(y => y.SeregInfoDTOs))
                .ForMember(x => x.EpuletInfo, opt => opt.MapFrom(y => y.EpuletInfoDTOs))
                .ReverseMap();
            CreateMap<HarcDTO, HarcViewModel>()
                .ForMember(x => x.TamadoCsapat, opt => opt.MapFrom(y => y.TamadoCsapat))
                .ForMember(x => x.VedekezoCsapat, opt => opt.MapFrom(y => y.VedekezoCsapat))
                .ForMember(x => x.HarcEredmeny, opt => opt.MapFrom(y => Enum.GetName(typeof(HarcEredmenyTipus), y.HarcEredmeny)));


            CreateMap<SeregInfoDTO, TamadoSeregInfoViewModel>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.GetName(typeof(EgysegTipus), y.Tipus)));
            CreateMap<TamadoSeregInfoViewModel, SeregInfoDTO>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.Parse<EgysegTipus>(y.Tipus)));
            CreateMap<TamadasDTO, TamadasViewModel>()
                .ForMember(x => x.Orszag, opt => opt.MapFrom(y => y.EllensegesOrszagok))
                .ForMember(x => x.Sereg, opt => opt.MapFrom(y => y.OtthoniEgysegek));

            CreateMap<FejlesztesInfoDTO, FejlesztesInfoViewModel>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.GetName(typeof(FejlesztesTipus), y.Tipus)));

            CreateMap<EgysegInfoDTO, EgysegInfoViewModel>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.GetName(typeof(EgysegTipus), y.Tipus)));

            CreateMap<FejlesztesInfoDTO, FejlesztesVetelViewModel>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.GetName(typeof(FejlesztesTipus), y.Tipus)));
            CreateMap<FejlesztesVetelViewModel, FejlesztesInfoDTO>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.Parse<FejlesztesTipus>(y.Tipus)));

            CreateMap<EgysegVetelViewModel, SeregInfoDTO>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.Parse<EgysegTipus>(y.Tipus)));
            //.ForMember(x => x.Ar, opt => opt.MapFrom(y => (Activator.CreateInstance(Type.GetType(y.Tipus)) as Egyseg).Ar));

            CreateMap<RanglistaDTO, RanglistaViewModel>().ReverseMap();

            CreateMap<TamadasInditasViewModel, BejovoTamadasDTO>()
                .ForMember(x => x.CelpontNev, opt => opt.MapFrom(y => y.Orszag))
                .ForMember(x => x.TamadoEgysegek, opt => opt.MapFrom(y => y.TamadoEgysegek));
                

        }
    }
}
