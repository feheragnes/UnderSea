using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Bll.DTOs;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface ITamadasService
    {
        Task MakeTamadas(BejovoTamadasDTO bejovoTamadasDTO, Guid userId);
        Task<List<HarcDTO>> GetHarcStatus(Guid userId);
    }
}
