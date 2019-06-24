using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.ServiceInterfaces;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GlobalController : Controller
    {
        private readonly IGlobalService _globalService;
        public GlobalController(IGlobalService globalSevice)
        {
            _globalService = globalSevice;
        }
        [HttpGet]
        public async Task<IActionResult> GetAktualisKor()
        {
            return Json(new {Kor = await _globalService.GetKor() });
        }
        [HttpGet]
        public async Task<IActionResult> GetHelyezes()
        {
            return Json(new { Helyezes = await _globalService.GetHelyezes(User)});
        }
        [HttpGet]
        public async Task<ActionResult<List<KeyValuePair<string, long>>>> GetRanglista()
        {
            return await _globalService.GetRanglista();
        }

        [HttpPost]
        public async Task<IActionResult> PostKorVege()
        {
            return Ok("Not implemented");
        }
    }
}