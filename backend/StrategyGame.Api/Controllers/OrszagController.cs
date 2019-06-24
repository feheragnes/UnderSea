using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class OrszagController : StrategyController
    {
        private readonly IOrszagService _orszagService;
        public OrszagController(IOrszagService orszagService,UserManager<StrategyGameUser> userManager):base(userManager)
        {
            _orszagService = orszagService;
        }
        [HttpGet]
        public async Task<ActionResult<OrszagDTO>> GetOrszagInfos()
        {
            return await _orszagService.GetUserOrszagInfos(UserId);
        }

    }
}