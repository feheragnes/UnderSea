﻿using StrategyGame.Api.ViewModels.EgysegViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.ViewModels.Felfedezes
{
    public class FelfedezesViewModel
    {
        public List<string> Orszag { get; set; }
        public List<TamadoSeregInfoViewModel> Sereg { get; set; }
    }
}