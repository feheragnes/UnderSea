using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class InitService : IInitService
    {
        private readonly StrategyGameContext _context;
        private readonly IOrszagService _orszagService;
        public readonly UserManager<StrategyGameUser> _userManager;

        public InitService(StrategyGameContext context, IOrszagService orszagService, UserManager<StrategyGameUser> userManager)
        {
            _context = context;
            _orszagService = orszagService;
            _userManager = userManager;
        }
        public async Task SeedGame()
        {
           // if( await _context.Orszags.CountAsync() != 0)
          //  {
          //      return;
          //  }

            List<StrategyGameUser> users = new List<StrategyGameUser>();

            for (int i = 0; i < 5; i++)
            {
                var user = new StrategyGameUser
                {
                    UserName = ("TesztUser" + i + "@asd.com"),
                    Email = ("TesztUser" + i + "@asd.com")
                };

                users.Add(user);

                 await _userManager.CreateAsync(user, "Asd123");
                
            }


            for (int i = 0; i < 5; i++)
            {
                 await _orszagService.MakeOrszagUserConnection(users[i], ("TesztOrszag" + i));
            }

        }
    }
}
