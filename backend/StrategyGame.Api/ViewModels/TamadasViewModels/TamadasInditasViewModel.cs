using StrategyGame.Api.ViewModels.EgysegViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.ViewModels.TamadasViewModels
{
    public class TamadasInditasViewModel
    {
        public string Orszag { get; set; }
        public List<TamadoSeregInfoViewModel> TamadoEgysegek { get; set; }
    }
}
