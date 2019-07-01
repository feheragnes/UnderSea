using StrategyGame.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface ITamadasService
    {
        Task MakeTamadas(BejovoTamadasDTO bejovoTamadasDTO, Guid userId);
        Task<List<HarcDTO>> GetHarcStatus(Guid userId);
    }
}
