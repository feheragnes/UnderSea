using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Fejlesztesek
{
    public class AlkimiaDTO : FejlesztesDTO, IFejlesztes
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
            var tmp = (double)orszag.GyongyTermeles;
            tmp *= Noveles / 100;
            orszag.GyongyTermeles = Convert.ToInt64(Math.Round(tmp));
            return orszag;
        }
    }
}
