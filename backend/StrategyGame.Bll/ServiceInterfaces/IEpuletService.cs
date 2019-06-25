using StrategyGame.Bll.DTOs;
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
        Task<List<EpuletInfoDTO>> GetAllEpuletsFromOneUserAsync(Guid userId);
        Task<List<EpuletInfoDTO>> GetFelepultEpuletsFromOneUserAsync(Orszag currentOrszag);
        Task<Epulet> GetEpuletByIdAsync(Guid id, Guid userId);
        Task<long> GetEpuloAramlasiranyitoCout(Orszag currentOrszag);
        Task<long> GetEpuloZatonyvarCount(Orszag currentOrszag);
        Task AddEpuletAsync(List<EpuletInfoDTO> epulets, Guid userId);
    }
}
