using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StrategyGame.Dal.EntityTypeConfigurations;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using StrategyGame.Model.Entities.Models.Novelok;
using StrategyGame.Model.Entities.Models.Termelok;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal.Context
{
    public class StrategyGameContext : IdentityDbContext<StrategyGameUser, StrategyGameRole, Guid>
    {
        public StrategyGameContext(DbContextOptions<StrategyGameContext> options)
            : base(options)
        {
        }

        public DbSet<Jatek> Jateks { get; set; }
        public DbSet<Egyseg> Egysegs { get; set; }
        public DbSet<Csapat> Csapats { get; set; }
        public DbSet<Epulet> Epulets { get; set; }
        public DbSet<Fejlesztes> Fejleszteses { get; set; }
        public DbSet<Orszag> Orszags { get; set; }
        public DbSet<Allapot> Allapots { get; set; }
        public DbSet<KorallTermelo> KorallTermelos {get;set;}
        public DbSet<NepessegTermelo> NepessegTermelos { get; set; }
        public DbSet<EgysegTermelo> EgysegTermelos { get; set; }
        public DbSet<KorallNovelo> KorallNovelos { get; set; }
        public DbSet<AdoNovelo> AdoNovelos { get; set; }
        public DbSet<TamadasNovelo> TamadasNovelos { get; set; }
        public DbSet<VedekezesNovelo> VedekezesNovelos { get; set; }
        public DbSet<EgysegInfo> EgysegInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AramlasIranyito>().HasBaseType<Epulet>();
            builder.Entity<ZatonyVar>().HasBaseType<Epulet>();
            builder.Entity<IszapTraktor>().HasBaseType<Fejlesztes>();
            builder.Entity<IszapKombajn>().HasBaseType<Fejlesztes>();
            builder.Entity<KorallFal>().HasBaseType<Fejlesztes>();
            builder.Entity<SzonarAgyu>().HasBaseType<Fejlesztes>();
            builder.Entity<VizalattiHarcmuveszet>().HasBaseType<Fejlesztes>();
            builder.Entity<Alkimia>().HasBaseType<Fejlesztes>();
            builder.Entity<RohamFoka>().HasBaseType<Egyseg>();
            builder.Entity<CsataCsiko>().HasBaseType<Egyseg>();
            builder.Entity<LezerCapa>().HasBaseType<Egyseg>();

            builder.Entity<NepessegTermelo>().HasOne(x => x.Epulet as AramlasIranyito).WithOne(x => x.Nepesseg);
            builder.Entity<KorallTermelo>().HasOne(x => x.Epulet as AramlasIranyito).WithOne(x => x.Korall);
            builder.Entity<EgysegTermelo>().HasOne(x => x.Epulet as ZatonyVar).WithOne(x => x.Szallas);

            builder.Entity<AdoNovelo>().HasOne(x => x.Fejlesztes as Alkimia).WithOne(x => x.Gyöngy);
            builder.Entity<KorallNovelo>().HasOne(x => x.Fejlesztes as IszapKombajn).WithOne(x => x.Korall);
            builder.Entity<KorallNovelo>().HasOne(x => x.Fejlesztes as IszapTraktor).WithOne(x => x.Korall);
            builder.Entity<TamadasNovelo>().HasOne(x => x.Fejlesztes as SzonarAgyu).WithOne(x => x.Tamadas);
            builder.Entity<TamadasNovelo>().HasOne(x => x.Fejlesztes as VizalattiHarcmuveszet).WithOne(x => x.Tamadas);
            builder.Entity<VedekezesNovelo>().HasOne(x => x.Fejlesztes as VizalattiHarcmuveszet).WithOne(x => x.Vedekezes);
            builder.Entity<VedekezesNovelo>().HasOne(x => x.Fejlesztes as KorallFal).WithOne(x => x.Vedekezes);

            // builder.ApplyConfiguration(new OrszagUserConfiguration());
            builder.ApplyConfiguration(new CsapatConfiguration());
            builder.Entity<EgysegInfo>().HasData
                (
                new EgysegInfo { Id =new Guid("00000000-0000-0000-0000-000000000001"), Tipus = EgysegTipus.RohamFoka, Ar = 50, Ellatas = 1, Zsold = 1, Tamadas = 6, Vedekezes = 2},
                new EgysegInfo { Id = new Guid("00000000-0000-0000-0000-000000000002"), Tipus = EgysegTipus.CsataCsiko, Ar = 50, Ellatas = 1, Zsold = 1, Tamadas = 2, Vedekezes = 6 },
                new EgysegInfo { Id = new Guid("00000000-0000-0000-0000-000000000003"), Tipus = EgysegTipus.LezerCapa, Ar = 100, Ellatas = 2, Zsold = 3, Tamadas = 5, Vedekezes = 5 }
                );
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
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
