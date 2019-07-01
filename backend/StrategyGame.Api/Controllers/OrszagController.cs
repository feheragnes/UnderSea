using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Api.ViewModels.OrszagViewModels;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Model.Entities.Identity;
using System;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrszagController : StrategyController
    {
        private readonly IOrszagService _orszagService;
        private readonly IMapper _mapper;

        public OrszagController(IOrszagService orszagService, UserManager<StrategyGameUser> userManager, IMapper mapper) : base(userManager)
        {
            _orszagService = orszagService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<OrszagInfoViewModel>> GetOrszagInfos()
        {
            try
            {
                return _mapper.Map<OrszagInfoViewModel>(await _orszagService.GetUserOrszagInfos(UserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}