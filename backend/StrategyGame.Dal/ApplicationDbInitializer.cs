using Microsoft.AspNetCore.Identity;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal
{
    public static class ApplicationDbInitializer
    {
    
        public static void SeedUsers(UserManager<StrategyGameUser> userManager, StrategyGameContext context)
        {
            for (int i = 0; i < 4; i++)
            {
                if (userManager.FindByEmailAsync($"TesztUser{i}@asd.com").Result == null)
                {
                    var user = new StrategyGameUser
                    {
                        UserName = ($"TesztUser{i}@asd.com"),
                        Email = ($"TesztUser{i}@asd.com"),
                        Orszag = context.Orszags.Find(new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"))
                    };

                    IdentityResult result = userManager.CreateAsync(user, "Abc123").Result;

                }
            }
          
        }
    }
}