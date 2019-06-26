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
        Task<List<EgysegDTO>> GetAllEgysegsFromOneUserAsync(Guid userId);
        Task AddEgysegAsync(List<SeregInfoDTO> egysegek, Guid userId);
        Task<List<SeregInfoDTO>> GetOtthoniEgysegsFromOneUserAsync(Orszag currentOrszag);
        Task<List<EgysegInfoDTO>> GetEgysegInfoDTOs(Guid userId);
    }
}
