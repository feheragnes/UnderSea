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
        Task<List<Epulet>> GetAllEpuletsAsync(Guid userId);
        Task<List<Epulet>> GetAllEpuletsAsync(Orszag currentOrszag);
        Task<List<EpuletInfoDTO>> GetFelepultEpuletsAsync(Guid userId);
        Task<List<EpuletInfoDTO>> GetFelepultEpuletsAsync(Orszag currentOrszag);
        Task<Epulet> GetEpuletByIdAsync(Guid id, Guid userId);
        Task<bool> GetIfActiveConstruction(Guid userId);
        Task<bool> GetIfActiveConstruction(Orszag currentOrszag);
        Task AddEpuletAsync(List<EpuletInfoDTO> epulets, Guid userId);
        Task AddEpuletAsync(List<EpuletInfoDTO> epulets, Orszag currentOrszag);
    }
}
