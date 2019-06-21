using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
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

        public async Task AddEpuletAsync(List<EpuletInfoDTO> epulets, Orszag currentOrszag)
        {
            List<Epulet> epuletek = new List<Epulet>(currentOrszag.Epulets);

            long osszKoltseg = 0;
            foreach (var item in epulets)
            {
                osszKoltseg += (item.Ar * item.Mennyiseg);
            }

            if (osszKoltseg > currentOrszag.Gyongy)
                throw new ArgumentException("You don't have enough Gyöngy");

            for (int i = 0; i < epulets[0].Mennyiseg; i++)
            {
                epuletek.Add(new AramlasIranyito(1000,5,50,200));
            }

            for (int i = 0; i < epulets[1].Mennyiseg; i++)
            {
                epuletek.Add(new ZatonyVar(1000,5,200));
            }

            await SaveChangesAsync();
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
