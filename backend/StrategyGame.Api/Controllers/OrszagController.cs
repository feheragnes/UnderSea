using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrszagController : ControllerBase
    {
        private readonly IOrszagService _orszagService;
        public OrszagController(IOrszagService orszagService)
        {
            _orszagService = orszagService;
        }
        [HttpGet]
        public async Task<ActionResult<OrszagDTO>> GetOrszagInfos()
        {
            return await _orszagService.GetUserOrszagInfos(User);
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