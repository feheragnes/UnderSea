using AutoMapper;
using Microsoft.AspNetCore.Identity;

using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services.AAAServices
{
    public class FejlesztesService : IFejlesztesService
    {
        private readonly StrategyGameContext _context;
        private readonly ICommonService _commonService;
        private readonly UserManager<StrategyGameUser> _userManager;
        private readonly IMapper _mapper;

        public FejlesztesService(StrategyGameContext context, ICommonService commonService, UserManager<StrategyGameUser> userManager, IMapper mapper)
        {
            _context = context;
            _commonService = commonService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task AddFejlesztesAsync(FejlesztesInfoDTO fejlesztes, Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            string fejlesztesTipus = Enum.GetName(typeof(FejlesztesTipus), fejlesztes.Tipus); ;

            if (currentOrszag?.Fejleszteses.Where(x => x.Kifejlesztve == false)?.Count() !=0)
            {
                throw new InvalidOperationException("Another PowerUp is under development");
            }
            if (currentOrszag?.Fejleszteses.Where(x => x.GetType().Name == fejlesztesTipus)?.Count() != 0)
            {
                throw new InvalidOperationException("You already have the chosen PowerUp");
            }


            

                switch (fejlesztes.Tipus)
            {
                case FejlesztesTipus.Alkimia:
                    currentOrszag.Fejleszteses.Add(new Alkimia());
                    break;
                case FejlesztesTipus.IszapKombajn:
                    currentOrszag.Fejleszteses.Add(new IszapKombajn());
                    break;
                case FejlesztesTipus.IszapTraktor:
                    currentOrszag.Fejleszteses.Add(new IszapTraktor());
                    break;
                case FejlesztesTipus.KorallFal:
                    currentOrszag.Fejleszteses.Add(new KorallFal());
                    break;
                case FejlesztesTipus.SzonarAgyu:
                    currentOrszag.Fejleszteses.Add(new SzonarAgyu());
                    break;
                case FejlesztesTipus.VizalattiHarmuveszet:
                    currentOrszag.Fejleszteses.Add(new VizalattiHarcmuveszet());
                    break;
                default:
                    throw new ArgumentException("Invalid fejlesztes type");
            }

            _context.SaveChanges();

        }


        public async Task<List<FejlesztesInfoDTO>> GetFinishedFejlesztesesAsync(Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            List<Fejlesztes> keszFejleszteses = currentOrszag.Fejleszteses.Where(x => x.Kifejlesztve == true).ToList();
            List<FejlesztesInfoDTO> keszDTOList = new List<FejlesztesInfoDTO>();


            keszFejleszteses.ForEach(x =>
            {
                keszDTOList.Add(new FejlesztesInfoDTO((FejlesztesTipus)Enum.Parse(typeof(FejlesztesTipus), x.GetType().Name), false, x.AktualisKor));
            });

            return keszDTOList;
        }


        public async Task<long> GetActiveFejlesztesCount(Orszag currentOrszag)
        {
            return currentOrszag.Fejleszteses.ToList().FindAll(x => x.Kifejlesztve == false).Count();
        }

        public async Task<List<FejlesztesInfoDTO>> GetFejlesztesInfoDTOs(Guid userId)
        {
            Orszag currentOrszag = await _commonService.GetCurrentOrszag(userId);
            List<Fejlesztes> userFejleszteses = currentOrszag.Fejleszteses.ToList();

            List<FejlesztesInfoDTO> returnDtoList = new List<FejlesztesInfoDTO>();

            userFejleszteses.ForEach(x =>
            {
                returnDtoList.Add(new FejlesztesInfoDTO((FejlesztesTipus)Enum.Parse(typeof(FejlesztesTipus), x.GetType().Name), x.Kifejlesztve, x.AktualisKor));
            });

            return returnDtoList;
        }
    }
}
