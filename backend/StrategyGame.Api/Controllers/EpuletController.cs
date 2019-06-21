using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;

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

            return Ok("Not implemented");
        }

        [HttpPost]
        public async Task<IActionResult> BuyEpulets([FromBody] EpuletInfoDTO epulet)
        {
            return Ok("Not implemented");
        }
        [HttpGet]
        public async Task<IActionResult> GetEpuletInfos()
        {
            return Ok("Not implemented");
        }
    }
}