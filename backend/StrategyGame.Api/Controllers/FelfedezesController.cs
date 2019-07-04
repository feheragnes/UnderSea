using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Api.ViewModels.EgysegViewModels;
using StrategyGame.Api.ViewModels.Felfedezes;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FelfedezesController : StrategyController
    {
        private readonly IOrszagService _orszagService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IEgysegService _egysegService;
        private readonly IFelfedezesService _felfedezesService;

        public FelfedezesController(IEgysegService egysegService,
            IOrszagService orszagService,
            ICommonService commonService,
            IFelfedezesService felfedezesService,
            IMapper mapper,
            UserManager<StrategyGameUser> userManager) : base(userManager)
        {
            _egysegService = egysegService;
            _orszagService = orszagService;
            _commonService = commonService;
            _felfedezesService = felfedezesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<SeregInfoViewModel>> GetUserFelfedezos()
        {
            return _mapper.Map<SeregInfoViewModel>(await _felfedezesService.GetOtthoniFelfedezokFromOneUserAsync(UserId));
        }

        [HttpGet]
        public async Task<ActionResult<SeregInfoViewModel>> GetUserElerhetoFelfedezos()
        {
            return _mapper.Map<SeregInfoViewModel>(await _felfedezesService.GetElerhetoFelfedezokFromOneUserAsync(UserId));
        }

        [HttpGet]
        public async Task<ActionResult<FelfedezesViewModel>> GetFelfedezesInfos()
        {
            try
            {
                return _mapper.Map<FelfedezesViewModel>(await _felfedezesService.GetFelfedezes(UserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<FelfedezesEredmenyViewModel>>> GetUsersFinishedFelfedezeses()
        {
            return _mapper.Map<List<FelfedezesEredmenyViewModel>>(await _felfedezesService.GetFinishedFelfedezeses(UserId));
        }
        [HttpPost]
        public async Task<ActionResult<FelfedezesEredmenyViewModel>> PostFelfedezes([FromBody]FelfedezesInditasViewModel felfedezesInditasViewModel)
        {
            try
            {
                //TODO MakeFelfedezes
                return _mapper.Map<FelfedezesEredmenyViewModel>(await _felfedezesService.MakeFelfedezes(_mapper.Map<BejovoFelfedezesDTO>(felfedezesInditasViewModel),UserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}