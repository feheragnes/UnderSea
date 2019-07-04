﻿using AutoMapper;
using StrategyGame.Bll.DTOs.Epuletek;
using StrategyGame.Model.Entities.Models.Epuletek;

namespace StrategyGame.Bll.Mappers
{
    public class EpuletProfile : Profile
    {

        public EpuletProfile()
        {
            CreateMap<Epulet, EpuletDTO>()
                .ForMember(e => e.Ar, opt => opt.MapFrom(e => e.Ar))
                .ForMember(e => e.SzuksegesKorok, opt => opt.MapFrom(e => e.SzuksegesKorok))
                .ForMember(e => e.AktualisKor, opt => opt.MapFrom(e => e.AktualisKor))
                .ForMember(e => e.Felepult, opt => opt.MapFrom(e => e.Felepult))
                .ReverseMap();

            CreateMap<AramlasIranyito, AramlasIranyitoDTO>()
                .IncludeBase<Epulet, EpuletDTO>()
                .ReverseMap();

            CreateMap<ZatonyVar, ZatonyvarDTO>()
               .IncludeBase<Epulet, EpuletDTO>()
               .ReverseMap();

            CreateMap<KoBanya, KoBanyaDTO>()
               .IncludeBase<Epulet, EpuletDTO>()
               .ReverseMap();

        }
    }
}
