using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class EgysegService : IEgysegService
    {
        private readonly StrategyGameContext _context;
        private readonly IMapper _mapper;

        public EgysegService(StrategyGameContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }
        public async Task AddEgysegAsync(List<SeregInfoDTO> egysegek, Orszag currentOrszag)
        {
            List<Csapat> otthoniCsapatok = new List<Csapat>(currentOrszag.OtthoniCsapats);

            long osszKoltseg = 0;
            foreach (var item in egysegek)
            {
                osszKoltseg += (item.Ar * item.Mennyiseg);
            }

            if(osszKoltseg > currentOrszag.Gyongy)
               throw new ArgumentException("You don't have enough Gyöngy");

            for(int i=0; i< egysegek[0].Mennyiseg; i++)
            {
                otthoniCsapatok.Find(T => T.Celpont == null).Egysegs.Add(new RohamFoka { Tamadas = 6, Vedekezes = 2, Ar = 50, Ellatas= 1, Zsold=1 });  ;
            }

            for (int i = 0; i < egysegek[1].Mennyiseg; i++)
            {
                otthoniCsapatok.Find(T => T.Celpont == null).Egysegs.Add(new CsataCsiko { Tamadas = 6, Vedekezes = 2, Ar = 50, Ellatas = 1, Zsold = 1 });
            }

            for (int i = 0; i < egysegek[2].Mennyiseg; i++)
            {
                otthoniCsapatok.Find(T => T.Celpont == null).Egysegs.Add(new LezerCapa { Tamadas = 5, Vedekezes = 5, Ar = 100, Ellatas = 2, Zsold = 3 });
            }

            await SaveChangesAsync();

        }

        public async Task<List<EgysegDTO>> GetAllEgysegsAsync(Orszag currentOrszag)
        {
            List<Csapat> otthoniCsapats = new List<Csapat>(currentOrszag.OtthoniCsapats);
            List<Egyseg> egysegList = new List<Egyseg>();
            foreach (var csapat in otthoniCsapats)
            {
                foreach (var egyseg in csapat.Egysegs)
                {
                    egysegList.Add(egyseg);
                }
            }

            var egysegDtoList = _mapper.Map<List<Egyseg>, List<EgysegDTO>>(egysegList);

             return egysegDtoList;
        }

        public async Task<List<SeregInfoDTO>> GetOtthoniEgysegsAsync(Orszag currentOrszag)
        {

            List<Csapat> otthoniCsapatok = new List<Csapat>(currentOrszag.OtthoniCsapats);

            long rohamFokaMennyiseg = 0;
            long csataCsikoMennyiseg = 0;
            long lezerCapaMennyiseg = 0;

            var otthonMaradtCsapat = otthoniCsapatok.Find(T => T.Celpont == null);

            foreach (var item in otthonMaradtCsapat.Egysegs)
            {
                if (item.GetType() == typeof(RohamFoka))
                    rohamFokaMennyiseg++;
                if (item.GetType() == typeof(CsataCsiko))
                    csataCsikoMennyiseg++;
                if (item.GetType() == typeof(LezerCapa))
                    lezerCapaMennyiseg++;
            }

            List<SeregInfoDTO> seregInfo = new List<SeregInfoDTO>();
            seregInfo.Add(new SeregInfoDTO(rohamFokaMennyiseg, 50, "RohamFoka"));
            seregInfo.Add(new SeregInfoDTO(csataCsikoMennyiseg, 50, "CsataCsiko"));
            seregInfo.Add(new SeregInfoDTO(lezerCapaMennyiseg, 100, "LezerCapa"));

            return seregInfo;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception("Concurrency error");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
;