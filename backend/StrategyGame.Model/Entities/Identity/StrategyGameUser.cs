using Microsoft.AspNetCore.Identity;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Identity
{
        public class StrategyGameUser : IdentityUser<Guid>
        {

        public int CurrentOrszagIndex { get; set; } = 0;
        public IList<OrszagUser> Orszags { get; set; } = new List<OrszagUser>();



    }
}
