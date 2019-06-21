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
using StrategyGame.Model.Entities.Models;
using StrategyGame.Dal.Context;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Bll.Services.AAAServices
{
    public class RegistrationService : IRegistrationService
    {
        private readonly SignInManager<StrategyGameUser> _signInManager;
        private readonly UserManager<StrategyGameUser> _userManager;
        private readonly StrategyGameContext _context;
        private readonly IJWTService _jwtService;


        public RegistrationService(
            UserManager<StrategyGameUser> userManager,
            SignInManager<StrategyGameUser> signInManager,
            StrategyGameContext context,
            IJWTService jwtService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<string> Register(RegistrationDTO model)
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
