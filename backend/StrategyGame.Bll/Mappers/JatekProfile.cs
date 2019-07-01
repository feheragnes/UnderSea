using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;

namespace StrategyGame.Bll.Mappers
{
    public class JatekProfile : Profile
    {

        public JatekProfile()
        {
            CreateMap<Jatek, JatekDTO>()
                 .ForMember(e => e.Korok, opt => opt.MapFrom(e => e.Korok))
                 .ReverseMap();
        }
    }
}
