﻿using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.EpuletDTO
{
    class ZatonyvarDTO : EpuletDTO, IEpulet
    {
        public Task NextTurn()
        {
            throw new NotImplementedException();
        }
    }
}
