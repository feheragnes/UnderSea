using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class KorallFal : Fejlesztes
    {
        public KorallFal() : base()
        {
            Novelo.Add(new VedekezesNovelo(20));
        }
    }
}
