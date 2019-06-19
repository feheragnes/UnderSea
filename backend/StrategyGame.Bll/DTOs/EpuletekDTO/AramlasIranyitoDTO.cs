using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.EpuletDTO
{
    class AramlasIranyitoDTO : EpuletDTO, IEpulet
    {
        public Task NextTurn()
        {
            throw new NotImplementedException();
        }
    }
}
