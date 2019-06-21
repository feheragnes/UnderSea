using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EgysegController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserEgysegs()
        {
            return Ok("Not implemented");
        }

        [HttpGet]
        public async Task<IActionResult> GetEgysegInfos()
        {
            return Ok("Not implemented");
        }

        [HttpPost]
        public async Task<IActionResult> BuyEgysegs([FromBody] JObject egysegs)
        {
            SeregInfoDTO csataCsikos = data["customerData"].ToObject<Customer>();
            SeregInfoDTO product = data["productData"].ToObject<Product>();
            SeregInfoDTO employee = data["employeeData"].ToObject<Employee>();
            return Ok("Not implemented");
        }
    }
}