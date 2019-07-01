using StrategyGame.Bll.DTOs;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IFejlesztes
    {
        Task<OrszagDTO> SetTermeles(OrszagDTO orszag);
        Task Increase();

        Task NextTurn();
    }


}
