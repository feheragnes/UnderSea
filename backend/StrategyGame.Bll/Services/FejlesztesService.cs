using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StrategyGame.Bll.DTOs.DTOEnums;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
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
        private readonly UserManager<StrategyGameUser> _userManager;
        private readonly IMapper _mapper;

        public FejlesztesService(StrategyGameContext context, UserManager<StrategyGameUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task AddFejlesztesAsync(FejlesztesInfoDTO fejlesztes, Orszag currentOrszag)
        {
            List<Fejlesztes> fejleszteses = currentOrszag.Fejleszteses.ToList();

            string fejlesztesTipus = Enum.GetName(typeof(FejlesztesTipus), fejlesztes.Tipus); ;

            fejleszteses.ForEach(x =>
            {
                if (x.Kifejlesztve == false)
                    throw new InvalidOperationException("Another PowerUp is under development");

                if (x.GetType().ToString() == fejlesztesTipus)
                    throw new InvalidOperationException("You already have the chosen PowerUp");
            });

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

        }

        public async Task<List<FejlesztesInfoDTO>> GetFinishedFejlesztesesAsync(Orszag currentOrszag)
        {
            List<Fejlesztes> keszFejleszteses = currentOrszag.Fejleszteses.Where(x => x.Kifejlesztve == true).ToList();
            List<FejlesztesInfoDTO> keszDTOList = new List<FejlesztesInfoDTO>();

            foreach (var fejl in keszFejleszteses)
            {
                switch (fejl.GetType().Name)
                {
                    case "Alkimia":
                        keszDTOList.Add(new FejlesztesInfoDTO(FejlesztesTipus.Alkimia, false));
                        break;
                    case "IszapKombajn":
                        keszDTOList.Add(new FejlesztesInfoDTO(FejlesztesTipus.IszapKombajn, false));
                        break;
                    case "IszapTraktor":
                        keszDTOList.Add(new FejlesztesInfoDTO(FejlesztesTipus.IszapTraktor, false));
                        break;
                    case "KorallFal":
                        keszDTOList.Add(new FejlesztesInfoDTO(FejlesztesTipus.KorallFal, false));
                        break;
                    case "SzonarAgyu":
                        keszDTOList.Add(new FejlesztesInfoDTO(FejlesztesTipus.SzonarAgyu, false));
                        break;
                    case "VizalattiHarmuveszet":
                        keszDTOList.Add(new FejlesztesInfoDTO(FejlesztesTipus.VizalattiHarmuveszet, false));
                        break;
                    default:
                        throw new ArgumentException("Invalid fejlesztes type");
                }
            }
            return keszDTOList;
        }

        public async Task<bool> GetIfCurrentlyActiveFejlesztes(Orszag currentOrszag)
        {
             return currentOrszag.Fejleszteses.FirstOrDefault(x => x.Kifejlesztve == false) != null;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
