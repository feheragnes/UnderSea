using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;

namespace StrategyGame.Model.Entities.Models
{
    public class Csapat
    {
        public Guid Id { get; set; }
        public Orszag Celpont { get; set; }
        public Orszag Tulajdonos { get; set; }
        public long RaboltGyongy { get; set; }
        public long RaboltKorall { get; set; }
        public HarcEredmenyTipus Kimenetel { get; set; }
        public List<Egyseg> Egysegs { get; set; } = new List<Egyseg>();
        public List<Egyseg> VedekezoEgysegs { get; set; } = new List<Egyseg>();
    }
}
