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

        public async Task MakeOrszagUserConnection(StrategyGameUser user, string orszagNev)
        {
            try
            {
                user.Orszag = await InitOrszag(orszagNev);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Orszag> InitOrszag(string orszagNev)
        {
            var orszag = new Orszag { Nev = orszagNev, Korall = 0, Gyongy = 1000 };
            orszag.Epulets.Add(new AramlasIranyito() { Felepult = true });
            orszag.OtthoniCsapats.Add(new Csapat() { Kimenetel = HarcEredmenyTipus.Otthon });
            if (_context.Orszags.FirstOrDefault(x => x.Nev.ToUpper() == orszagNev.ToUpper()) == null)
            {
                await _context.Orszags.AddAsync(orszag);
                return orszag;
            }
            throw new ArgumentException(Resources.ErrorMessage.AlreadyExistCountry);
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
                GyongyTermeles = await GetGyongyTermeles(orszag),
                KorallTermeles = await GetKorallTermeles(orszag),
                EpuloAramlasIranyito = await _epuletService.GetEpuloAramlasiranyitoCout(orszag),
                EpuloZatonyVar = await _epuletService.GetEpuloZatonyvarCount(orszag),
                SeregInfoDTOs = await GetSeregInfoDTOs(orszag),
                EpuletInfoDTOs = await GetEpuletInfoDTOs(orszag),
                TamadoBonusz = await GetTamadasBonusz(orszag),
                VedekezoBonusz = await GetVedekezesBonusz(orszag)
            };
            return orszagdto;
        }
        private async Task<long> GetHelyezes(Orszag orszag)
        {
            var sorted = await _globalService.GetRanglista();
            return (sorted.IndexOf(sorted.FirstOrDefault(x => x.Orszag == orszag.Nev))) + 1;
        }
        public async Task<long> GetKorallTermeles(Orszag orszag)
        {
            return Convert.ToInt64(Convert.ToDouble(await _context.KorallTermelos
                .Include(x => x.Epulet).ThenInclude(x => x.Orszag)
                .Where(x => x.Epulet.Orszag.Id == orszag.Id && x.Epulet.Felepult)
                .SumAsync(x => x.Ertek))
                * (Convert.ToDouble(await _context.KorallNovelos
                .Include(x => x.Fejlesztes).ThenInclude(x => x.Orszag)
                .Where(x => x.Fejlesztes.Orszag.Id == orszag.Id && x.Fejlesztes.Kifejlesztve)
                .SumAsync(x => x.Ertek) / 100.0) + 1));
        }
        public async Task<long> GetGyongyTermeles(Orszag orszag)
        {
            return Convert.ToInt64(Convert.ToDouble(await _context.NepessegTermelos
                 .Include(x => x.Epulet).ThenInclude(x => x.Orszag)
                 .Where(x => x.Epulet.Orszag.Id == orszag.Id)
                 .Where(x => x.Epulet.Felepult == true)
                 .SumAsync(x => x.Ertek) * 1)
                * (Convert.ToDouble(await _context.AdoNovelos
                .Include(x => x.Fejlesztes).ThenInclude(x => x.Orszag)
                .Where(x => x.Fejlesztes.Orszag.Id == orszag.Id)
                .Where(x => x.Fejlesztes.Kifejlesztve == true)
                .SumAsync(x => x.Ertek) / 100.0) + 1));
        }
        public async Task<long> GetTamadasBonusz(Orszag orszag)
        {
            return await _context.TamadasNovelos
                .Include(x => x.Fejlesztes).ThenInclude(x => x.Orszag)
                .Where(x => x.Fejlesztes.Orszag.Id == orszag.Id)
                .Where(x => x.Fejlesztes.Kifejlesztve == true)
                .SumAsync(x => x.Ertek);
        }
        public async Task<long> GetVedekezesBonusz(Orszag orszag)
        {
            return await _context.VedekezesNovelos
                .Include(x => x.Fejlesztes).ThenInclude(x => x.Orszag)
                .Where(x => x.Fejlesztes.Orszag.Id == orszag.Id)
                .Where(x => x.Fejlesztes.Kifejlesztve == true)
                .SumAsync(x => x.Ertek);
        }
        public async Task<TamadasDTO> GetTamadasDTO(Guid userId)
        {
            var orszag = await _commonService.GetCurrentOrszag(userId);
            var tamadasDto = new TamadasDTO
            {
                EllensegesOrszagok = await GetEllensegesOrszags(orszag),
                OtthoniEgysegek = await _egysegService.GetOtthoniEgysegsFromOneUserAsync(orszag)
            };
            return tamadasDto;
        }
        private async Task<IList<string>> GetEllensegesOrszags(Orszag orszag)
        {
            var list = new List<string>();
            await _context.Orszags.Where(x => x.Id != orszag.Id).ForEachAsync(x =>
                {
                    list.Add(x.Nev);
                });
            return list;
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
