using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Hubs;
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
    public class EndTurnService : IEndTurnService
    {
        private readonly StrategyGameContext _context;
        private readonly IMapper _mapper;
        private readonly IOrszagService _orszagService;
        private readonly IHubContext<NextTurnHub> _hubContext;

        public EndTurnService(StrategyGameContext context, IMapper mapper, IOrszagService orszagService, IHubContext<NextTurnHub> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _orszagService = orszagService;
            _hubContext = hubContext;
        }

        public async Task DoFejleszteses()
        {
            await _context.Fejleszteses.ForEachAsync(x =>
            {
                if (++x.AktualisKor == x.SzuksegesKorok)
                {
                    x.Kifejlesztve = true;
                }
            });
            await _context.SaveChangesAsync();
        }
        public async Task DoEpulets()
        {
            await _context.Epulets.ForEachAsync(x =>
            {
                if (++x.AktualisKor == x.SzuksegesKorok)
                {
                    x.Felepult = true;
                }
            });
            await _context.SaveChangesAsync();
        }
        public async Task DoAdo()
        {
            await _context.Orszags.ForEachAsync(x => x.Gyongy += _orszagService.GetGyongyTermeles(x).Result);
            await _context.SaveChangesAsync();
        }
        public async Task DoKorall()
        {
            await _context.Orszags.ForEachAsync(x => x.Korall += _orszagService.GetKorallTermeles(x).Result);
            await _context.SaveChangesAsync();
        }
        public async Task DoZsold()
        {
            await _context.Orszags.Include(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs).ForEachAsync(x =>
                {
                    var otthoniCsapat = x.OtthoniCsapats.SingleOrDefault(y => y.Kimenetel == HarcEredmenyTipus.Otthon);
                    var osszKoltseg = otthoniCsapat.Egysegs.Sum(y => y.Zsold);
                    if (osszKoltseg < x.Gyongy)
                    {
                        x.Gyongy -= osszKoltseg;
                    }
                    else
                    {
                        while (x.Gyongy < osszKoltseg)
                        {
                            osszKoltseg -= otthoniCsapat.Egysegs.FirstOrDefault()?.Zsold ?? 0;
                            otthoniCsapat.Egysegs.Remove(otthoniCsapat.Egysegs.FirstOrDefault());
                        }
                    }
                });
        }
        public async Task DoEtetes()
        {
            await _context.Orszags.Include(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs).ForEachAsync(x =>
            {
                var otthoniCsapat = x.OtthoniCsapats.SingleOrDefault(y => y.Kimenetel == HarcEredmenyTipus.Otthon);
                var osszKoltseg = otthoniCsapat.Egysegs.Sum(y => y.Ellatas);
                if (osszKoltseg < x.Korall)
                {
                    x.Korall -= osszKoltseg;
                }
                else
                {
                    while (x.Korall < osszKoltseg)
                    {
                        osszKoltseg -= otthoniCsapat.Egysegs.FirstOrDefault()?.Ellatas ?? 0;
                        otthoniCsapat.Egysegs.Remove(otthoniCsapat.Egysegs.FirstOrDefault());
                    }
                }
            });
        }
        private double GetRandom()
        {
            var rand = new Random();
            return (rand.Next(0, 5) / 100) + 1;
        }
        private void DoHarcEredmeny(Csapat csapat)
        {
            var tamadas = csapat.Egysegs.Sum(x => x.Tamadas) * GetRandom() + _orszagService.GetTamadasBonusz(csapat.Tulajdonos).Result;
            var vedekezes = (csapat.Celpont.OtthoniCsapats
                .FirstOrDefault(y => y.Kimenetel == HarcEredmenyTipus.Otthon)
                .Egysegs?.Sum(y => y.Vedekezes) ?? 0) * GetRandom() + _orszagService.GetVedekezesBonusz(csapat.Celpont).Result;
            if (tamadas > vedekezes)
            {
                csapat.Kimenetel = HarcEredmenyTipus.Gyozelem;
                csapat.Tulajdonos.Gyongy += csapat.Celpont.Gyongy / 2;
                csapat.Tulajdonos.Korall += csapat.Celpont.Korall / 2;
                csapat.Celpont.Gyongy -= csapat.Celpont.Gyongy / 2;
                csapat.Celpont.Korall -= csapat.Celpont.Korall / 2;
                var ellenseg = csapat.Celpont.OtthoniCsapats.FirstOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon);
                for (int i = 0; i < Convert.ToInt64(ellenseg.Egysegs.Count * 0.1); i++)
                {
                    ellenseg.Egysegs.Remove(ellenseg.Egysegs.FirstOrDefault());
                }
            }
            else if (tamadas < vedekezes)
            {
                csapat.Kimenetel = HarcEredmenyTipus.Vereseg;
                for (int i = 0; i < Convert.ToInt64(csapat.Egysegs.Count * 0.1); i++)
                {
                    csapat.Egysegs.Remove(csapat.Egysegs.FirstOrDefault());
                }
            }
            else
            {
                csapat.Kimenetel = HarcEredmenyTipus.Dontetlen;
                for (int i = 0; i < Convert.ToInt64(csapat.Egysegs.Count * 0.05); i++)
                {
                    csapat.Egysegs.Remove(csapat.Egysegs.FirstOrDefault());
                }
                var ellenseg = csapat.Celpont.OtthoniCsapats.FirstOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon);
                for (int i = 0; i < Convert.ToInt64(ellenseg.Egysegs.Count * 0.05); i++)
                {
                    ellenseg.Egysegs.Remove(ellenseg.Egysegs.FirstOrDefault());
                }

            }
            var egysegs = new List<Egyseg>();
            csapat.Egysegs.ToList().ForEach(x =>
            {
                egysegs.Add((Egyseg)Activator.CreateInstance(x.GetType()));
                x.CsatakSzama++;

            });
            csapat.Tulajdonos.OtthoniCsapats.FirstOrDefault(x => x.Kimenetel == HarcEredmenyTipus.Otthon).Egysegs.AddRange(csapat.Egysegs);
            csapat.Egysegs.AddRange(egysegs);
            _context.SaveChanges();
        }
        public async Task DoHarc()
        {
            await _context.Orszags
                .Include(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs)
                .Include(x => x.OtthoniCsapats).ThenInclude(x => x.Celpont)
                .ThenInclude(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs)
                .Include(x => x.OtthoniCsapats).ThenInclude(x => x.Tulajdonos).ThenInclude(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs)
                .ForEachAsync(x =>
               {
                   foreach (var csapat in x.OtthoniCsapats.Where(y => y.Kimenetel == HarcEredmenyTipus.Folyamatban))
                   {
                       DoHarcEredmeny(csapat);
                   }
               });

        }

        public async Task DoLevelUp()
        {
            await _context.Egysegs.ForEachAsync(x =>
            {
                var egyseginfo = _context.EgysegInfos.Where(y => y.Tipus.ToString() == x.Discriminator);
                x.Szint = egyseginfo.SingleOrDefault(y => y.CsatakSzama == x.CsatakSzama)?.Szint ?? x.Szint;
                x.Tamadas = egyseginfo.SingleOrDefault(y => y.CsatakSzama == x.CsatakSzama)?.Tamadas ?? x.Tamadas;
                x.Vedekezes = egyseginfo.SingleOrDefault(y => y.CsatakSzama == x.CsatakSzama)?.Vedekezes ?? x.Vedekezes;
            });
            await _context.SaveChangesAsync();
        }
        public async Task NextTurn()
        {
            await DoAdo();
            await DoKorall();
            await DoZsold();
            await DoEtetes();
            await DoFejleszteses();
            await DoEpulets();
            await DoHarc();
            await DoLevelUp();
            await SetOrszagScores();
            (await _context.Jateks.FirstOrDefaultAsync()).Korok++;
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("NextTurn");

        }
        public async Task SetOrszagScores()
        {
            await _context.Orszags.Include(x => x.Epulets).Include(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs).Include(x => x.Fejleszteses).ForEachAsync(async x =>
                    {
                        x.Pont = 0;
                        x.Pont += await _context.NepessegTermelos
                        .Include(y => y.Epulet).ThenInclude(y => y.Orszag)
                        .Where(y => y.Epulet.Felepult == true)
                        .Where(y => y.Epulet.Orszag.Id == x.Id)
                        .SumAsync(y => y.Ertek)
                        + x.Epulets.Where(y => y.Felepult == true).Count() * 50
                        + x.OtthoniCsapats.Where(y => y.Celpont == null).SingleOrDefault()
                        .Egysegs.Where(y => y.Discriminator == Enum.GetName(typeof(EgysegTipus), EgysegTipus.LezerCapa)).Count() * 10
                        + x.OtthoniCsapats.Where(y => y.Celpont == null).SingleOrDefault()
                        .Egysegs.Where(y => y.Discriminator != Enum.GetName(typeof(EgysegTipus), EgysegTipus.LezerCapa)).Count() * 5
                        + x.Fejleszteses.Where(y => y.Kifejlesztve == true).Count() * 100;
                    });
            await _context.SaveChangesAsync();
        }
    }
}
