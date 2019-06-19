using AutoMapper;
using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Mappers
{
    class FejlesztesProfile : Profile
    {
        public FejlesztesProfile()
        {
            CreateMap<Fejlesztes, FejlesztesDTO>()
              .ForMember(e => e.Noveles, opt => opt.MapFrom(e => e.Noveles))
              .ForMember(e => e.SzuksegesKorok, opt => opt.MapFrom(e => e.SzuksegesKorok))
              .ForMember(e => e.AktualisKor, opt => opt.MapFrom(e => e.AktualisKor))
              .ForMember(e => e.Kifejlesztve, opt => opt.MapFrom(e => e.Kifejlesztve))
              .ReverseMap();
        }
    }
}
