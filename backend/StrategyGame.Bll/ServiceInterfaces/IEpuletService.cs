using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Epuletek;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IEpuletService
    {
        Task<List<Epulet>> GetEpuletsAsync(Orszag currentOrszag);
        Task<Epulet> GetEpuletByIdAsync(Guid id, Orszag currentOrszag);
        Task AddEpuletAsync(Epulet e, Orszag currentOrszag);
        Task SaveChangesAsync();
       
    }
}
