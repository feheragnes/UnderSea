using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs.Epuletek;
using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class GlobalService : IGlobalService
    {
        private readonly StrategyGameContext _context;
        private readonly IOrszagService _orszagService;
        private readonly IMapper _mapper;
        public GlobalService(StrategyGameContext context, IOrszagService orszagService, IMapper mapper)
        {
            _context = context;
            _orszagService = orszagService;
            _mapper = mapper;
        }
        public async Task<long> GetUserScore(ClaimsPrincipal userClaim)
        {
            var orszag = await _orszagService.GetUserOrszag(userClaim);
            var dict = await  GetOrszagScores();
            return dict.GetValueOrDefault(orszag.Nev);
        }
        public async Task<Dictionary<string,long>> GetOrszagScores()
        {
            Dictionary<string, long> dict = new Dictionary<string, long>();
            foreach (var user in _context.Users)
            {
                var orszag = await _orszagService.GetUserOrszag(user);
                long score = 0;
                foreach (var epulet in orszag.Epulets)
                {
                    var epuletDTO = _mapper.Map<EpuletDTO>(epulet);
                    if (epuletDTO.Felepult == true)
                    {
                        score += 50;
                    }
                    score += await epuletDTO.GetNepesseg();
                }
                foreach (var fejlesztes in orszag.Fejleszteses)
                {
                    var fejlesztesDTO = _mapper.Map<FejlesztesDTO>(fejlesztes);
                    if(fejlesztesDTO.Kifejlesztve == true)
                    {
                        score += 100;
                    }
                }
                dict.Add(orszag.Nev, score);
            }
            return dict;
        }
        public async Task<List<KeyValuePair<string, long>>> GetRanglista()
        {
            var dict =await GetOrszagScores();
            List<KeyValuePair<string, long>> sorted = (from kv in dict orderby kv.Value descending select kv).ToList();
            return sorted;
        }
        public async Task<long> GetHelyezes(ClaimsPrincipal userClaim)
        {
            var orszag = await _orszagService.GetUserOrszag(userClaim);
            var sorted = await GetRanglista();
            return (sorted.FindIndex(x => x.Key == orszag.Nev))+1;

        }

        public async Task<long> GetKor()
        {
            var jatek = await _context.Jateks.FirstOrDefaultAsync();
            return jatek.Korok;
        }
    }
}
