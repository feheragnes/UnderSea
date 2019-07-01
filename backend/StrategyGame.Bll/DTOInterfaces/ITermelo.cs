using StrategyGame.Bll.DTOs;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface ITermelo
    {
        Task<OrszagDTO> SetTermeles(OrszagDTO orszag);
    }
}
