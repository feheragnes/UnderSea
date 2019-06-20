﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public abstract class Fejlesztes
    {

        public Guid Id { get; set; }

        public int Noveles { get; set; }
        public long SzuksegesKorok { get; set; }
        public long AktualisKor { get; set; }
        public bool Kifejlesztve { get; set; }

    }
}

    