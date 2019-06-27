using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class Alkimia : Fejlesztes
    {
        public Alkimia() : base()
        {
            Novelo.Add(new AdoNovelo(30));
        }
    }
}
