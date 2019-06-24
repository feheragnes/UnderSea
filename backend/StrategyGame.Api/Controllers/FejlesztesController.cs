using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FejlesztesController : StrategyController
    {
        private readonly IFejlesztesService _fejlesztesService;
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;

        public FejlesztesController(IFejlesztesService fejlesztesService, IOrszagService orszagService, ICommonService commonService, UserManager<StrategyGameUser> userManager) : base(userManager)
        {

            _fejlesztesService = fejlesztesService;
            _orszagService = orszagService;
            _commonService = commonService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FejlesztesInfoDTO>>> GetAllFejleszteses()
        {
           return await _fejlesztesService.GetFinishedFejlesztesesAsync(UserId);
        }

        [HttpGet]
        public async Task<IActionResult> GetFejlesztesInfos()
        {
            return Ok("Not implemented");
        }

        [HttpPost]
        public async Task<IActionResult> BuyFejlesztes([FromBody] FejlesztesInfoDTO fejlesztes)
        {
            return Ok(_fejlesztesService.AddFejlesztesAsync(fejlesztes, UserId));
        }

    }
}