using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using Newtonsoft.Json.Linq;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Api.ViewModels.EpuletViewModels;
using AutoMapper;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EpuletController : StrategyController
    {

        private readonly IEpuletService _epuletService;
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;

        public EpuletController(IEpuletService epuletService, IOrszagService orszagService,ICommonService commonService,UserManager<StrategyGameUser> userManager, IMapper mapper):base(userManager)
        {
            _epuletService = epuletService;
            _orszagService = orszagService;
            _commonService = commonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EpuletInfoViewModel>>> GetUserEpulets()
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(UserId);
           return _mapper.Map<List<EpuletInfoViewModel>> (await _epuletService.GetFelepultEpuletsFromOneUserAsync(currentOrszag));
        }

        [HttpPost]
        public async Task<IActionResult> BuyEpulets([FromBody]  List<EpuletInfoViewModel> epulets)
        {
            await _epuletService.AddEpuletAsync(_mapper.Map<List<EpuletInfoDTO>> (epulets), UserId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<long>> GetActiveEpitesNumber()
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(UserId);
            return await _epuletService.GetActiveEpitesCount(currentOrszag);
        }

        [HttpGet]
        public async Task<ActionResult<List<EpuletInfoViewModel>>> GetEpuletInfos()
        {

            return  _mapper.Map < List < EpuletInfoViewModel >> (await _epuletService.GetAllEpuletsFromOneUserAsync(UserId));
        }
    }
}