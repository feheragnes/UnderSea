using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrszagController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrszagInfos()
        {
            return Ok("Not implemented");
        }
        [HttpGet]
        public async Task<IActionResult> GetUserInfos()
        {
            return Ok("Not implemented");
        }
        [HttpGet]
        public async Task<IActionResult> GetRanglista()
        {
            return Ok("Not implemented");
        }
    }
}