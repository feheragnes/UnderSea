﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrategyGame.Dal.Context;

namespace StrategyGame.Dal.Migrations
{
    [DbContext(typeof(StrategyGameContext))]
    partial class StrategyGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Identity.StrategyGameRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Identity.StrategyGameUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<Guid?>("OrszagId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("OrszagId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Allapot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Kimenetel");

                    b.HasKey("Id");

                    b.ToTable("Allapots");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Csapat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CelpontId");

                    b.Property<int>("Kimenetel");

                    b.Property<Guid?>("TulajdonosId");

                    b.HasKey("Id");

                    b.HasIndex("CelpontId");

                    b.HasIndex("TulajdonosId");

                    b.ToTable("Csapats");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Egysegek.Egyseg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Ar");

                    b.Property<Guid?>("CsapatId");

                    b.Property<long>("CsatakSzama");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("Ellatas");

                    b.Property<long>("Szint");

                    b.Property<long>("Tamadas");

                    b.Property<long>("Vedekezes");

                    b.Property<long>("Zsold");

                    b.HasKey("Id");

                    b.HasIndex("CsapatId");

                    b.ToTable("Egysegs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Egyseg");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Egysegek.EgysegInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Ar");

                    b.Property<long>("CsatakSzama");

                    b.Property<long>("Ellatas");

                    b.Property<long>("Szint");

                    b.Property<long>("Tamadas");

                    b.Property<int>("Tipus");

                    b.Property<long>("Vedekezes");

                    b.Property<long>("Zsold");

                    b.HasKey("Id");

                    b.ToTable("EgysegInfos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b36d5280-ea24-410e-9508-9f6e24691219"),
                            Ar = 50L,
                            CsatakSzama = 0L,
                            Ellatas = 1L,
                            Szint = 1L,
                            Tamadas = 6L,
                            Tipus = 0,
                            Vedekezes = 2L,
                            Zsold = 1L
                        },
                        new
                        {
                            Id = new Guid("befcb0a8-3249-44b3-9d17-86ee1d8bc9c6"),
                            Ar = 50L,
                            CsatakSzama = 0L,
                            Ellatas = 1L,
                            Szint = 1L,
                            Tamadas = 2L,
                            Tipus = 1,
                            Vedekezes = 6L,
                            Zsold = 1L
                        },
                        new
                        {
                            Id = new Guid("cb92f77e-24d3-4897-af7e-ee1c3468ef1b"),
                            Ar = 100L,
                            CsatakSzama = 0L,
                            Ellatas = 2L,
                            Szint = 1L,
                            Tamadas = 5L,
                            Tipus = 2,
                            Vedekezes = 5L,
                            Zsold = 3L
                        },
                        new
                        {
                            Id = new Guid("ae42a8bf-e4b3-4da3-9e7b-c6b301f51909"),
                            Ar = 50L,
                            CsatakSzama = 3L,
                            Ellatas = 1L,
                            Szint = 2L,
                            Tamadas = 8L,
                            Tipus = 0,
                            Vedekezes = 3L,
                            Zsold = 1L
                        },
                        new
                        {
                            Id = new Guid("9d4f3f63-88d3-462f-ad7b-41bf9907d7f0"),
                            Ar = 50L,
                            CsatakSzama = 3L,
                            Ellatas = 1L,
                            Szint = 2L,
                            Tamadas = 3L,
                            Tipus = 1,
                            Vedekezes = 8L,
                            Zsold = 1L
                        },
                        new
                        {
                            Id = new Guid("91677371-4e16-4cd8-9d52-200f208b115f"),
                            Ar = 100L,
                            CsatakSzama = 3L,
                            Ellatas = 2L,
                            Szint = 2L,
                            Tamadas = 7L,
                            Tipus = 2,
                            Vedekezes = 7L,
                            Zsold = 3L
                        },
                        new
                        {
                            Id = new Guid("679bdcee-05af-4651-9032-6b38052a9973"),
                            Ar = 50L,
                            CsatakSzama = 8L,
                            Ellatas = 1L,
                            Szint = 3L,
                            Tamadas = 10L,
                            Tipus = 0,
                            Vedekezes = 5L,
                            Zsold = 1L
                        },
                        new
                        {
                            Id = new Guid("a75f134e-6fa2-481c-9915-8326e76d4e4f"),
                            Ar = 50L,
                            CsatakSzama = 8L,
                            Ellatas = 1L,
                            Szint = 3L,
                            Tamadas = 5L,
                            Tipus = 1,
                            Vedekezes = 10L,
                            Zsold = 1L
                        },
                        new
                        {
                            Id = new Guid("f7ed9941-c9ef-4a6e-992d-6b684054290c"),
                            Ar = 100L,
                            CsatakSzama = 8L,
                            Ellatas = 2L,
                            Szint = 3L,
                            Tamadas = 10L,
                            Tipus = 2,
                            Vedekezes = 10L,
                            Zsold = 3L
                        });
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epuletek.Epulet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AktualisKor");

                    b.Property<long>("Ar");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("Felepult");

                    b.Property<Guid?>("OrszagId");

                    b.Property<long>("SzuksegesKorok");

                    b.HasKey("Id");

                    b.HasIndex("OrszagId");

                    b.ToTable("Epulets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Epulet");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AktualisKor");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("Kifejlesztve");

                    b.Property<Guid?>("OrszagId");

                    b.Property<long>("SzuksegesKorok");

                    b.HasKey("Id");

                    b.HasIndex("OrszagId");

                    b.ToTable("Fejleszteses");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Fejlesztes");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Jatek", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Korok");

                    b.HasKey("Id");

                    b.ToTable("Jateks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9c4c0ab1-5c85-430f-8788-6a929d98ca35"),
                            Korok = 0L
                        });
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.AbstractNovelo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("Ertek");

                    b.Property<Guid>("FejlesztesId");

                    b.HasKey("Id");

                    b.HasIndex("FejlesztesId");

                    b.ToTable("AbstractNovelo");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractNovelo");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.NoveloInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Ertek");

                    b.Property<int>("Tipus");

                    b.HasKey("Id");

                    b.ToTable("NoveloInfos");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Orszag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Gyongy");

                    b.Property<long>("Korall");

                    b.Property<string>("Nev");

                    b.Property<long>("Pont");

                    b.HasKey("Id");

                    b.ToTable("Orszags");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.EgysegTermelo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EpuletId");

                    b.Property<long>("Ertek");

                    b.HasKey("Id");

                    b.HasIndex("EpuletId")
                        .IsUnique();

                    b.ToTable("EgysegTermelos");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.KorallTermelo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EpuletId");

                    b.Property<long>("Ertek");

                    b.HasKey("Id");

                    b.HasIndex("EpuletId")
                        .IsUnique();

                    b.ToTable("KorallTermelos");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.NepessegTermelo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EpuletId");

                    b.Property<long>("Ertek");

                    b.HasKey("Id");

                    b.HasIndex("EpuletId")
                        .IsUnique();

                    b.ToTable("NepessegTermelos");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Egysegek.CsataCsiko", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Egysegek.Egyseg");

                    b.HasDiscriminator().HasValue("CsataCsiko");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Egysegek.LezerCapa", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Egysegek.Egyseg");

                    b.HasDiscriminator().HasValue("LezerCapa");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Egysegek.RohamFoka", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Egysegek.Egyseg");

                    b.HasDiscriminator().HasValue("RohamFoka");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epuletek.AramlasIranyito", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Epuletek.Epulet");

                    b.HasDiscriminator().HasValue("AramlasIranyito");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epuletek.ZatonyVar", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Epuletek.Epulet");

                    b.HasDiscriminator().HasValue("ZatonyVar");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.Alkimia", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.HasDiscriminator().HasValue("Alkimia");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.IszapKombajn", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.HasDiscriminator().HasValue("IszapKombajn");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.IszapTraktor", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.HasDiscriminator().HasValue("IszapTraktor");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.KorallFal", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.HasDiscriminator().HasValue("KorallFal");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.SzonarAgyu", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.HasDiscriminator().HasValue("SzonarAgyu");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.VizalattiHarcmuveszet", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.HasDiscriminator().HasValue("VizalattiHarcmuveszet");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.AdoNovelo", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Novelok.AbstractNovelo");

                    b.HasDiscriminator().HasValue("AdoNovelo");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.KorallNovelo", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Novelok.AbstractNovelo");

                    b.HasDiscriminator().HasValue("KorallNovelo");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.TamadasNovelo", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Novelok.AbstractNovelo");

                    b.HasDiscriminator().HasValue("TamadasNovelo");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.VedekezesNovelo", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Novelok.AbstractNovelo");

                    b.HasDiscriminator().HasValue("VedekezesNovelo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Identity.StrategyGameRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Identity.StrategyGameUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Identity.StrategyGameUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Identity.StrategyGameRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StrategyGame.Model.Entities.Identity.StrategyGameUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Identity.StrategyGameUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Identity.StrategyGameUser", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag", "Orszag")
                        .WithMany()
                        .HasForeignKey("OrszagId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Csapat", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag", "Celpont")
                        .WithMany("TamadoCsapats")
                        .HasForeignKey("CelpontId");

                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag", "Tulajdonos")
                        .WithMany("OtthoniCsapats")
                        .HasForeignKey("TulajdonosId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Egysegek.Egyseg", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Csapat")
                        .WithMany("Egysegs")
                        .HasForeignKey("CsapatId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epuletek.Epulet", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag", "Orszag")
                        .WithMany("Epulets")
                        .HasForeignKey("OrszagId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag", "Orszag")
                        .WithMany("Fejleszteses")
                        .HasForeignKey("OrszagId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.AbstractNovelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes", "Fejlesztes")
                        .WithMany("Novelo")
                        .HasForeignKey("FejlesztesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.EgysegTermelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Epuletek.ZatonyVar", "Epulet")
                        .WithOne("Szallas")
                        .HasForeignKey("StrategyGame.Model.Entities.Models.Termelok.EgysegTermelo", "EpuletId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.KorallTermelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Epuletek.AramlasIranyito", "Epulet")
                        .WithOne("Korall")
                        .HasForeignKey("StrategyGame.Model.Entities.Models.Termelok.KorallTermelo", "EpuletId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.NepessegTermelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Epuletek.AramlasIranyito", "Epulet")
                        .WithOne("Nepesseg")
                        .HasForeignKey("StrategyGame.Model.Entities.Models.Termelok.NepessegTermelo", "EpuletId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
