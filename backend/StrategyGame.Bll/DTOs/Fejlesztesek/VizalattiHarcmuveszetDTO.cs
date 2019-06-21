using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Fejlesztesek
{
    class VizalattiHarcmuveszetDTO : FejlesztesDTO, IFejlesztes
    {
        public Task Increase()
        {
            throw new NotImplementedException();
        }

        public override Task NextTurn()
        {
            throw new NotImplementedException();
        }

        public async override Task<OrszagDTO> SetTermeles(OrszagDTO orszag)
        {
            return orszag;
        }
    }
}
