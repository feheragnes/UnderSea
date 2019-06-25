using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StrategyGame.Dal.EntityTypeConfigurations;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Entities.Models.Epuletek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using StrategyGame.Model.Entities.Models.Termelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal.Context
{
    public class StrategyGameContext : IdentityDbContext<StrategyGameUser, StrategyGameRole, Guid>, IStrategyGameContext
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

           // builder.ApplyConfiguration(new OrszagUserConfiguration());
            builder.ApplyConfiguration(new CsapatConfiguration());
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
