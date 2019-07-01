using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Api.ViewModels.TamadasViewModels;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TamadasController : StrategyController
    {
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;
        private readonly ITamadasService _tamadasService;
        private readonly IMapper _mapper;
        private readonly IEgysegService _egysegService;

        public TamadasController(IEgysegService egysegService,
            IOrszagService orszagService,
            ICommonService commonService,
            ITamadasService tamadasService,
            IMapper mapper,
            UserManager<StrategyGameUser> userManager) : base(userManager)
        {
            _egysegService = egysegService;
            _orszagService = orszagService;
            _commonService = commonService;
            _tamadasService = tamadasService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserEgysegs()
        {
            Orszag userOrszag = await _commonService.GetCurrentOrszag(UserId);
            return Ok(_egysegService.GetOtthoniEgysegsFromOneUserAsync(userOrszag));
        }

        [HttpGet]
        public async Task<ActionResult<TamadasViewModel>> GetTamadasInfos()
        {
            try
            {
                return _mapper.Map<TamadasViewModel>(await _orszagService.GetTamadasDTO(UserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTamadas([FromBody]TamadasInditasViewModel tamadasInditasViewModel)
        {
            try
            {
                await _tamadasService.MakeTamadas(_mapper.Map<BejovoTamadasDTO>(tamadasInditasViewModel), UserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<HarcViewModel>>> GetHarcStatusz()
        {
            try
            {
                return _mapper.Map<List<HarcViewModel>>(await _tamadasService.GetHarcStatus(UserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}