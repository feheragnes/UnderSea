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
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class TamadasService : ITamadasService
    {
        private readonly StrategyGameContext _context;
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;

        public TamadasService(StrategyGameContext context,
            IOrszagService orszagService,
            ICommonService commonService,
            IMapper mapper)
        {
            _context = context;
            _orszagService = orszagService;
            _commonService = commonService;
            _mapper = mapper;
        }
        public List<SeregInfoDTO> GetSeregFromEgysegs(List<Egyseg> egysegs)
        {
            try
            {
                var egysegGroup = egysegs.GroupBy(e => new { e.Discriminator, e.Szint }).GroupBy(x => x.Key.Szint);

                var seregInfoList = new List<SeregInfoDTO>();

                if (egysegGroup != null)
                {
                    foreach (var egysegek in egysegGroup)
                    {
                        foreach (var szint in egysegek)
                        {
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
        public async Task<List<HarcDTO>> GetHarcStatus(Guid userId)
        {
            var orszag = await _commonService.GetCurrentOrszag(userId);
            var harcok = new List<HarcDTO>();

            orszag.OtthoniCsapats.Where(x => x.Kimenetel != HarcEredmenyTipus.Otthon).ToList()?.ForEach(x =>
           {
               harcok.Add(new HarcDTO
               {
                   VedezoOrszag = new OrszagDTO { Nev = x.Celpont.Nev },
                   HarcEredmeny = x.Kimenetel,
                   TamadoCsapat = GetSeregFromEgysegs(x.Egysegs),
                   VedekezoCsapat = GetSeregFromEgysegs(x.VedekezoEgysegs),
                   TamadoOrszag = new OrszagDTO { Nev = x.Tulajdonos.Nev },
                   RaboltKorall = x.RaboltKorall,
                   RaboltGyongy = x.RaboltGyongy
               });
           });
            return harcok;

        }

        public async Task MakeTamadas(BejovoTamadasDTO bejovoTamadasDTO, Guid userId)
        {
            var tamadoorszag = await _commonService.GetCurrentOrszag(userId);
            bejovoTamadasDTO.TamadoNev = tamadoorszag.Nev;
            if (tamadoorszag.OtthoniCsapats.Where(x => x.Celpont?.Nev == bejovoTamadasDTO.CelpontNev && x.Kimenetel == HarcEredmenyTipus.Folyamatban).Count() > 0)
            {
                throw new ArgumentException(Resources.ErrorMessage.AlreadyAttackedCountry);
            }
            var csapat0 = tamadoorszag.OtthoniCsapats.SingleOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon);
            var tamadocsapat = new Csapat()
            {
                Celpont = _context.Orszags.SingleOrDefault(x => x.Nev == bejovoTamadasDTO.CelpontNev),
                Kimenetel = HarcEredmenyTipus.Folyamatban,
                Tulajdonos = tamadoorszag
            };
            bejovoTamadasDTO.TamadoEgysegek.ForEach(x =>
            {
                var egysegszam = x.Mennyiseg;
                for (int i = 0; i < x.Mennyiseg; i++)
                {
                    if (x.Tipus == EgysegTipus.CsataCsiko)
                    {

                        if (egysegszam > csapat0.Egysegs.Where(y => Enum.Parse<EgysegTipus>(y.Discriminator) == x.Tipus && y.Szint == x.Szint).Count())
                        {
                            throw new ArgumentException(Resources.ErrorMessage.NotEnougCsataCsiko);
                        }
                        tamadocsapat.Egysegs.Add(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.CsataCsiko) && y.Szint == x.Szint));
                        csapat0.Egysegs.Remove(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.CsataCsiko) && y.Szint == x.Szint));
                        egysegszam--;
                    }
                    if (x.Tipus == EgysegTipus.LezerCapa)
                    {
                        if (egysegszam > csapat0.Egysegs.Where(y => Enum.Parse<EgysegTipus>(y.Discriminator) == x.Tipus && y.Szint == x.Szint).Count())
                        {
                            throw new ArgumentException(Resources.ErrorMessage.NotEnougLezerCapa);
                        }
                        tamadocsapat.Egysegs.Add(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.LezerCapa) && y.Szint == x.Szint));
                        csapat0.Egysegs.Remove(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.LezerCapa) && y.Szint == x.Szint));
                        egysegszam--;
                    }
                    if (x.Tipus == EgysegTipus.RohamFoka)
                    {
                        if (egysegszam > csapat0.Egysegs.Where(y => Enum.Parse<EgysegTipus>(y.Discriminator) == x.Tipus && y.Szint == x.Szint).Count())
                        {
                            throw new ArgumentException(Resources.ErrorMessage.NotEnougRohamFoka);
                        }
                        tamadocsapat.Egysegs.Add(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.RohamFoka) && y.Szint == x.Szint));
                        csapat0.Egysegs.Remove(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.RohamFoka) && y.Szint == x.Szint));
                        egysegszam--;
                    }
                }
            });
            tamadoorszag.OtthoniCsapats.Add(tamadocsapat);
            await _context.SaveChangesAsync();
        }
    }
}
