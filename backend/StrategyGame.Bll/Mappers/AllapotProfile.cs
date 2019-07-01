using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;

namespace StrategyGame.Bll.Mappers
{
    public class AllapotProfile : Profile
    {

        public AllapotProfile()
        {
            CreateMap<Allapot, AllapotDTO>()
                 .ForMember(e => e.Kimenetel, opt => opt.MapFrom(e => e.Kimenetel))
                .ReverseMap();
        }
    }
}
