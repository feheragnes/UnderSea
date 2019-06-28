using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using StrategyGame.Bll.DTOs.Epuletek;
using StrategyGame.Model.Enums;

namespace StrategyGame.Bll.Services
{
    public class EndTurnService : IEndTurnService
    {
        private readonly StrategyGameContext _context;
        private readonly IMapper _mapper;
        private readonly IOrszagService _orszagService;

        public EndTurnService(StrategyGameContext context, IMapper mapper, IOrszagService orszagService)
        {
            _context = context;
            _mapper = mapper;
            _orszagService = orszagService;
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
            await _context.Orszags.ForEachAsync(x => x.Gyongy +=  _orszagService.GetGyongyTermeles(x).Result);
            await _context.SaveChangesAsync();
        }
        public async Task DoKorall()
        {
            await _context.Orszags.ForEachAsync(x => x.Korall +=  _orszagService.GetKorallTermeles(x).Result);
            await _context.SaveChangesAsync();
        }
        public async Task DoZsold()
        {
            await _context.Orszags.Include(x => x.OtthoniCsapats).ThenInclude(x => x.Egysegs).ForEachAsync(x =>
                {
                    var otthoniCsapat = x.OtthoniCsapats.SingleOrDefault(y => y.Kimenetel == HarcEredmenyTipus.Otthon);
                    var osszKoltseg = otthoniCsapat.Egysegs.Sum(y => y.Zsold);
                    if(osszKoltseg < x.Gyongy)
                    {
                        x.Gyongy -= osszKoltseg;
                    }
                    else
                    {
                        while(x.Gyongy < osszKoltseg)
                        {
                            osszKoltseg -= otthoniCsapat.Egysegs.FirstOrDefault()?.Zsold ?? 0 ;
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
        public async Task DoHarc()
        {

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
            await SetOrszagScores();
            (await _context.Jateks.FirstOrDefaultAsync()).Korok++;
            await _context.SaveChangesAsync();
        }
        public async Task SetOrszagScores()
        {
            await _context.Orszags.Include(x=>x.Epulets).Include(x=>x.OtthoniCsapats).ThenInclude(x=>x.Egysegs).Include(x=>x.Fejleszteses).ForEachAsync(async x =>
            {
                x.Pont = 0;
                x.Pont += await _context.NepessegTermelos
                .Include(y => y.Epulet).ThenInclude(y => y.Orszag)
                .Where(y => y.Epulet.Felepult == true)
                .Where(y => y.Epulet.Orszag.Id == x.Id)
                .SumAsync(y => y.Ertek) 
                + x.Epulets.Where(y=>y.Felepult==true).Count() * 50
                + x.OtthoniCsapats.Where(y=>y.Celpont == null).SingleOrDefault()
                .Egysegs.Where(y=>y.Discriminator == Enum.GetName(typeof(EgysegTipus),EgysegTipus.LezerCapa)).Count() *10
                + x.OtthoniCsapats.Where(y => y.Celpont == null).SingleOrDefault()
                .Egysegs.Where(y => y.Discriminator != Enum.GetName(typeof(EgysegTipus), EgysegTipus.LezerCapa)).Count() * 5
                + x.Fejleszteses.Count *100;               
            });
            await _context.SaveChangesAsync();
        }
    }
}
