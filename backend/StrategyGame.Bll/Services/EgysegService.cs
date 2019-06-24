using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.DTOs.DTOEnums;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Csapat otthoniEgysegek = currentOrszag.OtthoniCsapats.FirstOrDefault(T => T.Celpont == null);

            long osszKoltseg = 0;
            egysegek.ForEach(x =>
            {
                osszKoltseg += (x.Ar * x.Mennyiseg);
            });

            if (osszKoltseg > currentOrszag.Gyongy)
                throw new ArgumentException("You don't have enough Gyöngy");

            var rohamFokas = egysegek.FindAll(e => e.Tipus == EgysegTipus.RohamFoka);
            var csataCsikos = egysegek.FindAll(e => e.Tipus == EgysegTipus.CsataCsiko);
            var lezerCapas = egysegek.FindAll(e => e.Tipus == EgysegTipus.LezerCapa);

            rohamFokas.ForEach(x =>
            {
                otthoniEgysegek.Egysegs.Add(new RohamFoka());
            });
            csataCsikos.ForEach(x =>
            {
                otthoniEgysegek.Egysegs.Add(new CsataCsiko());
            });
            lezerCapas.ForEach(x =>
            {
                otthoniEgysegek.Egysegs.Add(new LezerCapa());
            });

            currentOrszag.Gyongy -= osszKoltseg;

            await SaveChangesAsync();
        }

        public async Task<List<EgysegDTO>> GetAllEgysegsAsync(Orszag currentOrszag)
        {
            List<Csapat> otthoniCsapats = new List<Csapat>(currentOrszag.OtthoniCsapats);
            List<Egyseg> egysegList = new List<Egyseg>();

            otthoniCsapats.ForEach(x =>
            {
                foreach (var egyseg in x.Egysegs)
                {
                    egysegList.Add(egyseg);
                }
            });

            var egysegDtoList = _mapper.Map<List<Egyseg>, List<EgysegDTO>>(egysegList);

            return egysegDtoList;
        }

        public async Task<List<SeregInfoDTO>> GetOtthoniEgysegsAsync(Orszag currentOrszag)
        {
            Csapat otthoniEgysegek = currentOrszag.OtthoniCsapats.FirstOrDefault(T => T.Celpont == null);

            long rohamFokaMennyiseg = 0, csataCsikoMennyiseg = 0, lezerCapaMennyiseg = 0;

            otthoniEgysegek.Egysegs.ToList().ForEach(x =>
            {
                if (x.GetType() == typeof(RohamFoka))
                    rohamFokaMennyiseg++;
                if (x.GetType() == typeof(CsataCsiko))
                    csataCsikoMennyiseg++;
                if (x.GetType() == typeof(LezerCapa))
                    lezerCapaMennyiseg++;
            });

            List<SeregInfoDTO> seregInfo = new List<SeregInfoDTO>();
            seregInfo.Add(new SeregInfoDTO(rohamFokaMennyiseg, 50, EgysegTipus.RohamFoka));
            seregInfo.Add(new SeregInfoDTO(csataCsikoMennyiseg, 50, EgysegTipus.CsataCsiko));
            seregInfo.Add(new SeregInfoDTO(lezerCapaMennyiseg, 100, EgysegTipus.LezerCapa));

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