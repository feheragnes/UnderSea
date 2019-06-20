using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Epuletek;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    class EpuletService : IEpuletService
    {

        private readonly StrategyGameContext _context;
        private readonly UserManager<StrategyGameUser> _userManager;

        public EpuletService(StrategyGameContext context, UserManager<StrategyGameUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task AddEpuletAsync(Epulet e, ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);

            var currentOrszag = _context.Orszags.Include(x => x.Epulets).SingleOrDefaultAsync().Result.Epulets;


            throw new NotImplementedException();
        }

        public Task<Epulet> GetEpuletByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Epulet>> GetEpuletsAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
