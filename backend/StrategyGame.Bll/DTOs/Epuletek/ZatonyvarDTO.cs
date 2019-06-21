using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Epuletek
{
    public class ZatonyvarDTO : EpuletDTO, IEpulet
    {
        public long Szallas { get; set; }

        public async override Task<long> GetNepesseg()
        {
            return 0;
        }

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
