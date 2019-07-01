using StrategyGame.Model.Entities.Identity;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces
{
    public interface IJWTService
    {
        Task<string> GenerateJwtToken(string email, StrategyGameUser user);
    }
}
