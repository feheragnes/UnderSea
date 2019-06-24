using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOInterfaces
{
    interface IEndTurnService
    {
        Task DoFejleszteses();
        void SetOrszagScores();
    }
}
