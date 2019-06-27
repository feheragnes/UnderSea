using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class SzonarAgyu : Fejlesztes
    {
        public SzonarAgyu() : base()
        {
            Novelo.Add(new TamadasNovelo(20));
        }
    }
}
