using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class Orszag
    {
        public Guid Id { get; set; }

        public string Nev { get; set; }
        public long Pont { get; set; }

        public long Gyongy { get; set; }

        public long Korall { get; set; }
        public IList<Epulet> Epulets { get; set; } = new List<Epulet>();

        public IList<Csapat> OtthoniCsapats { get; set; } = new List<Csapat>();
        public IList<Csapat> TamadoCsapats { get; set; } = new List<Csapat>();

        public IList<Fejlesztes> Fejleszteses { get; set; } = new List<Fejlesztes>();

    
    }
}
