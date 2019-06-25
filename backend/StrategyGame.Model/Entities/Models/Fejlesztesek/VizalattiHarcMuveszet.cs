using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class VizalattiHarcmuveszet : Fejlesztes
    {

        TamadasNovelo Tamadas;
        VedekezesNovelo Vedekezes;

        public VizalattiHarcmuveszet() : base()
        {
            Tamadas = new TamadasNovelo();
            Vedekezes = new VedekezesNovelo();
            Tamadas.Ertek = 10;
            Vedekezes.Ertek = 10;
        }
    }
}
