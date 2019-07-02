using StrategyGame.Api.ViewModels.EgysegViewModels;
using System.Collections.Generic;

namespace StrategyGame.Api.ViewModels.TamadasViewModels
{
    public class HarcViewModel
    {
        public string VedekezoOrszag { get; set; }
        public string TamadoOrszag { get; set; }
        public List<SeregInfoViewModel> TamadoCsapat { get; set; }
        public List<SeregInfoViewModel> VedekezoCsapat { get; set; }
        public long RaboltGyongy { get; set; }
        public long RaboltKorall { get; set; }
        public string HarcEredmeny { get; set; }
    }
}
