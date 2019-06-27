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

        public EndTurnService(StrategyGameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task DoFejleszteses()
        {
            throw new NotImplementedException();
        }

        public async Task NextTurn()
        {
            await SetOrszagScores();
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
