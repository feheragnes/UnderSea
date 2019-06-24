using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EgysegController : ControllerBase
    {

        private readonly IOrszagService _orszagService;
        private readonly IEgysegService _egysegService;

        public EgysegController(IEgysegService egysegService, IOrszagService orszagService)
        {
            _egysegService = egysegService;
            _orszagService = orszagService;

        }
        [HttpGet]
        public async Task<IActionResult> GetUserEgysegs()
        {
            Orszag userOrszag = await _orszagService.GetUserOrszag(User);
            return Ok("Not implemented");
        }

        [HttpGet]
        public async Task<IActionResult> GetEgysegInfos()
        {
            return Ok("Not implemented");
        }

        [HttpPost]
        public async Task<IActionResult> BuyEgysegs([FromBody] List<SeregInfoDTO> egysegs)
        {
          

            Orszag userOrszag = await _orszagService.GetUserOrszag(User);

            await _egysegService.AddEgysegAsync(egysegs, userOrszag);

            return Ok("Not implemented");
        }
    }
}