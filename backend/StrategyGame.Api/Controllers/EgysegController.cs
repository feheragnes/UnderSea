using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EgysegController : StrategyController
    {
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;
        private readonly IEgysegService _egysegService;

        public EgysegController(IEgysegService egysegService, IOrszagService orszagService,ICommonService commonService,UserManager<StrategyGameUser> userManager):base(userManager)
        {
            _egysegService = egysegService;
            _orszagService = orszagService;
            _commonService = commonService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SeregInfoDTO>>> GetOtthonMaradtCsapatFromOneUser()
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(UserId);
            return await _egysegService.GetOtthoniEgysegsFromOneUserAsync(currentOrszag);
        }

        [HttpGet]
        public async Task<ActionResult<List<EgysegDTO>>> GetAllEgysegsFromOneUser()
        {
            return await _egysegService.GetAllEgysegsFromOneUserAsync(UserId);
        }


        [HttpPost]
        public async Task<IActionResult> BuyEgysegs([FromBody] List<SeregInfoDTO> egysegs)
        {
            await _egysegService.AddEgysegAsync(egysegs, UserId);
            return Ok();
        }
    }
}