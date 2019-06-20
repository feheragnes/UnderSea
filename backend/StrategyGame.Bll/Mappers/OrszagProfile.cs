using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Mappers
{
    public class OrszagProfile : Profile
    {
        public OrszagProfile()
        {


            /*CreateMap<Orszag, OrszagDTO>()
                  .ForMember(e => e.Gyongy, opt => opt.MapFrom(e => e.Gyongy))
                  .ForMember(e => e.Korall, opt => opt.MapFrom(e => e.Korall))
                  .ForMember(e => e.Epulets, opt => opt.MapFrom(e => e.Epulets))
                  .ForMember(e => e.OtthoniCsapats, opt => opt.MapFrom(e => e.OtthoniCsapats))
                  .ForMember(e => e.TamadoCsapats, opt => opt.MapFrom(e => e.TamadoCsapats))
                  .ForMember(e => e.Fejleszteses, opt => opt.MapFrom(e => e.Fejleszteses))
                  .ReverseMap();*/
        }

    }
}
