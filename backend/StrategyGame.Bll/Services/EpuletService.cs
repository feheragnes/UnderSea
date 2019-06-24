using AutoMapper;
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
        private readonly IMapper _mapper;

        public EpuletService(StrategyGameContext context, UserManager<StrategyGameUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
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
                epuletek.Add(new AramlasIranyito {Ar = 1000, SzuksegesKorok =5 , Nepesseg= 50, Korall=200  });
            }

            for (int i = 0; i < epulets[1].Mennyiseg; i++)
            {
                epuletek.Add(new ZatonyVar { Ar = 1000, SzuksegesKorok = 5, Szallas = 200 });
            }

            await SaveChangesAsync();
        }



        public async Task<Epulet> GetEpuletByIdAsync(Guid id, Orszag currentOrszag)
        {
            
            List<Epulet> currentEpulets = new List<Epulet>(currentOrszag.Epulets);

            return currentEpulets.Find(x => x.Id == id);
        }

        public async Task<List<Epulet>> GetAllEpuletsAsync(Orszag currentOrszag)
        {

            var epulets = currentOrszag.Epulets;

            List<Epulet> currentEpulets = new List<Epulet>(currentOrszag.Epulets);

            return currentEpulets;
        }

        public async Task<IList<EpuletInfoDTO>> GetFelepultEpuletsAsync(Orszag currentOrszag)
        {
            List<Epulet> epulets = new List<Epulet>(currentOrszag.Epulets);
            List<Epulet> felepultEpulets  = new List<Epulet>();
            foreach (var epulet in epulets)
            {
                if (epulet.Felepult)
                    felepultEpulets.Add(epulet);
            }

            long aramlasIranyitoMennyiseg = 0;
            long zatonyvarMennyiseg = 0;


            foreach (var item in felepultEpulets)
                {
                    if (item.GetType() == typeof(AramlasIranyito))
                        aramlasIranyitoMennyiseg++;
                    if (item.GetType() == typeof(ZatonyVar))
                        zatonyvarMennyiseg++;
                }
            

            List<EpuletInfoDTO> felepultDtoList = new List<EpuletInfoDTO>();
            felepultDtoList.Add(new EpuletInfoDTO("AramlasIranyito", 1000, aramlasIranyitoMennyiseg));
            felepultDtoList.Add(new EpuletInfoDTO("ZatonyVar", 1000, zatonyvarMennyiseg));

         
            return felepultDtoList;
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
