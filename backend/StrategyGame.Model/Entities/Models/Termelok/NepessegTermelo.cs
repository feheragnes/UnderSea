﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Termelok
{
    public class NepessegTermelo : AbstractTermelo
    {
        public Guid Id { get; set; }


        public long Ertek { get; set; }
    }
}
