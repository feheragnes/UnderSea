using AutoMapper;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Model.Entities.Models.Egysegek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Mappers
{
    public class EgysegProfile : Profile
    {
        public EgysegProfile()
        {
         

            CreateMap<Egyseg, EgysegDTO>()
                .ForMember(e => e.Ar, opt => opt.MapFrom(e => e.Ar))
                .ForMember(e => e.Ellatas, opt => opt.MapFrom(e => e.Ellatas))
                .ForMember(e => e.Tamadas, opt => opt.MapFrom(e => e.Tamadas))
                .ForMember(e => e.Vedekezes, opt => opt.MapFrom(e => e.Vedekezes))
                .ForMember(e => e.Zsold, opt => opt.MapFrom(e => e.Zsold))
                .ReverseMap();

            CreateMap<CsataCsiko, CsataCsikoDTO>()
                .IncludeBase<Egyseg, EgysegDTO>()
                .ReverseMap();

            CreateMap<LezerCapa, LezerCapaDTO>()
                .IncludeBase<Egyseg, EgysegDTO>()
                .ReverseMap();

            CreateMap<RohamFoka, RohamFokaDTO>()
                .IncludeBase<Egyseg, EgysegDTO>()
                .ReverseMap();
        }
    }
}
