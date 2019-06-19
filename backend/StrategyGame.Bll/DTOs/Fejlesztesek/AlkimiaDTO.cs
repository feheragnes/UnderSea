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

        public Task NextTurn()
        {
            throw new NotImplementedException();
        }
    }
}
