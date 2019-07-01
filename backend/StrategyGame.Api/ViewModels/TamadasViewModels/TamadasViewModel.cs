using StrategyGame.Api.ViewModels.EgysegViewModels;
using System.Collections.Generic;

namespace StrategyGame.Api.ViewModels.TamadasViewModels
{
    public class TamadasViewModel
    {
        public IList<string> Orszag { get; set; }
        public IList<TamadoSeregInfoViewModel> Sereg { get; set; }
    }
}
