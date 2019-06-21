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
     public class EpuletService : IEpuletService
    {

        private readonly StrategyGameContext _context;
        private readonly UserManager<StrategyGameUser> _userManager;

        public EpuletService(StrategyGameContext context, UserManager<StrategyGameUser> userManager)
        {
     
            _context = context;
            _userManager = userManager;
        }

        public async Task AddEpuletAsync(Epulet e, Orszag currentOrszag)
        {

            currentOrszag.Epulets.Add(e);

            SaveChangesAsync();
        }



        public async Task<Epulet> GetEpuletByIdAsync(Guid id, Orszag currentOrszag)
        {
            
            List<Epulet> currentEpulets = new List<Epulet>(currentOrszag.Epulets);

            return currentEpulets.Find(x => x.Id == id);
        }

        public async Task<List<Epulet>> GetEpuletsAsync(Orszag currentOrszag)
        {

            var epulets = currentOrszag.Epulets;

            List<Epulet> currentEpulets = new List<Epulet>(currentOrszag.Epulets);

            return currentEpulets;
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
