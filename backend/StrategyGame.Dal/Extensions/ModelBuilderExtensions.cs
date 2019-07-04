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
                }
                for (int j = 0; j < rnd.Next(0, 15); j++)
                {
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
                }

                for (int j = 0; j < rnd.Next(0, 15); j++)
                {
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

                for (int j = 0; j < rnd.Next(0, 15); j++)
                {
                    modelBuilder.Entity<Felfedezo>().HasData(
                           new
                           {
                               Id = Guid.NewGuid(),
                               Ar = 50L,
                               Tamadas = 0L,
                               Vedekezes = 0L,
                               Ellatas = 1L,
                               Zsold = 1L,
                               CsatakSzama = 0L,
                               Szint = 1L,
                               KemkedesiKepesseg = 5L,
                               Felfedezett = false,
                               CsapatId = new Guid($"00000000-0000-0000-0000-00000000000{i + 5}"),
                           }
                           );
                }

                for (int j = 0; j < rnd.Next(1, 4); j++)
                {
                    modelBuilder.Entity<Hadvezer>().HasData(
                            new
                            {
                                Id = Guid.NewGuid(),
                                Ar = 200L,
                                Tamadas = 0L,
                                Vedekezes = 0L,
                                Ellatas = 2L,
                                Zsold = 4L,
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
                         Ko = rnd.Next(50, 350),
                     }
                     );

                var aramlasId = Guid.NewGuid();
                var zatonyId = Guid.NewGuid();
                var koBanyaId = Guid.NewGuid();

                modelBuilder.Entity<AramlasIranyito>().HasData(
                    new
                    {
                        Id = aramlasId,
                        Felepult = true,
                        OrszagId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                        EpitoAnyag = 50L,
                        Ar = 1000L,
                        AktualisKor = 15L,
                        SzuksegesKorok = 5L
                    });


                modelBuilder.Entity<ZatonyVar>().HasData(
                    new
                    {
                        Id = zatonyId,
                        Felepult = true,
                        OrszagId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                        EpitoAnyag = 50L,
                        Ar = 1000L,
                        AktualisKor = 15L,
                        SzuksegesKorok = 5L
                    });

                modelBuilder.Entity<KoBanya>().HasData(
                    new
                    {
                        Id = koBanyaId,
                        Felepult = true,
                        OrszagId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                        EpitoAnyag = 0L,
                        Ar = 1000L,
                        AktualisKor = 15L,
                        SzuksegesKorok = 5L
                    });

                modelBuilder.Entity<NepessegTermelo>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        EpuletId = aramlasId,
                        Ertek = 50
                    });

                modelBuilder.Entity<KorallTermelo>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        EpuletId = aramlasId,
                        Ertek = 50
                    });

                modelBuilder.Entity<EgysegTermelo>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        EpuletId = zatonyId,
                        Ertek = 50
                    });

                modelBuilder.Entity<KoTermelo>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        EpuletId = koBanyaId,
                        Ertek = 50
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

                modelBuilder.Entity<Felfedezes>().HasData(
                   new
                   {
                       Id = new Guid($"00000000-0000-0000-0000-00300000000{i + 5}"),
                       OrszagId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                       Celpont = "asd",
                       VedekezoEro = 666L,
                       Gyongy = 1000L,
                       Korall= 999L,
                       Idopont= DateTime.Now
                   });
            }
        }
    }
}
