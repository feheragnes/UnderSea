using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IOrszagService
    {
        Task<OrszagUser> MakeOrszagUserConnection(StrategyGameUser user, string orszagnev);
        Task<Orszag> InitOrszag(string orszagnev);
    }
}
