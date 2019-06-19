using Microsoft.AspNetCore.Identity;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Identity
{
        public class StrategyGameUser : IdentityUser<Guid>
        {

        public IList<Orszag> Orszags = new List<Orszag>();

    }
}
