using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class Alkimia : Fejlesztes
    {
        public AdoNovelo Gyöngy { get; set; }
        public Alkimia() : base()
        {
            Gyöngy.Ertek = 30;
        }
    }
}
