using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Enums;
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
        public readonly IEpuletService _epuletService;
        public readonly IEgysegService _egysegService;
        public readonly UserManager<StrategyGameUser> _userManager;

        public InitService(StrategyGameContext context, IOrszagService orszagService, IEpuletService epuletService, IEgysegService egysegService, UserManager<StrategyGameUser> userManager)
        {
            _context = context;
            _orszagService = orszagService;
            _userManager = userManager;
            _egysegService = egysegService;
            _epuletService = epuletService;
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
                    UserName = ($"TesztUser{i}@asd.com"),
                    Email = ($"TesztUser{i}@asd.com")
                };

                 await _userManager.CreateAsync(user, "Asd123");
                
            }

            var rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
               var user = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedEmail.Equals($"TesztUser{i}@asd.com"));


                var orszag = new Orszag { Nev = $"Tesztorszag{i}", Korall = rnd.Next(100,2000), Gyongy = rnd.Next(1000,5000) };
                orszag.Epulets.Add(new AramlasIranyito() { Felepult = true });

                orszag.OtthoniCsapats.Add(new Csapat() { Kimenetel = HarcEredmenyTipus.Otthon });
                    await _context.Orszags.AddAsync(orszag);


                   
            }



        }
    }
}
