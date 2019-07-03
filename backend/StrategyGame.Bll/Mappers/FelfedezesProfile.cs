using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Mappers
{
    class FelfedezesProfile : Profile
    {
        public FelfedezesProfile()
        {
            CreateMap<FelfedezesDTO, Felfedezes>()
                 .ForMember(e => e.Celpont, opt => opt.MapFrom(e => e.VedekezoOrszag))
                 .ForMember(e => e.VedekezoEro, opt => opt.MapFrom(e => e.VedekezoEro))
                 .ForMember(e => e.Gyongy, opt => opt.MapFrom(e => e.VedekezoGyongy))
                 .ForMember(e => e.Korall, opt => opt.MapFrom(e => e.VedekezoKorall))
                .ReverseMap();
        }
    }
}

