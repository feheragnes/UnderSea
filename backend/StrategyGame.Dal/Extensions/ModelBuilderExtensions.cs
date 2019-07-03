using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal.Extensons
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                List<Egyseg> egysegs = new List<Egyseg>();
                for (int j = 0; j < rnd.Next(0, 15); j++)
                {
                    modelBuilder.Entity<RohamFoka>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        Ar = 50L,
                        Tamadas = 6L,
                        Vedekezes = 2L,
                        Ellatas = 1L,
                        Zsold = 1L,
                        CsatakSzama = 0L,
                        Szint = 1L,
                        
                        CsapatId = new Guid($"00000000-0000-0000-0000-00000000000{i + 5}"),
                    }
                    );

                    modelBuilder.Entity<CsataCsiko>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        Ar = 50L,
                        Tamadas = 2L,
                        Vedekezes = 6L,
                        Ellatas = 1L,
                        Zsold = 1L,
                        CsatakSzama = 0L,
                        Szint = 1L,
                        CsapatId = new Guid($"00000000-0000-0000-0000-00000000000{i + 5}"),
                    }
                    );

                    modelBuilder.Entity<LezerCapa>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        Ar = 100L,
                        Tamadas = 5L,
                        Vedekezes = 5L,
                        Ellatas = 2L,
                        Zsold = 3L,
                        CsatakSzama = 0L,
                        Szint = 1L,
                        CsapatId = new Guid($"00000000-0000-0000-0000-00000000000{i + 5}"),
                    }
                    );
                }

                modelBuilder.Entity<Orszag>().HasData(
                     new Orszag
                     {
                         Nev = $"Tesztorszag{i}",
                         Id = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                         Korall = rnd.Next(100, 2000),
                         Gyongy = rnd.Next(1000, 5000),
                     }
                     );

                modelBuilder.Entity<AramlasIranyito>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        Felepult = true,
                        OrszagId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                        Ar = 1000L,
                        AktualisKor = 15L,
                        SzuksegesKorok = 15L
                    });



                modelBuilder.Entity<ZatonyVar>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        Felepult = true,
                        OrszagId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                        Ar = 1000L,
                        AktualisKor = 15L,
                        SzuksegesKorok = 15L
                    });

                modelBuilder.Entity<Csapat>().HasData(
                    new
                    {
                        Id = new Guid($"00000000-0000-0000-0000-00000000000{i + 5}"),
                        Kimenetel = HarcEredmenyTipus.Otthon,
                        TulajdonosId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                        RaboltGyongy = 0L,
                        RaboltKorall = 0L
                    });

            }
        }
    }
}
