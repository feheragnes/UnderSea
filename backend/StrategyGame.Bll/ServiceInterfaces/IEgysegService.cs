using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IEgysegService
    {
        Task<List<Egyseg>> GetEgysegsAsync(Orszag currentOrszag);
        Task AddEgysegAsync(Egyseg e, Orszag currentOrszag);

        
    }
}
