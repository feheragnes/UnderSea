using StrategyGame.Model.Entities.Models.Egysegek;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class Csapat
    {
        
        public Guid Id { get; set; }
        public Orszag Celpont { get; set; }
        public Orszag Tulajdonos { get; set; }
        public Allapot Allapot { get; set; }
        public IList<Egyseg> Egysegs { get; set; } = new List<Egyseg>();
    }
}
