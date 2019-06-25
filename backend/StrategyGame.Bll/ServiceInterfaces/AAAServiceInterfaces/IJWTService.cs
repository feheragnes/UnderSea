using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces
{
    public interface IJWTService
    {
        Task<string> GenerateJwtToken(string email, StrategyGameUser user);
    }
}
