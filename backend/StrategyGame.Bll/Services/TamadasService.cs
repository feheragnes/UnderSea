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
            var seregList = new List<SeregInfoDTO>();
            egysegs.GroupBy(x => x.Discriminator).ToList()?.ForEach(x =>
              {
                  seregList.Add(new SeregInfoDTO { Tipus = Enum.Parse<EgysegTipus>(x.Key), Mennyiseg = x.Count() });
              });
            return seregList;

        }
        public async Task<List<HarcDTO>> GetHarcStatus(Guid userId)
        {
            var orszag = await _commonService.GetCurrentOrszag(userId);
            var harcok = new List<HarcDTO>();

            orszag.OtthoniCsapats.Where(x => x.Kimenetel != HarcEredmenyTipus.Otthon).ToList()?.ForEach( x =>
            {
                harcok.Add(new HarcDTO { VedezoOrszag = new OrszagDTO { Nev = x.Celpont.Nev}, HarcEredmeny = x.Kimenetel, TamadoCsapat = GetSeregFromEgysegs(x.Egysegs)});
            });
            return harcok; 

        }
        public async Task SetHarcEredmeny(CsapatDTO csapatDto)
        {
            csapatDto.Kimenetel = csapatDto.TamadoEro > csapatDto.VedekezoEro ? HarcEredmenyTipus.Tulajdonos : HarcEredmenyTipus.Celpont;
        }
        public async Task SetVeszteseg(CsapatDTO csapatDto)
        {
            if (csapatDto.Kimenetel == HarcEredmenyTipus.Tulajdonos)
            {
                (csapatDto.VedekezoEgysegs as List<SeregInfoDTO>).ForEach(x =>
                {
                    x.Mennyiseg -= Convert.ToInt64(Convert.ToDouble(x.Mennyiseg) / 10);
                });
            }
            else
            {
                (csapatDto.TamadoEgysegs as List<SeregInfoDTO>).ForEach(x =>
                {
                    x.Mennyiseg -= Convert.ToInt64(Convert.ToDouble(x.Mennyiseg) / 10);
                });
            }
        }
        public async Task SetRablas(CsapatDTO csapatDto)
        {
            if (csapatDto.Kimenetel == HarcEredmenyTipus.Tulajdonos)
            {
                csapatDto.Celpont.Korall -= csapatDto.Celpont.Korall / 2;
                csapatDto.Celpont.Gyongy -= csapatDto.Celpont.Gyongy / 2;
                csapatDto.Tulajdonos.Korall += csapatDto.Tulajdonos.Korall / 2;
                csapatDto.Tulajdonos.Gyongy -= csapatDto.Tulajdonos.Gyongy / 2;
            }
        }
        public async Task<CsapatDTO> SetTamadas(CsapatDTO csapatDto)
        {
            await SetHarcEredmeny(csapatDto);
            await SetVeszteseg(csapatDto);
            await SetRablas(csapatDto);
            return csapatDto;
        }
        public async Task SetTamadasModel(CsapatDTO csapatDto)
        {
            var tamadocsapat = await _context.Csapats.Include(x => x.Celpont).ThenInclude(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs)
                .Include(x => x.Tulajdonos).ThenInclude(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs).SingleOrDefaultAsync(x => x.Id == csapatDto.Id);
            var vedekezocsapat = tamadocsapat.Celpont.OtthoniCsapats.SingleOrDefault(x => x.Celpont == null);
            tamadocsapat.Tulajdonos.Gyongy = csapatDto.Tulajdonos.Gyongy;
            tamadocsapat.Tulajdonos.Korall = csapatDto.Tulajdonos.Korall;
            tamadocsapat.Celpont.Gyongy = csapatDto.Celpont.Gyongy;
            tamadocsapat.Celpont.Korall = csapatDto.Celpont.Korall;
            tamadocsapat.Kimenetel = csapatDto.Kimenetel == HarcEredmenyTipus.Tulajdonos ? HarcEredmenyTipus.Gyozelem : HarcEredmenyTipus.Vereseg;
            (csapatDto.TamadoEgysegs as List<SeregInfoDTO>).ForEach(x =>
            {
                for (int i = 0; i < x.Mennyiseg; i++)
                {
                    if (x.Tipus == EgysegTipus.CsataCsiko)
                        tamadocsapat.Egysegs.Add(new CsataCsiko());
                    if (x.Tipus == EgysegTipus.LezerCapa)
                        tamadocsapat.Egysegs.Add(new LezerCapa());
                    if (x.Tipus == EgysegTipus.RohamFoka)
                        tamadocsapat.Egysegs.Add(new RohamFoka());
                }
            });
            vedekezocsapat.Egysegs.Clear();
            (csapatDto.VedekezoEgysegs as List<SeregInfoDTO>).ForEach(x =>
            {
                for (int i = 0; i < x.Mennyiseg; i++)
                {
                    if (x.Tipus == EgysegTipus.CsataCsiko)
                        vedekezocsapat.Egysegs.Add(new CsataCsiko());
                    if (x.Tipus == EgysegTipus.LezerCapa)
                        vedekezocsapat.Egysegs.Add(new LezerCapa());
                    if (x.Tipus == EgysegTipus.RohamFoka)
                        vedekezocsapat.Egysegs.Add(new RohamFoka());
                }
            });
            await _context.SaveChangesAsync();
        }
        public async Task Tamadas()
        {
            await _context.Orszags.Include(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs).ForEachAsync(async x =>
                {
                    ((x.OtthoniCsapats as List<Csapat>).Where(y => y.Celpont != null) as List<Csapat>).ForEach(async y =>
                  {
                        await SetTamadasModel(await SetTamadas(_mapper.Map<CsapatDTO>(y)));
                    });
                });
        }
        public async Task MakeTamadas(BejovoTamadasDTO bejovoTamadasDTO, Guid userId)
        {
            var tamadoorszag = await _commonService.GetCurrentOrszag(userId);
            bejovoTamadasDTO.TamadoNev = tamadoorszag.Nev;
            if (tamadoorszag.OtthoniCsapats.Where(x=>x.Celpont?.Nev == bejovoTamadasDTO.CelpontNev && x.Kimenetel == HarcEredmenyTipus.Folyamatban).Count() > 0)
            {
                throw new ArgumentException($"{bejovoTamadasDTO.CelpontNev} országot már támadtad ebben a körben!");
            }
            var csapat0 = tamadoorszag.OtthoniCsapats.SingleOrDefault(x => x.Celpont == null);
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

                        if (egysegszam > csapat0.Egysegs.Where(y=> Enum.Parse<EgysegTipus>(y.Discriminator) == x.Tipus).Count())
                        {
                            throw new ArgumentException($"Nincs elég {x.Tipus} egységed!");
                        }
                        csapat0.Egysegs.Remove(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.CsataCsiko)));
                        tamadocsapat.Egysegs.Add(new CsataCsiko());
                        egysegszam--;
                    }
                    if (x.Tipus == EgysegTipus.LezerCapa)
                    {
                        if (egysegszam > csapat0.Egysegs.Where(y => Enum.Parse<EgysegTipus>(y.Discriminator) == x.Tipus).Count())
                        {
                            throw new ArgumentException($"Nincs elég {x.Tipus} egységed!");
                        }
                        csapat0.Egysegs.Remove(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.LezerCapa)));
                        tamadocsapat.Egysegs.Add(new LezerCapa());
                        egysegszam--;
                    }
                    if (x.Tipus == EgysegTipus.RohamFoka)
                    {
                        if (egysegszam > csapat0.Egysegs.Where(y => Enum.Parse<EgysegTipus>(y.Discriminator) == x.Tipus).Count())
                        {
                            throw new ArgumentException($"Nincs elég {x.Tipus} egységed!");
                        }
                        csapat0.Egysegs.Remove(csapat0.Egysegs.FirstOrDefault(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.RohamFoka)));
                        tamadocsapat.Egysegs.Add(new RohamFoka());
                        egysegszam--;
                    }
                }
            });
            tamadoorszag.OtthoniCsapats.Add(tamadocsapat);
            await _context.SaveChangesAsync();
        }
    }
}
