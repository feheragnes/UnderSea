using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities.Identity;
using System;

namespace StrategyGame.Api.Controllers
{
    public class StrategyController : Controller
    {
        private readonly UserManager<StrategyGameUser> _userManager;

        public StrategyController(UserManager<StrategyGameUser> userManager)
        {
            _userManager = userManager;
        }
        public Guid UserId => Guid.Parse(_userManager.GetUserId(User));
    }
}
