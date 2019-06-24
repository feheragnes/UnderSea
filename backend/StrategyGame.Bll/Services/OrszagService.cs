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
    public class OrszagService: IOrszagService
    {
        private readonly StrategyGameContext _context;
        private readonly UserManager<StrategyGameUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEgysegService _egysegService;
        private readonly IEpuletService _epuletService;

        public OrszagService(StrategyGameContext context,
                             UserManager<StrategyGameUser> userManager, 
                             IMapper mapper, 
                             IEgysegService egysegService, 
                             IEpuletService epuletService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _egysegService = egysegService;
            _epuletService = epuletService;
        }

        public async Task<OrszagUser> MakeOrszagUserConnection(StrategyGameUser user, string orszagNev)
        {
            var orszaguser = new OrszagUser { User = user, Orszag = InitOrszag(orszagNev).Result };
            user.Orszags.Add(orszaguser);
            await _context.SaveChangesAsync();
            return orszaguser;
        }
        public  async Task<Orszag> InitOrszag(string orszagNev)
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
        public async Task<Orszag> GetUserOrszag(ClaimsPrincipal userClaim)
        {
            var user = await _userManager.GetUserAsync(userClaim);
            return _context.Users
                .Include(x => x.Orszags)
                .ThenInclude(x => x.Orszag)
                .ThenInclude(x => x.Fejleszteses)
                .Include(x => x.Orszags)
                .ThenInclude(x => x.Orszag)
                .ThenInclude(x => x.Epulets)
                .Include(x => x.Orszags)
                .ThenInclude(x => x.Orszag)
                .ThenInclude(x => x.OtthoniCsapats)
                .Include(x => x.Orszags)
                .ThenInclude(x => x.Orszag)
                .ThenInclude(x => x.TamadoCsapats)
                .FirstOrDefault(x => x.Id == user.Id)
                .Orszags
                .FirstOrDefault().Orszag;
        }
        public async Task<Orszag> GetUserOrszag(StrategyGameUser user)
        {
            return _context.Users
                .Include(x => x.Orszags)
                .ThenInclude(x => x.Orszag)
                .ThenInclude(x => x.Fejleszteses)
                .Include(x => x.Orszags)
                .ThenInclude(x => x.Orszag)
                .ThenInclude(x => x.Epulets)
                .Include(x => x.Orszags)
                .ThenInclude(x => x.Orszag)
                .ThenInclude(x => x.OtthoniCsapats)
                .Include(x => x.Orszags)
                .ThenInclude(x => x.Orszag)
                .ThenInclude(x => x.TamadoCsapats)
                .FirstOrDefault(x => x.Id == user.Id)
                .Orszags
                .FirstOrDefault().Orszag;
        }

        public async Task<OrszagDTO> GetUserOrszagInfos(ClaimsPrincipal userClaim)
        {
            var orszag = await GetUserOrszag(userClaim);
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
            return 0;
        }
        private async Task<OrszagDTO> GetTermeles(Orszag orszag)
        {
            orszag = _context.Orszags
                .Include(x => x.Epulets)
                .Include(x => x.Fejleszteses)
                .AsNoTracking().FirstOrDefault(x => x.Id == orszag.Id);
            var orszagDTO = new OrszagDTO();
            var epuletdtolist = _mapper.Map<IList<Epulet>, IList<EpuletDTO>>(orszag.Epulets);
            foreach (var item in epuletdtolist)
            {
                orszagDTO = await item.SetTermeles(orszagDTO);
            }
            var fejlesztesDTOList = _mapper.Map<IList<Fejlesztes>, IList<FejlesztesDTO>>(orszag.Fejleszteses);
            foreach (var item in fejlesztesDTOList)
            {
                orszagDTO = await item.SetTermeles(orszagDTO);
            }

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
