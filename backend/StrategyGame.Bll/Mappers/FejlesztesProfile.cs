using AutoMapper;
using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;

namespace StrategyGame.Bll.Mappers
{
    public class FejlesztesProfile : Profile
    {
        public FejlesztesProfile()
        {
            CreateMap<Fejlesztes, FejlesztesDTO>()
              .ForMember(e => e.SzuksegesKorok, opt => opt.MapFrom(e => e.SzuksegesKorok))
              .ForMember(e => e.AktualisKor, opt => opt.MapFrom(e => e.AktualisKor))
              .ForMember(e => e.Kifejlesztve, opt => opt.MapFrom(e => e.Kifejlesztve))
              .ReverseMap();

            CreateMap<Alkimia, AlkimiaDTO>()
               .IncludeBase<Fejlesztes, FejlesztesDTO>()
               .ReverseMap();

            CreateMap<IszapKombajn, IszapKombajnDTO>()
               .IncludeBase<Fejlesztes, FejlesztesDTO>()
               .ReverseMap();

            CreateMap<IszapTraktor, IszapTraktorDTO>()
               .IncludeBase<Fejlesztes, FejlesztesDTO>()
               .ReverseMap();

            CreateMap<KorallFal, KorallFalDTO>()
               .IncludeBase<Fejlesztes, FejlesztesDTO>()
               .ReverseMap();

            CreateMap<SzonarAgyu, SzonarAgyuDTO>()
               .IncludeBase<Fejlesztes, FejlesztesDTO>()
               .ReverseMap();

            CreateMap<VizalattiHarcmuveszet, VizalattiHarcmuveszetDTO>()
               .IncludeBase<Fejlesztes, FejlesztesDTO>()
               .ReverseMap();
        }
    }
}
