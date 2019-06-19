using Microsoft.AspNetCore.Identity;
using StrategyGame.Bll.DTOs.AAADTOs;
using StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services.AAAServices
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<StrategyGameUser> _signInManager;
        private readonly UserManager<StrategyGameUser> _userManager;
        private readonly IJWTService _jwtService;

        public LoginService(
            UserManager<StrategyGameUser> userManager,
            SignInManager<StrategyGameUser> signInManager,
            IJWTService jwtService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }
        public async Task<object> Login(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return await _jwtService.GenerateJwtToken(model.Email, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
    }
}
