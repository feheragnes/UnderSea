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
                        Ar = long.Parse("50"),
                        Tamadas = long.Parse("6"),
                        Vedekezes = long.Parse("2"),
                        Ellatas = long.Parse("1"),
                        Zsold = long.Parse("1"),
                        CsapatId = new Guid($"00000000-0000-0000-0000-00000000000{i + 5}"),
                    }
                    );

                    modelBuilder.Entity<RohamFoka>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        Ar = long.Parse("50"),
                        Tamadas = long.Parse("2"),
                        Vedekezes = long.Parse("6"),
                        Ellatas = long.Parse("1"),
                        Zsold = long.Parse("1"),
                        CsapatId = new Guid($"00000000-0000-0000-0000-00000000000{i + 5}"),
                    }
                    );

                    modelBuilder.Entity<RohamFoka>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        Ar = long.Parse("100"),
                        Tamadas = long.Parse("5"),
                        Vedekezes = long.Parse("5"),
                        Ellatas = long.Parse("2"),
                        Zsold = long.Parse("3"),
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
                        Ar = long.Parse("1000"),
                        AktualisKor = long.Parse("15"),
                        SzuksegesKorok = long.Parse("15"),
                    });



                modelBuilder.Entity<ZatonyVar>().HasData(
                    new
                    {
                        Id = Guid.NewGuid(),
                        Felepult = true,
                        OrszagId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                        Ar = long.Parse("1000"),
                        AktualisKor = long.Parse("15"),
                        SzuksegesKorok = long.Parse("15"),
                    });

                modelBuilder.Entity<Csapat>().HasData(
                    new
                    {
                        Id = new Guid($"00000000-0000-0000-0000-00000000000{i + 5}"),
                        Kimenetel = HarcEredmenyTipus.Otthon,
                        TulajdonosId = new Guid($"00000000-0000-0000-0000-00000000000{i + 1}"),
                    });

            }
        }
    }
}
