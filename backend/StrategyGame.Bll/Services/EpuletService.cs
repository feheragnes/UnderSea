using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;

using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class EpuletService : IEpuletService
    {
        private readonly StrategyGameContext _context;
        private readonly UserManager<StrategyGameUser> _userManager;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;


        public EpuletService(StrategyGameContext context, UserManager<StrategyGameUser> userManager, ICommonService commonService, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _commonService = commonService;
            _mapper = mapper;
        }


        public async Task<Epulet> GetEpuletByIdAsync(Guid id, Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            List<Epulet> currentEpulets = currentOrszag.Epulets.ToList();

            return currentEpulets.Find(x => x.Id == id);
        }

        public async Task<List<EpuletInfoDTO>> GetAllEpuletsFromOneUserAsync(Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            return _mapper.Map<List<EpuletInfoDTO>>(currentOrszag.Epulets.ToList());
        }


        public async Task<List<EpuletInfoDTO>> GetFelepultEpuletsFromOneUserAsync(Orszag currentOrszag)
        {
            List<Epulet> felepultEpulets = currentOrszag.Epulets.Where(x => x.Felepult == true).ToList();

            long aramlasIranyitoMennyiseg = 0;
            long zatonyVarMennyiseg = 0;
            long koBanyaMennyiseg = 0;

            felepultEpulets.ForEach(x =>
            {
                if (x is AramlasIranyito)
                {
                    aramlasIranyitoMennyiseg++;
                }

                if (x is ZatonyVar)
                {
                    zatonyVarMennyiseg++;
                }
                if(x is KoBanya)
                {
                    koBanyaMennyiseg++;
                }
            });

            List<EpuletInfoDTO> felepultDtoList = new List<EpuletInfoDTO>();

            felepultDtoList.Add(new EpuletInfoDTO(EpuletTipus.AramlasIranyito, 1000, aramlasIranyitoMennyiseg));
            felepultDtoList.Add(new EpuletInfoDTO(EpuletTipus.ZatonyVar, 1000, zatonyVarMennyiseg));
            felepultDtoList.Add(new EpuletInfoDTO(EpuletTipus.KobBanya, 1000, koBanyaMennyiseg));

            return felepultDtoList;
        }


        public async Task AddEpuletAsync(List<EpuletInfoDTO> epulets, Guid userId)
        {
            var currentOrszag = (await _context.Users
                                  .Include(x => x.Orszag)
                                  .ThenInclude(x => x.Epulets)
                                  .FirstOrDefaultAsync(x => x.Id == userId))
                                  .Orszag;

            List<Epulet> currentEpulets = currentOrszag.Epulets.ToList();

            currentEpulets.ForEach(x =>
            {
                if (x.Felepult == false)

                {
                    throw new InvalidOperationException(Resources.ErrorMessage.AnotherConstruction);
                }
            });

            long osszKoltseg = 0;
            long osszEpitoanyag = 0;

            var aramlasIranyitos = epulets.FindAll(e => e.Tipus == EpuletTipus.AramlasIranyito);
            var zatonyVars = epulets.FindAll(e => e.Tipus == EpuletTipus.ZatonyVar);
            var koBanyas = epulets.FindAll(e => e.Tipus == EpuletTipus.KobBanya);
            var epuletsToBuy = new List<Epulet>();

            aramlasIranyitos.ForEach(x =>
            {
                epuletsToBuy.Add(new AramlasIranyito());
            });
            zatonyVars.ForEach(x =>
            {
                epuletsToBuy.Add(new ZatonyVar());
            });
            koBanyas.ForEach(x =>
            {
                epuletsToBuy.Add(new KoBanya());
            });

            epuletsToBuy.ForEach(x =>
            {
                osszKoltseg += x.Ar;
                osszEpitoanyag += x.Epitoanyag;
            });

            if (osszKoltseg > currentOrszag.Gyongy)
            {
                throw new ArgumentException(Resources.ErrorMessage.NotEnoughPearl);
            }
            if(osszEpitoanyag > currentOrszag.Ko)
            {
                throw new ArgumentException(Resources.ErrorMessage.NotEnoughKo);
            }
            (currentOrszag.Epulets as List<Epulet>).AddRange(epuletsToBuy);
            currentOrszag.Gyongy -= osszKoltseg;
            currentOrszag.Ko -= osszEpitoanyag;

            _context.SaveChanges();
        }

        public async Task<long> GetEpuloAramlasiranyitoCout(Orszag currentOrszag)
        {
            return currentOrszag.Epulets.ToList().FindAll(x => x.Felepult == false && x is AramlasIranyito).Count();

        }
        public async Task<long> GetEpuloZatonyvarCount(Orszag currentOrszag)
        {
            return currentOrszag.Epulets.ToList().FindAll(x => x.Felepult == false && x is ZatonyVar).Count();
        }
    }
}
