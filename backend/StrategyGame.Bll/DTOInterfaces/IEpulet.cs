using StrategyGame.Bll.DTOs;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IEpulet
    {
        Task NextTurn();
        Task<OrszagDTO> SetTermeles(OrszagDTO orszag);
        Task<long> GetNepesseg();
    }
}
