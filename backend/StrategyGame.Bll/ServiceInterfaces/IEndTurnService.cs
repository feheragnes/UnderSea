using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IEndTurnService
    {
        Task DoFejleszteses();
        Task SetOrszagScores();
        Task NextTurn();
    }
}
