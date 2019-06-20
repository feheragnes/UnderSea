using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Mappers
{
    class JatekProfile : Profile
    {

        public JatekProfile()
        {
            CreateMap<Jatek, JatekDTO>()
                 .ForMember(e => e.Korok, opt => opt.MapFrom(e => e.Korok))
                 .ReverseMap();
        }
    }
}
