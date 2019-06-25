using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOInterfaces;
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
            try
            {
                user.Orszag = await InitOrszag(orszagNev);
                await _context.SaveChangesAsync();
            } catch (Exception e)
            {
                throw e;
            }
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
                GyongyTermeles = (await GetTermeles(orszag)).GyongyTermeles,
                KorallTermeles = (await GetTermeles(orszag)).KorallTermeles,
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
        private async Task<long> GetKorallTermeles(Orszag orszag)
        {
            return await _context.KorallTermelos
                .Include(x => x.Epulet).ThenInclude(x => x.Orszag)
                .Where(x => x.Epulet.Orszag.Id == orszag.Id)
                .SumAsync(x => x.Ertek);
        }
        private async Task<OrszagDTO> GetTermeles(Orszag orszag)
        {
            var orszagDTO = new OrszagDTO();
            orszag = await _context.Orszags
                .Include(x => x.Epulets)
                .Include(x => x.Fejleszteses).FirstOrDefaultAsync(x => x.Id == orszag.Id);
            orszag.Epulets.Where(e => e.Felepult == true).ToList().ForEach(async e =>
            {
                var ep =  _mapper.Map<EpuletDTO>(e);
                if (ep is ITermelo)
                {
                    orszagDTO = await (ep as ITermelo).SetTermeles(orszagDTO);
                }
            });
            orszag.Fejleszteses.Where(f => f.Kifejlesztve == true).ToList().ForEach(async f =>
            {
                var fe = _mapper.Map<FejlesztesDTO>(f);
                if (fe is ITermelo)
                {
                    orszagDTO = await (fe as ITermelo).SetTermeles(orszagDTO);
                }
            });


            return orszagDTO;
        }
        private async Task<IList<SeregInfoDTO>> GetSeregInfoDTOs(Orszag orszag)
        {
            return await _egysegService.GetOtthoniEgysegsFromOneUserAsync(orszag);
        }
        private async Task<IList<EpuletInfoDTO>> GetEpuletInfoDTOs(Orszag orszag)
        {
            return await _epuletService.GetFelepultEpuletsFromOneUserAsync(orszag);
        }
    }
}
