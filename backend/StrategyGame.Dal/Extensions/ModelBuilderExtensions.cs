using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Entities.Models.Termelok;
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
                var csapatId = Guid.NewGuid();
                var aramlasId = Guid.NewGuid();
                var zatonyId = Guid.NewGuid();
                var koBanyaId = Guid.NewGuid();
                var orszagId = Guid.NewGuid();

                modelBuilder.Entity<Orszag>().HasData(
                     new Orszag
                     {
                         Nev = $"Tesztorszag{i}",
                         Id = orszagId,
                         Korall = rnd.Next(100, 2000),
                         Gyongy = rnd.Next(1000, 5000),
                         Ko = rnd.Next(50, 350),
                     });

                modelBuilder.Entity<Csapat>().HasData(
                   new
                   {
                       Id = csapatId,
                       Kimenetel = HarcEredmenyTipus.Otthon,
                       TulajdonosId = orszagId,
                       RaboltGyongy = 0L,
                       RaboltKorall = 0L
                   });

                for (int j = 0; j < rnd.Next(0, 15); j++)
                {
                    modelBuilder.Entity<RohamFoka>().HasData(
                            new
                            {
                                Id = Guid.NewGuid(),
                                BirtokosCsapatId = csapatId,
                                Ar = 50L,
                                Tamadas = 6L,
                                Vedekezes = 2L,
                                Ellatas = 1L,
                                Zsold = 1L,
                                CsatakSzama = 0L,
                                Szint = 1L
                            });
                        }

                for (int j = 0; j < rnd.Next(0, 15); j++)
                {
                    modelBuilder.Entity<CsataCsiko>().HasData(
                            new
                            {
                                Id = Guid.NewGuid(),
                                BirtokosCsapatId = csapatId,
                                Ar = 50L,
                                Tamadas = 2L,
                                Vedekezes = 6L,
                                Ellatas = 1L,
                                Zsold = 1L,
                                CsatakSzama = 0L,
                                Szint = 1L
                            });
                }

                for (int j = 0; j < rnd.Next(0, 15); j++)
                {
                    modelBuilder.Entity<LezerCapa>().HasData(
                            new
                            {
                                Id = Guid.NewGuid(),
                                BirtokosCsapatId = csapatId,
                                Ar = 100L,
                                Tamadas = 5L,
                                Vedekezes = 5L,
                                Ellatas = 2L,
                                Zsold = 3L,
                                CsatakSzama = 0L,
                                Szint = 1L
                            });
                }

                for (int j = 0; j < rnd.Next(0, 15); j++)
                {
                    modelBuilder.Entity<Felfedezo>().HasData(
                           new
                           {
                               Id = Guid.NewGuid(),
                               BirtokosCsapatId = csapatId,
                               Ar = 50L,
                               Tamadas = 0L,
                               Vedekezes = 0L,
                               Ellatas = 1L,
                               Zsold = 1L,
                               CsatakSzama = 0L,
                               Szint = 1L,
                               KemkedesiKepesseg = 5L,
                               Felfedezett = false
                           });
                }

                for (int j = 0; j < rnd.Next(1, 4); j++)
                {
                    modelBuilder.Entity<Hadvezer>().HasData(
                            new
                            {
                                Id = Guid.NewGuid(),
                                BirtokosCsapatId = csapatId,
                                Ar = 200L,
                                Tamadas = 0L,
                                Vedekezes = 0L,
                                Ellatas = 2L,
                                Zsold = 4L,
                                CsatakSzama = 0L,
                                Szint = 1L
                            });

                }

                modelBuilder.Entity<AramlasIranyito>().HasData(
                    new
                    {
                        Id = aramlasId,
                        Felepult = true,
                        OrszagId = orszagId,
                        Epitoanyag = 50L,
                        Ar = 1000L,
                        AktualisKor = 15L,
                        SzuksegesKorok = 5L
                    });

                modelBuilder.Entity<ZatonyVar>().HasData(
                    new
                    {
                        Id = zatonyId,
                        Felepult = true,
                        OrszagId = orszagId,
                        Epitoanyag = 50L,
                        Ar = 1000L,
                        AktualisKor = 15L,
                        SzuksegesKorok = 5L
                    });

                modelBuilder.Entity<KoBanya>().HasData(
                    new
                    {
                        Id = koBanyaId,
                        Felepult = true,
                        OrszagId = orszagId,
                        Epitoanyag = 0L,
                        Ar = 1000L,
                        AktualisKor = 15L,
                        SzuksegesKorok = 5L
                    });

                modelBuilder.Entity<NepessegTermelo>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        EpuletId = aramlasId,
                        Ertek = 50L
                    });

                modelBuilder.Entity<KorallTermelo>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        EpuletId = aramlasId,
                        Ertek = 50L
                    });

                modelBuilder.Entity<EgysegTermelo>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        EpuletId = zatonyId,
                        Ertek = 50L
                    });

                modelBuilder.Entity<KoTermelo>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        EpuletId = koBanyaId,
                        Ertek = 50L
                    });

                modelBuilder.Entity<Felfedezes>().HasData(
                   new
                   {
                       Id = Guid.NewGuid(),
                       OrszagId = orszagId,
                       Celpont = "asd",
                       VedekezoEro = 666L,
                       Gyongy = 1000L,
                       Korall = 999L,
                       Idopont = DateTime.Now
                   });
            }
        }
    }
}
