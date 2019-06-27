using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOInterfaces;
using StrategyGame.Dal.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using StrategyGame.Bll.DTOs.Epuletek;

namespace StrategyGame.Bll.Services
{
    class EndTurnService : IEndTurnService
    {
        private readonly StrategyGameContext _context;
        private readonly IMapper _mapper;

        public EndTurnService(StrategyGameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task DoFejleszteses()
        {
            throw new NotImplementedException();
        }

        public async Task SetOrszagScores()
        {

        }
    }
}
