﻿using System;

namespace StrategyGame.Model.Entities.Models.Egysegek
{
    public abstract class Egyseg
    {
        public Egyseg()
        {

        }
        public Guid Id { get; set; }
        public long Tamadas { get; set; }
        public long Vedekezes { get; set; }
        public long Ar { get; set; }
        public long Zsold { get; set; }
        public string Discriminator { get; set; }
        public long Ellatas { get; set; }
    }


}
