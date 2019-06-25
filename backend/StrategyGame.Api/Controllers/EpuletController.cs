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
        public async Task<ActionResult<List<Epulet>>> GetUserEpulets()
        {
           
            return  await _epuletService.GetAllEpuletsFromOneUserAsync(UserId);
        }

        [HttpPost]
        public async Task<IActionResult> BuyEpulets([FromBody]  List<EpuletInfoDTO> epulets)
        {
            await _epuletService.AddEpuletAsync(epulets, UserId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<long>> GetActiveEpitesNumber()
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(UserId);
            return await _epuletService.GetActiveEpitesCount(currentOrszag);
        }

        [HttpGet]
        public async Task<ActionResult<List<Epulet>>> GetEpuletInfos()
        {

            return await _epuletService.GetAllEpuletsFromOneUserAsync(UserId);
        }
    }
}