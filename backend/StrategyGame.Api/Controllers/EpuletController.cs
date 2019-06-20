using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EpuletController : Controller
    {
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