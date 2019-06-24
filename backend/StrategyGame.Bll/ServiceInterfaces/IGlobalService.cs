using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IGlobalService
    {
        Task<long> GetUserScore(ClaimsPrincipal userClaim);
        Task<long> GetKor();
        Task<Dictionary<string, long>> GetOrszagScores();
        Task<List<KeyValuePair<string, long>>> GetRanglista();
        Task<long> GetHelyezes(ClaimsPrincipal userClaim);
    }
}
