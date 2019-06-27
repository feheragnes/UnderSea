using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Api.ViewModels.FejlesztesViewModels;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FejlesztesController : StrategyController
    {
        private readonly IFejlesztesService _fejlesztesService;
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;

        public FejlesztesController(IFejlesztesService fejlesztesService, 
            IOrszagService orszagService, 
            ICommonService commonService, 
            IMapper mapper,
            UserManager<StrategyGameUser> userManager) : base(userManager)
        {

            _fejlesztesService = fejlesztesService;
            _orszagService = orszagService;
            _commonService = commonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FejlesztesInfoDTO>>> GetAllFejleszteses()
        {
            return await _fejlesztesService.GetFinishedFejlesztesesAsync(UserId);
        }

        [HttpGet]
        public async Task<ActionResult<List<FejlesztesInfoViewModel>>> GetFejlesztesInfos()
        {
            try
            {
                return _mapper.Map<List<FejlesztesInfoViewModel>>(await _fejlesztesService.GetFejlesztesInfoDTOs(UserId));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<long>> GetActiveFejlesztesNumber()
            {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(UserId);
            return await _fejlesztesService.GetActiveFejlesztesCount(currentOrszag);
            }


        [HttpPost]
        public async Task<IActionResult> BuyFejlesztes([FromBody] FejlesztesVetelViewModel fejlesztes)
        {
            try
            {
                await _fejlesztesService.AddFejlesztesAsync(_mapper.Map<FejlesztesInfoDTO>(fejlesztes), UserId);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        

    }
}