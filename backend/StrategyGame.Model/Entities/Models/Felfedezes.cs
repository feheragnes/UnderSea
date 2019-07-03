using StrategyGame.Model.Entities.Models.Egysegek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class Felfedezes
    {
        public Guid Id { get; set; }
        public Orszag Orszag { get; set; }
        public string Celpont { get; set; }
        public long VedekezoEro {get; set; }
        public long Gyongy { get; set; }
        public long Korall { get; set; }
        public DateTime Idopont { get; set; }
    }
}
