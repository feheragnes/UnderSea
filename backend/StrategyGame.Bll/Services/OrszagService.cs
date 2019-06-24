using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.DTOs.Epuletek;
using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class OrszagService : IOrszagService
    {
        private readonly StrategyGameContext _context;
        private readonly UserManager<StrategyGameUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEgysegService _egysegService;
        private readonly IEpuletService _epuletService;
        private readonly ICommonService _commonService;
        private readonly IGlobalService _globalService;

        public OrszagService(StrategyGameContext context,
                             UserManager<StrategyGameUser> userManager,
                             IMapper mapper,
                             IEgysegService egysegService,
                             IEpuletService epuletService,
                             ICommonService commonService,
                             IGlobalService globalService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _egysegService = egysegService;
            _epuletService = epuletService;
            _commonService = commonService;
            _globalService = globalService;
        }

        public async void MakeOrszagUserConnection(StrategyGameUser user, string orszagNev)
        {
            user.Orszag = await InitOrszag(orszagNev);
            await _context.SaveChangesAsync();
        }
        public async Task<Orszag> InitOrszag(string orszagNev)
        {
            var orszag = new Orszag { Nev = orszagNev, Korall = 0, Gyongy = 0 };
            if (_context.Orszags.FirstOrDefault(x => x.Nev.ToUpper() == orszagNev.ToUpper()) == null)
            {
                await _context.Orszags.AddAsync(orszag);
                await _context.SaveChangesAsync();
                return orszag;
            }
            throw new ArgumentException("Country already exists");
        }

        public async Task<OrszagDTO> GetUserOrszagInfos(Guid userId)
        {
            var orszag = await _commonService.GetCurrentOrszag(userId);
            return await Map(orszag);
        }
        public async Task<OrszagDTO> Map(Orszag orszag)
        {
            var orszagdto = new OrszagDTO
            {
                Id = orszag.Id,
                Gyongy = orszag.Gyongy,
                Nev = orszag.Nev,
                Korall = orszag.Korall,
                Helyezes = await GetHelyezes(orszag),
                GyongyTermeles = GetTermeles(orszag).Result.GyongyTermeles,
                KorallTermeles = GetTermeles(orszag).Result.KorallTermeles,
                SeregInfoDTOs = await GetSeregInfoDTOs(orszag),
                EpuletInfoDTOs = await GetEpuletInfoDTOs(orszag)
            };
            return orszagdto;
        }
        private async Task<long> GetHelyezes(Orszag orszag)
        {
            var sorted = await _globalService.GetRanglista();
            return (sorted.IndexOf(sorted.FirstOrDefault(x => x.Orszag == orszag.Nev))) + 1;
        }
        private async Task<OrszagDTO> GetTermeles(Orszag orszag)
        {
            var orszagDTO = new OrszagDTO();
            orszag = await _context.Orszags
                .Include(x => x.Epulets)
                .Include(x => x.Fejleszteses).FirstOrDefaultAsync(x => x.Id == orszag.Id);
            await orszag.Epulets.Where(e => e.Felepult == true).AsQueryable().ForEachAsync(async e =>
            {
                orszagDTO = await _mapper.Map<EpuletDTO>(e).SetTermeles(orszagDTO);
            });
            await orszag.Fejleszteses.Where(f => f.Kifejlesztve == true).AsQueryable().ForEachAsync(async f =>
            {
                orszagDTO = await _mapper.Map<FejlesztesDTO>(f).SetTermeles(orszagDTO);
            });


            return orszagDTO;
        }
        private async Task<IList<SeregInfoDTO>> GetSeregInfoDTOs(Orszag orszag)
        {
            return await _egysegService.GetOtthoniEgysegsAsync(orszag);
        }
        private async Task<IList<EpuletInfoDTO>> GetEpuletInfoDTOs(Orszag orszag)
        {
            return await _epuletService.GetFelepultEpuletsAsync(orszag);
        }
    }
}
