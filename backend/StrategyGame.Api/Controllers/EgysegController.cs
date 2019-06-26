using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StrategyGame.Api.ViewModels.EgysegViewModels;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EgysegController : StrategyController
    {
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;
        private readonly IEgysegService _egysegService;
        private readonly IMapper _mapper;


        public EgysegController(IEgysegService egysegService, IOrszagService orszagService,ICommonService commonService,UserManager<StrategyGameUser> userManager, IMapper mapper):base(userManager)
        {
            _egysegService = egysegService;
            _orszagService = orszagService;
            _commonService = commonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SeregInfoDTO>>> GetOtthonMaradtCsapatFromOneUser()
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(UserId);
            return await _egysegService.GetOtthoniEgysegsFromOneUserAsync(currentOrszag);
        }

    

        [HttpPost]
        public async Task<IActionResult> BuyEgysegs([FromBody] List<EgysegVetelViewModel> egysegs)
        {
            try
            {
                await _egysegService.AddEgysegAsync(_mapper.Map<List<SeregInfoDTO>>(egysegs), UserId);
                return Ok("Egysegek megveve!");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<EgysegInfoViewModel>>> GetEgysegInfos()
        {
            try
            {
                return _mapper.Map<List<EgysegInfoViewModel>>(await _egysegService.GetEgysegInfoDTOs(UserId));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}