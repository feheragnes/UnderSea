﻿using StrategyGame.Api.ViewModels.EgysegViewModels;
using StrategyGame.Api.ViewModels.EpuletViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.ViewModels.OrszagViewModels
{
    public class OrszagInfoViewModel
    {
        public Guid Id { get; set; }

        public string Nev { get; set; }

        public long Gyongy { get; set; }

        public long Korall { get; set; }
        public long Helyezes { get; set; }
        public long KorallTermeles { get; set; }
        public long GyongyTermeles { get; set; }
        public long EpuloAramlasIranyito { get; set; }
        public long EpuloZatonyvar { get; set; }
        public IList<SeregInfoViewModel> SeregInfo { get; set; }
        public IList<EpuletInfoViewModel> EpuletInfo { get; set; }
    }
}
