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
    public class GlobalController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAktualisKor()
        {
            return Ok("Not implemented");
        }

        [HttpPost]
        public async Task<IActionResult> PostKorVege()
        {
            return Ok("Not implemented");
        }
    }
}