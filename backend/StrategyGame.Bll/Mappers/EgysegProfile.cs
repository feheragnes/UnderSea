using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

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

            CreateMap<Felfedezo, RohamFokaDTO>()
    .IncludeBase<Egyseg, EgysegDTO>()
    .ReverseMap();



            CreateMap<Egyseg, EgysegInfoDTO>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.Parse<EgysegTipus>(y.GetType().Name)))
                .ForMember(x => x.Mennyiseg, opt => opt.MapFrom(y => 0));
            CreateMap<RohamFoka, EgysegInfoDTO>()
                .IncludeBase<Egyseg, EgysegInfoDTO>();
            CreateMap<LezerCapa, EgysegInfoDTO>()
                .IncludeBase<Egyseg, EgysegInfoDTO>();
            CreateMap<CsataCsiko, EgysegInfoDTO>()
                .IncludeBase<Egyseg, EgysegInfoDTO>();

            CreateMap<EgysegInfo, EgysegInfoDTO>();

            CreateMap<List<Egyseg>, SeregInfoDTO>()
                .ForMember(x => x.Tipus, opt => opt.MapFrom(y => Enum.Parse<EgysegTipus>(y.FirstOrDefault().Discriminator)))
                .ForMember(x => x.Mennyiseg, opt => opt.MapFrom(y => y.Count));


        }
    }
}
