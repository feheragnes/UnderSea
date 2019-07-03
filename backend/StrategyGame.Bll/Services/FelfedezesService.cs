using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Enums;
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

        public async Task<TamadasDTO> GetFelfedezes(Guid userId)
        {
            var allEgysegs = await _orszagService.GetTamadasDTO(userId);

            allEgysegs.OtthoniEgysegek = allEgysegs.OtthoniEgysegek.Where(x => x.Tipus == EgysegTipus.Felfedezo).ToList();

            return allEgysegs;
        }

        public async Task<List<FelfedezesDTO>> GetFinishedFelfedezeses(Guid userId)
        {
            var currentOrszag = await _commonService.GetCurrentOrszag(userId);
            var debug = _mapper.Map<List<FelfedezesDTO>>(currentOrszag.Fejleszteses.ToList());
            return debug;
        }

        public async Task<SeregInfoDTO> GetOtthoniFelfedezokFromOneUserAsync(Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            long otthoniFelfedezokSzama = currentOrszag.OtthoniCsapats.SingleOrDefault(T => T.Celpont == null).Egysegs.FindAll(x => x.Discriminator.Equals("Felfedezo")).Count();

            SeregInfoDTO seregInfo = new SeregInfoDTO()
            {
                Tipus = Model.Enums.EgysegTipus.Felfedezo,
                Ar = 50,
                Mennyiseg = otthoniFelfedezokSzama,
                Tamadas = 0,
                Vedekezes = 0,
                Szint = 1
            };

            return seregInfo;
        }
        public async Task<FelfedezesDTO> MakeFelfedezes(BejovoFelfedezesDTO bejovoFelfedezes, Guid userId)
        {
            var celpontOrszag = _context.Orszags.Include(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs).SingleOrDefault(x => x.Nev == bejovoFelfedezes.CelpontNev);
            var tulajdonosOrszag = await _commonService.GetCurrentOrszag(userId);
            var vedoKepesseg = celpontOrszag.OtthoniCsapats.SingleOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon)
                .Egysegs.Where(x => x.Discriminator == EgysegTipus.Felfedezo.ToString()).Cast<Felfedezo>()?.Sum(x => x.KemkedesiKepesseg) ?? 0;
            var tamadoFelfedezok = tulajdonosOrszag.OtthoniCsapats.SingleOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon)
                .Egysegs.Where(x => x.Discriminator == EgysegTipus.Felfedezo.ToString() && !(x as Felfedezo).Felfedezett)
                .Take(Convert.ToInt32(bejovoFelfedezes.TamadoFelfedezok.Sum(x => x.Mennyiseg)));
            if (tamadoFelfedezok.Count() < bejovoFelfedezes.TamadoFelfedezok.Sum(x => x.Mennyiseg))
            {
                throw new ArgumentException(Resources.ErrorMessage.NotEnoughFelfedezo);
            }
            var tamadoKepesseg = tamadoFelfedezok.Cast<Felfedezo>()
                ?.Sum(x => x.KemkedesiKepesseg) ?? 0;
            if (vedoKepesseg < tamadoKepesseg)
            {
                var felfedezesDTO = new FelfedezesDTO
                {
                    FelfedezesEredmeny = FelfedezesEredmenyTipus.Sikeres,
                    TamadoOrszag = new OrszagDTO { Nev = tulajdonosOrszag.Nev },
                    VedekezoOrszag = new OrszagDTO { Nev = celpontOrszag.Nev },
                    VedekezoEro = celpontOrszag.OtthoniCsapats.SingleOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon).Egysegs.Sum(x => x.Vedekezes),
                    VedekezoGyongy = celpontOrszag.Gyongy,
                    VedekezoKorall = celpontOrszag.Korall,
                    Felfedezos = bejovoFelfedezes.TamadoFelfedezok

                };
                tulajdonosOrszag.Felfedezeses.Add(_mapper.Map<Felfedezes>(felfedezesDTO));
                await _context.SaveChangesAsync();
                return felfedezesDTO;
            }
            else
            {
                var felfedezesDTO = new FelfedezesDTO
                {
                    FelfedezesEredmeny = FelfedezesEredmenyTipus.Sikertelen,
                    TamadoOrszag = new OrszagDTO { Nev = tulajdonosOrszag.Nev },
                    VedekezoOrszag = new OrszagDTO { Nev = celpontOrszag.Nev },
                    Felfedezos = bejovoFelfedezes.TamadoFelfedezok
                };
                tulajdonosOrszag.Felfedezeses.Add(_mapper.Map<Felfedezes>(felfedezesDTO));
                tamadoFelfedezok.ToList().ForEach(y =>
                    {
                        tulajdonosOrszag.OtthoniCsapats
                            .SingleOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon).Egysegs
                            .Where(x => x.Discriminator == EgysegTipus.Felfedezo.ToString())
                            .ToList().RemoveAll(x=>x.Id == y.Id);
                    });

                await _context.SaveChangesAsync();
                return felfedezesDTO;
            }
        }
    }
}
