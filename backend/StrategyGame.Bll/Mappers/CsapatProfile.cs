using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.DTOEnums;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Mappers
{
    public class CsapatProfile : Profile
    {
        public CsapatProfile()
        {
            CreateMap<Csapat, CsapatDTO>()
                 .ForMember(e => e.Tulajdonos, opt => opt.MapFrom(e => e.Tulajdonos))
                 .ForMember(e => e.Celpont, opt => opt.MapFrom(e => e.Celpont))
                 .ForMember(e => e.Kimenetel, opt => opt.MapFrom(e => (HarcEredmenyTipus)e.Kimenetel))
                 .ForMember(e => e.Egysegs, opt => opt.MapFrom(e => e.Egysegs))
                 .ReverseMap();
        }
    }
}
