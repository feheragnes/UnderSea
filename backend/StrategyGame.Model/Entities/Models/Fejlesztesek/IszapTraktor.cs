using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class IszapTraktor : Fejlesztes
    {
        public KorallNovelo Korall { get; set; }
        public IszapTraktor() : base()
        {
            Korall = new KorallNovelo();
            Korall.Ertek = 10;
        }
    }
}
