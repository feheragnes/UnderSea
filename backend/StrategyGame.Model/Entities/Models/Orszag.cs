using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class Orszag
    {
        [Key]
        public int OrszagId { get; set; }

        public int Gyongy { get; set; }

        public int Korall { get; set; }

        public IList<StrategyGameUser> Users = new List<StrategyGameUser>();

        public IList<Epulet> Epulets = new List<Epulet>();

        public IList<Csapat> Csapats = new List<Csapat>();

        public IList<Fejlesztes> Fejleszteses = new List<Fejlesztes>();


    }
}
