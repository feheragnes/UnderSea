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
        Task<List<Epulet>> GetEpuletsAsync(ClaimsPrincipal user);
        Task<Epulet> GetEpuletByIdAsync(Guid id, ClaimsPrincipal user);
        Task AddEpuletAsync(Epulet e, ClaimsPrincipal user);
        Task SaveChangesAsync();
       
    }
}
