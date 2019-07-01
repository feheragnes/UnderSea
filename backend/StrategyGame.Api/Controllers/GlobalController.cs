﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Api.ViewModels.GlobalViewModels;
using AutoMapper;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GlobalController : StrategyController
    {
        private readonly IGlobalService _globalService;
        private readonly IEndTurnService _endTurnService;
        private readonly IMapper _mapper;

        public GlobalController(IGlobalService globalSevice, 
                                IEndTurnService endTurnService,
                                IMapper mapper,
                                UserManager<StrategyGameUser> userManager) : base(userManager)
        {
            _globalService = globalSevice;
            _endTurnService = endTurnService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAktualisKor()
        {
            try
            {
                return Json(new { Kor = await _globalService.GetKor() });
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<RanglistaViewModel>>> GetRanglista()
        {
            try
            {
                return _mapper.Map<List<RanglistaViewModel>>(await _globalService.GetRanglista());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> NextTurn()
        {
            try
            {
                await _endTurnService.NextTurn();
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}