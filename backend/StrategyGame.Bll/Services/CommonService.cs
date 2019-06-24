using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class CommonService : ICommonService
    {
        private readonly StrategyGameContext _context;

        public CommonService(StrategyGameContext strategyGameContext)
        {
            _context = strategyGameContext;
        }
        public async Task<Orszag> GetCurrentOrszag(Guid userId)
        {
            return (await _context.Users
                                  .Include(x => x.Orszag)
                                  .ThenInclude(x => x.Fejleszteses)
                                  .Include(x => x.Orszag)
                                  .ThenInclude(x => x.Epulets)
                                  .Include(x => x.Orszag)
                                  .ThenInclude(x => x.OtthoniCsapats)
                                  .Include(x => x.Orszag)
                                  .ThenInclude(x => x.TamadoCsapats)
                                  .FirstOrDefaultAsync(x => x.Id == userId))
                                  .Orszag;

        }
    }
}
