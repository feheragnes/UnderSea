using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class InitController : StrategyController
    {

        private readonly IInitService _initService;
        private readonly IMapper _mapper;


        public InitController(IEgysegService egysegService, IInitService initService, UserManager<StrategyGameUser> userManager, IMapper mapper) : base(userManager)
        {
            _initService = initService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SeedDatabase()
        {
            await _initService.SeedGame();
            return Ok("asd");
        }
    }
}