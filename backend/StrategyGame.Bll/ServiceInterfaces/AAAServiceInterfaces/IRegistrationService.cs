using StrategyGame.Bll.DTOs.AAADTOs;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces
{
    public interface IRegistrationService
    {
        Task<string> Register(RegistrationDTO model);
    }
}
