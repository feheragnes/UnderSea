using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GlobalController : StrategyController
    {
        private readonly IGlobalService _globalService;
        public GlobalController(IGlobalService globalSevice, 
                                UserManager<StrategyGameUser> userManager) : base(userManager)
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
            return Json(new { Helyezes = await _globalService.GetHelyezes(UserId)});
        }
        [HttpGet]
        public async Task<IActionResult> GetRanglista()
        {
            return Ok(await _globalService.GetRanglista());
        }

        [HttpPost]
        public async Task<IActionResult> PostKorVege()
        {
            return Ok("Not implemented");
        }
    }
}