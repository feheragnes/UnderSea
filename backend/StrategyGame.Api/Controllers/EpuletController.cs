using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using Newtonsoft.Json.Linq;
using StrategyGame.Model.Entities.Models.Epuletek;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EpuletController : Controller
    {


        //var user = await _userManager.GetUserAsync(User);
        private readonly IEpuletService _epuletService;

        private readonly SignInManager<StrategyGameUser> _signInManager;
        private readonly UserManager<StrategyGameUser> _userManager;

        public EpuletController(IEpuletService epuletService)
        {
            _epuletService = epuletService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserEpulets()
        {

            return Ok(_epuletService.GetEpuletsAsync(User));
        }

        [HttpPost]
        public async Task<IActionResult> BuyEpulets([FromBody] JObject epulets)
        {
            EpuletInfoDTO aramlasIranyito = epulets["aramlasiranyito"].ToObject<EpuletInfoDTO>();
            EpuletInfoDTO zatonyVar = epulets["zatonyvar"].ToObject<EpuletInfoDTO>();

            for (int i = 0; i < aramlasIranyito.Mennyiseg; i++)
                await _epuletService.AddEpuletAsync(new AramlasIranyito(1000,5,50,200), User);

            for(int i=0; i< zatonyVar.Mennyiseg; i++)
                await _epuletService.AddEpuletAsync(new ZatonyVar(1000, 5, 200), User);

            return Ok("Not implemented");
        }
        [HttpGet]
        public async Task<IActionResult> GetEpuletInfos()
        {
            return Ok("Not implemented");
        }
    }
}