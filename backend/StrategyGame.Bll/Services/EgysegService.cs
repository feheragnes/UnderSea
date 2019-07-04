using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class EgysegService : IEgysegService
    {
        private readonly StrategyGameContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonService _commonService;


        public EgysegService(StrategyGameContext context, IMapper mapper, ICommonService commonService)
        {
            _context = context;
            _mapper = mapper;
            _commonService = commonService;
        }
        public async Task AddEgysegAsync(List<SeregInfoDTO> egysegek, Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            var otthoniEgysegek = currentOrszag.OtthoniCsapats.FirstOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon);

            long osszKoltseg = 0;

            if (_context.EgysegTermelos
                .Include(x => x.Epulet).ThenInclude(x => x.Orszag)
                .Where(x => x.Epulet.Orszag.Id == currentOrszag.Id)
                .Where(x => x.Epulet.Felepult == true).Sum(x => x.Ertek) <
                (await GetAllEgysegsFromOneUserAsync(userId)).Count + egysegek.Sum(x => x.Mennyiseg))
            {
                throw new ArgumentException(Resources.ErrorMessage.NotEnoughHousing);
            }

            egysegek.ForEach(x =>
            {
                osszKoltseg += _context.EgysegInfos.SingleOrDefault(y => y.Tipus == x.Tipus && y.Szint == 1)?.Ar ?? 0 * x.Mennyiseg;
            });

            if (osszKoltseg > currentOrszag.Gyongy)
            {
                throw new ArgumentException(Resources.ErrorMessage.NotEnoughPearl);
            }

            var rohamFokaInfos = await _context.EgysegInfos.SingleOrDefaultAsync(x => x.Tipus == EgysegTipus.RohamFoka && x.Szint == 1);
            var csataCsikoInfos = await _context.EgysegInfos.SingleOrDefaultAsync(x => x.Tipus == EgysegTipus.CsataCsiko && x.Szint == 1);
            var lezerCapaInfos = await _context.EgysegInfos.SingleOrDefaultAsync(x => x.Tipus == EgysegTipus.LezerCapa && x.Szint == 1);
            var felfedezoInfos = await _context.EgysegInfos.SingleOrDefaultAsync(x => x.Tipus == EgysegTipus.Felfedezo);
            var hadvezerInfos = await _context.EgysegInfos.SingleOrDefaultAsync(x => x.Tipus == EgysegTipus.Hadvezer);
            egysegek.ForEach(async x =>
            {
                if (x.Tipus == EgysegTipus.RohamFoka)
                {
                    for (int i = 0; i < x.Mennyiseg; i++)
                    {
                        otthoniEgysegek.Egysegs.Add(new RohamFoka()
                        {
                            Ar = rohamFokaInfos.Ar,
                            Tamadas = rohamFokaInfos.Tamadas,
                            Vedekezes = rohamFokaInfos.Vedekezes,
                            Ellatas = rohamFokaInfos.Ellatas,
                            Zsold = rohamFokaInfos.Zsold,
                            CsatakSzama = rohamFokaInfos.CsatakSzama,
                            Szint = rohamFokaInfos.Szint

                        });
                    }

                }
                if (x.Tipus == EgysegTipus.CsataCsiko)
                {
                    for (int i = 0; i < x.Mennyiseg; i++)
                    {
                        otthoniEgysegek.Egysegs.Add(new CsataCsiko()
                        {
                            Ar = csataCsikoInfos.Ar,
                            Tamadas = csataCsikoInfos.Tamadas,
                            Vedekezes = csataCsikoInfos.Vedekezes,
                            Ellatas = csataCsikoInfos.Ellatas,
                            Zsold = csataCsikoInfos.Zsold,
                            CsatakSzama = csataCsikoInfos.CsatakSzama,
                            Szint = csataCsikoInfos.Szint
                        });
                    }

                }
                if (x.Tipus == EgysegTipus.LezerCapa)
                {
                    for (int i = 0; i < x.Mennyiseg; i++)
                    {
                        otthoniEgysegek.Egysegs.Add(new LezerCapa()
                        {
                            Ar = lezerCapaInfos.Ar,
                            Tamadas = lezerCapaInfos.Tamadas,
                            Vedekezes = lezerCapaInfos.Vedekezes,
                            Ellatas = lezerCapaInfos.Ellatas,
                            Zsold = lezerCapaInfos.Zsold,
                            CsatakSzama = lezerCapaInfos.CsatakSzama,
                            Szint = lezerCapaInfos.Szint
                        });
                    }

                }
                if (x.Tipus == EgysegTipus.Felfedezo)
                {
                    for (int i = 0; i < x.Mennyiseg; i++)
                    {
                        otthoniEgysegek.Egysegs.Add(new Felfedezo()
                        {
                            Ar = felfedezoInfos.Ar,
                            Tamadas = felfedezoInfos.Tamadas,
                            Vedekezes = felfedezoInfos.Vedekezes,
                            Ellatas = felfedezoInfos.Ellatas,
                            Zsold = felfedezoInfos.Zsold,
                            CsatakSzama = felfedezoInfos.CsatakSzama,
                            Szint = felfedezoInfos.Szint,
                            KemkedesiKepesseg = felfedezoInfos.KemkedesiKepesseg,
                            Felfedezett = false

                        }) ;
                    }

                }
                if (x.Tipus == EgysegTipus.Hadvezer)
                {
                    for (int i = 0; i < x.Mennyiseg; i++)
                    {
                        otthoniEgysegek.Egysegs.Add(new Hadvezer()
                        {
                            Ar = hadvezerInfos.Ar,
                            Tamadas = hadvezerInfos.Tamadas,
                            Vedekezes = hadvezerInfos.Vedekezes,
                            Ellatas = hadvezerInfos.Ellatas,
                            Zsold = hadvezerInfos.Zsold,
                            CsatakSzama = hadvezerInfos.CsatakSzama,
                            Szint = hadvezerInfos.Szint
                        });
                    }
                }
            });

            currentOrszag.Gyongy -= osszKoltseg;

            _context.SaveChanges();
        }


        public async Task<List<EgysegDTO>> GetAllEgysegsFromOneUserAsync(Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            List<Csapat> otthoniCsapats = new List<Csapat>(currentOrszag.OtthoniCsapats);
            List<Egyseg> egysegList = new List<Egyseg>();

            otthoniCsapats.ForEach(x =>
            {
                foreach (var egyseg in x.Egysegs)
                {
                    egysegList.Add(egyseg);
                }
            });

            var egysegDtoList = _mapper.Map<List<Egyseg>, List<EgysegDTO>>(egysegList);

            return egysegDtoList;
        }



        public async Task<List<SeregInfoDTO>> GetOtthoniEgysegsFromOneUserAsync(Orszag currentOrszag)
        {
            try
            {
                var otthoniEgysegek = currentOrszag.OtthoniCsapats?.SingleOrDefault(T => T.Celpont == null)?.Egysegs.GroupBy(e => new { e.Discriminator, e.Szint }).GroupBy(x=>x.Key.Szint);

                var seregInfoList = new List<SeregInfoDTO>();

                if (otthoniEgysegek != null)
                {
                    foreach (var egysegek in otthoniEgysegek)
                    {
                        foreach (var szint in egysegek) {
                            seregInfoList.Add(new SeregInfoDTO()
                            {
                                Ar = szint.Sum(e => e.Ar),
                                Mennyiseg = szint.Count(),
                                Tamadas = szint.Sum(e => e.Tamadas),
                                Vedekezes = szint.Sum(e => e.Vedekezes),
                                Tipus = Enum.Parse<EgysegTipus>(szint.FirstOrDefault().Discriminator),
                                Szint = szint.Key.Szint
                            });
                        }
                    }
                }
                return seregInfoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<EgysegInfoDTO>> GetEgysegInfoDTOs(Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            var egysegInfoDtos = new List<EgysegInfoDTO>();
            await _context.EgysegInfos.ForEachAsync(x =>
            {
                egysegInfoDtos.Add(_mapper.Map<EgysegInfoDTO>(x));
            });
            currentOrszag?.OtthoniCsapats
                .FirstOrDefault(x => x.Celpont == null)
                ?.Egysegs.ToList()
                .ForEach(x => egysegInfoDtos
                              .FirstOrDefault(y => y.Tipus == Enum.Parse<EgysegTipus>(x.GetType().Name))
                              .Mennyiseg++);
            return egysegInfoDtos;
        }

    }
}
;