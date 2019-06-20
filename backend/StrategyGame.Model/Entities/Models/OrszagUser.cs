using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class OrszagUser
    {
        public Guid OrszagId { get; set; }
        public Orszag Orszag { get; set; }
        public Guid UserId { get; set; }
        public StrategyGameUser User { get; set; }
    }
}
