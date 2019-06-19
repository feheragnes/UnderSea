using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class Orszag
    {
      
        public Guid Id { get; set; }

        public long Gyongy { get; set; }

        public long Korall { get; set; }

        public IList<OrszagUser> Users { get; set; } = new List<OrszagUser>();

        public IList<Epulet> Epulets { get; set; } = new List<Epulet>();

        public IList<Csapat> Csapats { get; set; } = new List<Csapat>();

        public IList<Fejlesztes> Fejleszteses { get; set; } = new List<Fejlesztes>();


    }
}
