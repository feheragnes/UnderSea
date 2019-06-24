using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
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
        Task<List<EgysegDTO>> GetAllEgysegsAsync(Guid userId);
        Task<List<EgysegDTO>> GetAllEgysegsAsync(Orszag currentOrszag);
        Task AddEgysegAsync(List<SeregInfoDTO> egysegek, Guid userId);
        Task AddEgysegAsync(List<SeregInfoDTO> egysegek, Orszag currentOrszag);
        Task<List<SeregInfoDTO>> GetOtthoniEgysegsAsync(Guid userId);
        Task<List<SeregInfoDTO>> GetOtthoniEgysegsAsync(Orszag currentOrszag);
        Task SaveChangesAsync();


    }
}
