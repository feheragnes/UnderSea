using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.DTOEnums;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Epuletek;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Epulet> currentEpulets = currentOrszag.Epulets.ToList();
            currentEpulets.ForEach(x =>
            {
                if (x.Felepult == false)
                    throw new InvalidOperationException("Another building is under construction");
            });

            long osszKoltseg = 0;

            epulets.ForEach(x =>
            {
                osszKoltseg += (x.Ar * x.Mennyiseg);
            });

            if (osszKoltseg > currentOrszag.Gyongy)
                throw new ArgumentException("You don't have enough Gyöngy");

            var aramlasIranyitos = epulets.FindAll(e => e.Tipus == EpuletTipus.AramlasIranyito);
            var zatonyVars = epulets.FindAll(e => e.Tipus == EpuletTipus.ZatonyVar);

            aramlasIranyitos.ForEach(x =>
            {
                currentEpulets.Add(new AramlasIranyito());
            });
            zatonyVars.ForEach(x =>
            {
                currentEpulets.Add(new ZatonyVar());
            });

            currentOrszag.Gyongy -= osszKoltseg;
            await SaveChangesAsync();
        }

        public async Task<Epulet> GetEpuletByIdAsync(Guid id, Orszag currentOrszag)
        {
            List<Epulet> currentEpulets = currentOrszag.Epulets.ToList();

            return currentEpulets.Find(x => x.Id == id);
        }

        public async Task<List<Epulet>> GetAllEpuletsAsync(Orszag currentOrszag)
        {
            return currentOrszag.Epulets.ToList();
        }

        public async Task<List<EpuletInfoDTO>> GetFelepultEpuletsAsync(Orszag currentOrszag)
        {
            List<Epulet> felepultEpulets = currentOrszag.Epulets.Where(x => x.Felepult == true).ToList();

            long aramlasIranyitoMennyiseg = 0;
            long zatonyvarMennyiseg = 0;

            felepultEpulets.ForEach(x =>
            {
                if (x.GetType() == typeof(AramlasIranyito))
                    aramlasIranyitoMennyiseg++;
                if (x.GetType() == typeof(ZatonyVar))
                    zatonyvarMennyiseg++;
            });

            List<EpuletInfoDTO> felepultDtoList = new List<EpuletInfoDTO>();

            felepultDtoList.Add(new EpuletInfoDTO(EpuletTipus.AramlasIranyito, 1000, aramlasIranyitoMennyiseg));
            felepultDtoList.Add(new EpuletInfoDTO(EpuletTipus.ZatonyVar, 1000, zatonyvarMennyiseg));

            return felepultDtoList;
        }
        public async Task<bool> GetIfActiveConstruction(Orszag currentOrszag)
        {
            return currentOrszag.Epulets.FirstOrDefault(x => x.Felepult == false) != null;
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
