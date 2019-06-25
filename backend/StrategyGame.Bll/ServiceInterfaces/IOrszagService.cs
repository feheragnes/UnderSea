using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IOrszagService
    {
        void MakeOrszagUserConnection(StrategyGameUser user, string orszagnev);
        Task<Orszag> InitOrszag(string orszagnev);
        Task<OrszagDTO> Map(Orszag orszag);
        Task<OrszagDTO> GetUserOrszagInfos(Guid userId);
        Task<TamadasDTO> GetTamadasDTO(Guid userId);
    }
}
