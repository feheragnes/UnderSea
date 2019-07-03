﻿using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IFelfedezesService
    {
        Task<SeregInfoDTO> GetOtthoniFelfedezokFromOneUserAsync(Orszag currentOrszag);
        Task<FelfedezesDTO> MakeFelfedezes(BejovoFelfedezesDTO bejovoFelfedezes, Guid userId);
    }
}
