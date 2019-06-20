using StrategyGame.Bll.DTOs.AAADTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces
{
    public interface ILoginService
    {
        Task<string> Login(LoginDTO model);
    }
}
