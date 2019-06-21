﻿using StrategyGame.Bll.DTOs;
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
        Task<List<Egyseg>> GetEgysegsAsync(Orszag currentOrszag);
        Task AddEgysegAsync(List<SeregInfoDTO> egysegek, Orszag currentOrszag);
        Task<List<SeregInfoDTO>> GetOtthoniEgysegekAsync(Orszag currentOrszag);
        Task SaveChangesAsync();


    }
}
