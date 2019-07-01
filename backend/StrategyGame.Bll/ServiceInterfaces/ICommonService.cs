﻿using StrategyGame.Model.Entities.Models;
using System;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface ICommonService
    {
        Task<Orszag> GetCurrentOrszag(Guid userId);
    }
}
