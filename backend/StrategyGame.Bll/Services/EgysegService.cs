using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
            var otthoniEgysegek = currentOrszag.OtthoniCsapats.FirstOrDefault(T => T.Celpont == null);

            long osszKoltseg = 0;

            if(_context.EgysegTermelos
                .Include(x=>x.Epulet).ThenInclude(x=>x.Orszag)
                .Where(x=>x.Epulet.Orszag.Id == currentOrszag.Id)
                .Where(x=>x.Epulet.Felepult == true).Sum(x=>x.Ertek) < 
                (await GetAllEgysegsFromOneUserAsync(userId)).Count + egysegek.Sum(x => x.Mennyiseg))
            {
                throw new ArgumentException("You dont have enough Szallas");
            }

            egysegek.ForEach(async x =>
            {
                osszKoltseg += (await _context.EgysegInfos.SingleOrDefaultAsync(y=> y.Tipus == x.Tipus)).Ar*x.Mennyiseg;
            });

            if (osszKoltseg > currentOrszag.Gyongy)
                throw new ArgumentException("You don't have enough Gyöngy");

            var rohamFokaInfos = await _context.EgysegInfos.SingleOrDefaultAsync(x => x.Tipus == EgysegTipus.RohamFoka);
            var csataCsikoInfos = await _context.EgysegInfos.SingleOrDefaultAsync(x => x.Tipus == EgysegTipus.CsataCsiko);
            var lezerCapaInfos = await _context.EgysegInfos.SingleOrDefaultAsync(x => x.Tipus == EgysegTipus.LezerCapa);
            egysegek.ForEach(async x =>
            {
                if(x.Tipus == EgysegTipus.RohamFoka)
                {
                    for (int i = 0; i < x.Mennyiseg; i++)
                    {
                        otthoniEgysegek.Egysegs.Add(new RohamFoka()
                        {
                            Ar = rohamFokaInfos.Ar,
                            Tamadas = rohamFokaInfos.Tamadas,
                            Vedekezes = rohamFokaInfos.Vedekezes,
                            Ellatas = rohamFokaInfos.Ellatas,
                            Zsold = rohamFokaInfos.Zsold
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
                            Zsold = csataCsikoInfos.Zsold
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
                            Zsold = lezerCapaInfos.Zsold
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
                var otthoniEgysegek = currentOrszag.OtthoniCsapats?.SingleOrDefault(T => T.Celpont == null)?.Egysegs.GroupBy(e => e.Discriminator);

            var seregInfoList = new List<SeregInfoDTO>();

            if (otthoniEgysegek != null)
            {
                foreach (var egysegek in otthoniEgysegek)
                {
                    var egysegekDTO = _mapper.Map<List<EgysegDTO>>(egysegek.ToList());
                    seregInfoList.Add(new SeregInfoDTO()
                    {
                        Ar = egysegekDTO.Sum(e => e.Ar),
                        Mennyiseg = egysegekDTO.Count,
                        Tamadas = egysegekDTO.Sum(e => e.Tamadas),
                        Vedekezes = egysegek.Sum(e => e.Vedekezes),
                        Tipus = Enum.Parse<EgysegTipus>(egysegek.Key)
                    });
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

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception("Concurrency error");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
;