using StrategyGame.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOInterfaces
{
    public interface IFejlesztes
    {
        Task<OrszagDTO> SetTermeles(OrszagDTO orszag);
        Task Increase();

        Task NextTurn();
    }


}
