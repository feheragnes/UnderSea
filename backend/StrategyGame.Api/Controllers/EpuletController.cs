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
using StrategyGame.Model.Entities.Models;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EpuletController : StrategyController
    {

        private readonly IEpuletService _epuletService;
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;

        public EpuletController(IEpuletService epuletService, IOrszagService orszagService,ICommonService commonService,UserManager<StrategyGameUser> userManager):base(userManager)
        {
            _epuletService = epuletService;
            _orszagService = orszagService;
            _commonService = commonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserEpulets()
        {
            Orszag userOrszag = await _commonService.GetCurrentOrszag(UserId);
            return Ok(_epuletService.GetAllEpuletsAsync(userOrszag));
        }

        [HttpPost]
        public async Task<IActionResult> BuyEpulets([FromBody]  List<EpuletInfoDTO> epulets)
        {

            Orszag userOrszag = await _commonService.GetCurrentOrszag(UserId);

            await _epuletService.AddEpuletAsync(epulets, userOrszag);

            return Ok("Not implemented");
        }



        [HttpGet]
        public async Task<IActionResult> GetEpuletInfos()
        {
            Orszag userOrszag = await _commonService.GetCurrentOrszag(UserId);
            return Ok("Not implemented");
        }
    }
}