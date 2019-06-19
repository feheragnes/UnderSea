using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class Jatek
    {
        [Key]
        public int JatekId { get; set; }
        public int Korok { get; set; }
    }
}
