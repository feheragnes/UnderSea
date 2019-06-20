using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Mappers
{
    class AllapotProfile : Profile
    {

        public AllapotProfile()
        {
            CreateMap<Allapot, AllapotDTO>()
                 .ForMember(e => e.Kimenetel, opt => opt.MapFrom(e => e.Kimenetel))
                .ReverseMap();
        }
    }
}
