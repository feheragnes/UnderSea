using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class EgysegService : IEgysegService
    {
        private readonly StrategyGameContext _context;
        private readonly UserManager<StrategyGameUser> _userManager;

        public EgysegService(StrategyGameContext context, UserManager<StrategyGameUser> userManager)
        {

            _context = context;
            _userManager = userManager;
        }
        public async Task AddEgysegAsync(Egyseg e, Orszag currentOrszag)
        {

            List<Csapat> otthoniCsapatok = new List<Csapat>(currentOrszag.OtthoniCsapats);

            otthoniCsapatok.Find(T => T.Celpont == null).Egysegs.Add(e);
        }

        public Task<List<Egyseg>> GetEgysegsAsync(Orszag currentOrszag)
        {
            throw new NotImplementedException();
        }
    }
}
;