using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs.Fejlesztesek;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FejlesztesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllFejleszteses()
        {
            return Ok("Not implemented");
        }

        [HttpGet]
        public async Task<IActionResult> GetFejlesztesInfos()
        {
            return Ok("Not implemented");
        }

        [HttpGet]
        public async Task<IActionResult> BuyFejlesztes([FromBody] FejlesztesDTO epulet)
        {
            return Ok("Not implemented");
        }

    }
}