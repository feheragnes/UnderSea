using StrategyGame.Bll.DTOs.AAADTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces
{
    public interface IRegistrationService
    {
        Task<object> Register(RegistrationDTO model);
    }
}
