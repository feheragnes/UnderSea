using StrategyGame.Api.ViewModels.EgysegViewModels;
using System.Collections.Generic;

namespace StrategyGame.Api.ViewModels.TamadasViewModels
{
    public class TamadasInditasViewModel
    {
        public string Orszag { get; set; }
        public List<TamadoSeregInfoViewModel> TamadoEgysegek { get; set; }
    }
}
