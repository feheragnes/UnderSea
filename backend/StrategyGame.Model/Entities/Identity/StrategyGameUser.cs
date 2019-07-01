using Microsoft.AspNetCore.Identity;
using StrategyGame.Model.Entities.Models;
using System;

namespace StrategyGame.Model.Entities.Identity
{
    public class StrategyGameUser : IdentityUser<Guid>
    {
        public Orszag Orszag { get; set; }
    }
}