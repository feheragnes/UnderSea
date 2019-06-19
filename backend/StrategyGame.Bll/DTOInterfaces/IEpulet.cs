using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOInterfaces
{
    public interface IEpulet
    {
        Task NextTurn();
    }
}
