using StrategyGame.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface ITermelo
    {
        Task<OrszagDTO> SetTermeles(OrszagDTO orszag);
    }
}
