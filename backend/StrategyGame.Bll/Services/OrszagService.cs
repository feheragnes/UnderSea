using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.DTOs.Epuletek;
using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class OrszagService: IOrszagService
    {
        private readonly StrategyGameContext _context;
        private readonly IMapper _mapper;

        public OrszagService(StrategyGameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrszagUser> MakeOrszagUserConnection(StrategyGameUser user, string orszagnev)
        {
            var orszaguser = new OrszagUser { User = user, Orszag = InitOrszag(orszagnev).Result };
            user.Orszags.Add(orszaguser);
            await _context.SaveChangesAsync();
            return orszaguser;
        }
        public  async Task<Orszag> InitOrszag(string orszagnev)
        {
            var orszag = new Orszag { Nev = orszagnev, Korall = 0, Gyongy = 0 };
            if (_context.Orszags.FirstOrDefault(x => x.Nev.ToUpper() == orszagnev.ToUpper()) == null)
            {
                await _context.Orszags.AddAsync(orszag);
                await _context.SaveChangesAsync();
                return orszag;
            }
            throw new ArgumentException("Country already exists");
        }
        public async Task<OrszagDTO> Map(Orszag orszag)
        {
            var orszagdto = new OrszagDTO
            {
                Gyongy = orszag.Gyongy,
                Nev = orszag.Nev,
                Korall = orszag.Korall,
                Helyezes = await GetHelyezes(orszag),
                GyongyTermeles = GetTermeles(orszag).Result.GyongyTermeles,
                KorallTermeles = GetTermeles(orszag).Result.KorallTermeles,
                SeregInfoDTOs = await GetSeregInfoDTOs(orszag)
            };
            return orszagdto;
        }
        private async Task<long> GetHelyezes(Orszag orszag)
        {
            return 0;
        }
        private async Task<OrszagDTO> GetTermeles(Orszag orszag)
        {
            orszag = _context.Orszags.Include(x => x.Epulets).Include(x => x.Fejleszteses).FirstOrDefault(x => x.Id == orszag.Id);
            var orszagdto = new OrszagDTO();
            var epuletdtolist = _mapper.Map<IList<Epulet>, IList<EpuletDTO>>(orszag.Epulets);
            foreach (var item in epuletdtolist)
            {
                orszagdto = await item.SetTermeles(orszagdto);
            }
            var fejlesztesdtolist = _mapper.Map<IList<Fejlesztes>, IList<FejlesztesDTO>>(orszag.Fejleszteses);
            foreach (var item in fejlesztesdtolist)
            {
                orszagdto = await item.SetTermeles(orszagdto);
            }

            return orszagdto;
        }
        private async Task<IList<SeregInfoDTO>> GetSeregInfoDTOs(Orszag orszag)
        {
            return null;
        }
    }
}
