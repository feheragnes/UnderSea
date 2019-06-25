using AutoMapper;
using StrategyGame.Bll.DTOs.Identity;
using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<StrategyGameUser, StrategyGameUserDTO>()
                .ForMember(e => e.Email, opt => opt.MapFrom(e => e.Email))
                 .ReverseMap();
        }
    }
}
