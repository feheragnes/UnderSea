using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using System;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IOrszagService
    {
        Task MakeOrszagUserConnection(StrategyGameUser user, string orszagnev);
        Task<Orszag> InitOrszag(string orszagnev);
        Task<OrszagDTO> Map(Orszag orszag);
        Task<OrszagDTO> GetUserOrszagInfos(Guid userId);
        Task<TamadasDTO> GetTamadasDTO(Guid userId);
        Task<long> GetGyongyTermeles(Orszag orszag);
        Task<long> GetKorallTermeles(Orszag orszag);
        Task<long> GetKoTermeles(Orszag orszag);
        Task<long> GetVedekezesBonusz(Orszag orszag);
        Task<long> GetTamadasBonusz(Orszag orszag);
    }
}
