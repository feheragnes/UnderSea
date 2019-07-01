using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class GlobalService : IGlobalService
    {
        private readonly StrategyGameContext _context;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        public GlobalService(StrategyGameContext context, ICommonService commonService, IMapper mapper)
        {
            _context = context;
            _commonService = commonService;
            _mapper = mapper;
        }

        public async Task<long> GetUserScore(Guid userId)
        {
            var orszag = await _commonService.GetCurrentOrszag(userId);
            return orszag.Pont;
        }
        public async Task<IList<RanglistaDTO>> GetRanglista()
        {
            IList<RanglistaDTO> ranglista = new List<RanglistaDTO>();
            var i = 1;
            await _context.Orszags.OrderByDescending(x => x.Pont).ForEachAsync(x =>
           {
               ranglista.Add(new RanglistaDTO { Orszag = x.Nev, Pont = x.Pont, Helyezes = i });
               i++;
           });
            return ranglista;
        }

        public async Task<long> GetKor()
        {
            return (await _context.Jateks.FirstOrDefaultAsync()).Korok;
        }
    }
}
