using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Fejlesztesek
{
    class IszapTraktorDTO : FejlesztesDTO, IFejlesztes
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
            var tmp = (double)orszag.KorallTermeles;
            tmp *= Noveles / 100;
            orszag.KorallTermeles = Convert.ToInt64(Math.Round(tmp));
            return orszag;
        }
    }
}
