using AutoMapper;
using StrategyGame.Bll.DTOs.Identity;
using StrategyGame.Model.Entities.Identity;

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
