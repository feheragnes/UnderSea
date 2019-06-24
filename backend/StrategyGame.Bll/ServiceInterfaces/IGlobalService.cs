using StrategyGame.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IGlobalService
    {
        Task<long> GetUserScore(Guid UserId);
        Task<long> GetKor();
        Task<IList<RanglistaDTO>> GetRanglista();
        Task<long> GetHelyezes(Guid userId);
    }
}
