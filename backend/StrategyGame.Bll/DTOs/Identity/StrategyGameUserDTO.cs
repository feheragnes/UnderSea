using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs.Identity
{
    class StrategyGameUserDTO
    {
        public IList<OrszagDTO> Orszags { get; set; } = new List<OrszagDTO>();
    }
}
