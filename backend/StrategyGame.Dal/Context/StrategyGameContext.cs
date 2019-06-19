using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Model.Entities.Identity;
using StrategyGame.Model.Entities.Models;
using StrategyGame.Model.Entities.Models.Egysegek;
using StrategyGame.Model.Entities.Models.Epületek;
using StrategyGame.Model.Entities.Models.Fejlesztesek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal.Context
{
    public class StrategyGameContext : IdentityDbContext<StrategyGameUser,StrategyGameRole,Guid>
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

            builder.Entity<OrszagUser>()
                .HasKey(ou => new { ou.OrszagId, ou.UserId });
            builder.Entity<OrszagUser>()
                .HasOne(ou => ou.Orszag)
                .WithMany(o => o.Users)
                .HasForeignKey(ou => ou.OrszagId);
            builder.Entity<OrszagUser>()
                .HasOne(ou => ou.User)
                .WithMany(u => u.Orszags)
                .HasForeignKey(ou => ou.UserId);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
