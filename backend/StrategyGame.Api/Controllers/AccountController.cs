using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StrategyGame.Bll.DTOs.AAADTOs;
using StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces;
using StrategyGame.Model.Entities.Identity;

namespace StrategyGame.Api.Controllers
{



    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {

        public void HFTest()
        {
            Console.WriteLine("asdads");
        }

        private readonly IRegistrationService _registrationService;
        private readonly ILoginService _loginService;

        public AccountController(
            IRegistrationService registrationService,
            ILoginService loginService
            )
        {
            _registrationService = registrationService;
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] LoginDTO model)
        {
            return await _loginService.Login(model);
        }

        [HttpPost]
        public async Task<object> Register([FromBody] RegistrationDTO model)
        {
            return await _registrationService.Register(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<object> AutTest()
        {
            RecurringJob.AddOrUpdate(
                     () => HFTest(),
                     Cron.Minutely);

            return "Hang Fired";
        }
        }

    }
