﻿using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class IszapKombajn : Fejlesztes
    {
        public IszapKombajn() : base()
        {
            Novelo.Add(new KorallNovelo(15));
        }
    }
}
