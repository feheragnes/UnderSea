using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public  interface IFejlesztesService
    {
        Task<List<FejlesztesInfoDTO>> GetFinishedFejlesztesesAsync(Guid userId);
        Task<long> GetActiveFejlesztesCount(Orszag currentOrszag);
        Task AddFejlesztesAsync(FejlesztesInfoDTO fejlesztes, Guid userId);
    }
}
