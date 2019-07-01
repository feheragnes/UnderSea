using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StrategyGame.Api.ViewModels.AAAViewModels;
using StrategyGame.Bll.DTOs.AAADTOs;
using StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces;
using StrategyGame.Model.Entities.Identity;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly IRegistrationService _registrationService;
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public AccountController(
            IRegistrationService registrationService,
            ILoginService loginService,
            IMapper mapper
            )
        {
            _registrationService = registrationService;
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                return Json(new { Token = await _loginService.Login(_mapper.Map<LoginDTO>(model)) });
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            string token;
            try
            {
            token = await _registrationService.Register(_mapper.Map<RegistrationDTO>(model));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Json(new { Token = token });
        }

        }

    }
