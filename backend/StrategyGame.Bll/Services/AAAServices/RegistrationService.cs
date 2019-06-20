using Microsoft.AspNetCore.Identity;
using StrategyGame.Bll.DTOs.AAADTOs;
using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Bll.Services.AAAServices;
using StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces;
using Microsoft.Extensions.Configuration;

namespace StrategyGame.Bll.Services.AAAServices
{
    public class RegistrationService : IRegistrationService
    {
        private readonly SignInManager<StrategyGameUser> _signInManager;
        private readonly UserManager<StrategyGameUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IJWTService _jwtService;

        public RegistrationService(
            UserManager<StrategyGameUser> userManager,
            SignInManager<StrategyGameUser> signInManager,
            IConfiguration configuration,
            IJWTService jwtService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _jwtService = jwtService;
        }

        public async Task<object> Register(RegistrationDTO model)
        {
            var user = new StrategyGameUser
            {
                UserName = model.Email,
                Email = model.Email

            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return await _jwtService.GenerateJwtToken(model.Email, user);
            }

            throw new ApplicationException("UNKNOWN_ERROR");
        }


    }
}
