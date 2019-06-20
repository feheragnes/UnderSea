﻿using Microsoft.AspNetCore.Identity;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Identity
{
        public class StrategyGameUser : IdentityUser<Guid>
        {

        public IList<OrszagUser> Orszags { get; set; } = new List<OrszagUser>();

        public Orszag GetActiveOrszag()
        {
            return Orszags[0].Orszag;
        }

    }
}