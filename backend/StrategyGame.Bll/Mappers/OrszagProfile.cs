using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;

namespace StrategyGame.Bll.Mappers
{
    public class OrszagProfile : Profile
    {
        public OrszagProfile()
        {


            CreateMap<Orszag, OrszagDTO>()
                  .ForMember(e => e.Nev, opt => opt.MapFrom(e => e.Nev))
                  .ForMember(e => e.Gyongy, opt => opt.MapFrom(e => e.Gyongy))
                  .ForMember(e => e.Korall, opt => opt.MapFrom(e => e.Korall))
                  .ReverseMap();

        }

    }
}
