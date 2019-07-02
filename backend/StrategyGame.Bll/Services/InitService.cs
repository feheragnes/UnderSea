using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
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
                    UserName = ("TesztUser" + i + "@asd.com"),
                    Email = ("TesztUser" + i + "@asd.com")
                };

                users.Add(user);

                 await _userManager.CreateAsync(user, "Asd123");
                
            }

            var rnd = new Random();
            var epulets = new List<EpuletInfoDTO>();
            var egysegs = new List<SeregInfoDTO>();

            for (int i = 0; i < 5; i++)
            {
                 await _orszagService.MakeOrszagUserConnection(users[i], ("TesztOrszag" + i));

               var user = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedEmail.Equals("TesztUser" + i + "@asd.com"));

                epulets.Add(new EpuletInfoDTO() { Ar = 0, Mennyiseg = rnd.Next(0, 5), Tipus = Model.Enums.EpuletTipus.AramlasIranyito });
                epulets.Add(new EpuletInfoDTO() { Ar = 0, Mennyiseg = rnd.Next(0, 5), Tipus = Model.Enums.EpuletTipus.ZatonyVar });
                await _epuletService.AddEpuletAsync(epulets, user.Id);

                egysegs.Add(new SeregInfoDTO(rnd.Next(0, 20), EgysegTipus.CsataCsiko));
                egysegs.Add(new SeregInfoDTO(rnd.Next(0, 20), EgysegTipus.RohamFoka));
                egysegs.Add(new SeregInfoDTO(rnd.Next(0, 20), EgysegTipus.LezerCapa));
                await _egysegService.AddEgysegAsync(egysegs, user.Id);
            }



        }
    }
}
