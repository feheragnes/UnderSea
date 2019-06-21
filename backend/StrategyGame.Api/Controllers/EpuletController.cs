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

namespace StrategyGame.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EpuletController : Controller
    {

        private readonly IEpuletService _epuletService;
        private readonly IOrszagService _orszagService;




        public EpuletController(IEpuletService epuletService, IOrszagService orszagService)
        {
            _epuletService = epuletService;
            _orszagService = orszagService;
          
        }

        [HttpGet]
        public async Task<IActionResult> GetUserEpulets()
        {
            Orszag userOrszag = await _orszagService.GetUserOrszag(User);
            return Ok(_epuletService.GetEpuletsAsync(userOrszag));
        }

        [HttpPost]
        public async Task<IActionResult> BuyEpulets([FromBody] JObject epulets)
        {

         
            Orszag userOrszag = await _orszagService.GetUserOrszag(User);

            List<EpuletInfoDTO> epuletList = new List<EpuletInfoDTO>();
            epuletList.Add(epulets["aramlasiranyito"].ToObject<EpuletInfoDTO>());
            epuletList.Add(epulets["zatonyvar"].ToObject<EpuletInfoDTO>());

            await _epuletService.AddEpuletAsync(epuletList, userOrszag);

            return Ok("Not implemented");
        }



        [HttpGet]
        public async Task<IActionResult> GetEpuletInfos()
        {
            Orszag userOrszag = await _orszagService.GetUserOrszag(User);
            return Ok("Not implemented");
        }
    }
}