using AutoMapper;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class FelfedezesService : IFelfedezesService

    {

        private readonly StrategyGameContext _context;
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;

        public FelfedezesService(StrategyGameContext context,
            IOrszagService orszagService,
            ICommonService commonService,
            IMapper mapper)
        {
            _context = context;
            _orszagService = orszagService;
            _commonService = commonService;
            _mapper = mapper;
        }
        public async Task<SeregInfoDTO> GetOtthoniFelfedezokFromOneUserAsync(Orszag currentOrszag)
        {
            var otthoniFelfedezok = currentOrszag.OtthoniCsapats?.SingleOrDefault(T => T.Celpont == null)?.Egysegs.FindAll(x => x.Discriminator.Equals("Felfedezo")).ToList();

            SeregInfoDTO seregInfo = new SeregInfoDTO
            {
                Tipus= Model.Enums.EgysegTipus.Felfedezo,
                Ar = 50,
                Mennyiseg = otthoniFelfedezok.Count(),
                Tamadas = 0,
                Vedekezes = 0,
                Szint = 1
            };

            return seregInfo;
        }
    }
}
