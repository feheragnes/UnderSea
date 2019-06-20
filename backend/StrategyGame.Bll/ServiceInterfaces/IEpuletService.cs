using StrategyGame.Model.Entities.Models.Epuletek;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    interface IEpuletService
    {
        Task<List<Epulet>> GetEpuletsAsync();
        Task<Epulet> GetEpuletByIdAsync(Guid id);
        Task AddEpuletAsync(Epulet e);
        Task SaveChangesAsync();
    }
}
