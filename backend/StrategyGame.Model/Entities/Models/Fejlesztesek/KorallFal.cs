using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class KorallFal : Fejlesztes
    {
        public VedekezesNovelo Vedekezes { get; set; }
        public KorallFal() : base()
        {
            Vedekezes.Ertek = 20;
        }
    }
}
