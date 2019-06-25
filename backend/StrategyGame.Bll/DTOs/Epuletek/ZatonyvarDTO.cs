using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Epuletek
{
    public class ZatonyvarDTO : EpuletDTO
    {
        public long Szallas { get; set; }
        public Task NextTurn()
        {
            throw new NotImplementedException();
        }
    }
}
