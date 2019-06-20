using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StrategyGame.Bll.DTOs;
using StrategyGame.Dal.Context;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TamadasController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetUserEgysegs()
        {
            return Ok("Not implemented");
        }

        [HttpGet]
        public async Task<IActionResult> GetEllensegesOrszags()
        {
            return Ok("Not implemented");
        }
        
        [HttpPost]
        public async Task<IActionResult> PostTamadas([FromBody]JObject data)
        {
            return Ok("Not implemented");
        }

        [HttpGet]
        public async Task<IActionResult> GetHarcStatusz()
        {
            return Ok("Not implemented");
        }

    }
}