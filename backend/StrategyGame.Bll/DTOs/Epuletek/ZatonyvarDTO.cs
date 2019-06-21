using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Epuletek
{
    class ZatonyvarDTO : EpuletDTO, IEpulet
    {
        public long Szallas { get; set; }
        public Task NextTurn()
        {
            throw new NotImplementedException();
        }

        public async override Task<OrszagDTO> SetTermeles(OrszagDTO orszag)
        {
            return orszag;
        }
    }
}
