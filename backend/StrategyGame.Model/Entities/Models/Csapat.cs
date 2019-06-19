using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class Csapat
    {
        [Key]
        public int CsapatId { get; set; }
        public int CelpontId { get; set; }
        public int AllapotId { get; set; }
        public IList<Egyseg> Egysegs = new List<Egyseg>();
    }
}
