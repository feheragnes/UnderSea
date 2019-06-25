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

                    b.Property<Guid?>("AllapotId");

                    b.Property<Guid?>("CelpontId");

                    b.Property<Guid?>("TulajdonosId");

                    b.HasKey("Id");

                    b.HasIndex("AllapotId");

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

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("Ellatas");

                    b.Property<long>("Tamadas");

                    b.Property<long>("Vedekezes");

                    b.Property<long>("Zsold");

                    b.HasKey("Id");

                    b.HasIndex("CsapatId");

                    b.ToTable("Egysegs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Egyseg");
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
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.AdoNovelo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ertek");

                    b.Property<Guid?>("FejlesztesId");

                    b.HasKey("id");

                    b.HasIndex("FejlesztesId");

                    b.ToTable("AdoNovelo");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.KorallNovelo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ertek");

                    b.Property<Guid?>("FejlesztesId");

                    b.HasKey("id");

                    b.HasIndex("FejlesztesId");

                    b.ToTable("KorallNovelo");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.TamadasNovelo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ertek");

                    b.Property<Guid?>("FejlesztesId");

                    b.HasKey("id");

                    b.HasIndex("FejlesztesId");

                    b.ToTable("TamadasNovelo");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.VedekezesNovelo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ertek");

                    b.Property<Guid?>("FejlesztesId");

                    b.HasKey("id");

                    b.HasIndex("FejlesztesId");

                    b.ToTable("VedekezesNovelo");
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
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Ertek");

                    b.Property<Guid?>("epuletId");

                    b.HasKey("id");

                    b.HasIndex("epuletId");

                    b.ToTable("EgysegTermelo");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.KorallTermelo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Ertek");

                    b.Property<Guid?>("epuletId");

                    b.HasKey("id");

                    b.HasIndex("epuletId");

                    b.ToTable("KorallTermelos");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.NepessegTermelo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Ertek");

                    b.Property<Guid?>("epuletId");

                    b.HasKey("id");

                    b.HasIndex("epuletId");

                    b.ToTable("NepessegTermelo");
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

                    b.Property<Guid?>("Korallid");

                    b.Property<Guid?>("Nepessegid");

                    b.HasIndex("Korallid");

                    b.HasIndex("Nepessegid");

                    b.HasDiscriminator().HasValue("AramlasIranyito");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epuletek.ZatonyVar", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Epuletek.Epulet");

                    b.Property<Guid?>("Szallasid");

                    b.HasIndex("Szallasid");

                    b.HasDiscriminator().HasValue("ZatonyVar");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.Alkimia", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.Property<Guid?>("Gyöngyid");

                    b.HasIndex("Gyöngyid");

                    b.HasDiscriminator().HasValue("Alkimia");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.IszapKombajn", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.Property<Guid?>("Korallid");

                    b.HasIndex("Korallid");

                    b.HasDiscriminator().HasValue("IszapKombajn");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.IszapTraktor", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.Property<Guid?>("Korallid")
                        .HasColumnName("IszapTraktor_Korallid");

                    b.HasIndex("Korallid");

                    b.HasDiscriminator().HasValue("IszapTraktor");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.KorallFal", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.Property<Guid?>("Vedekezesid");

                    b.HasIndex("Vedekezesid");

                    b.HasDiscriminator().HasValue("KorallFal");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.SzonarAgyu", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.Property<Guid?>("Tamadasid");

                    b.HasIndex("Tamadasid");

                    b.HasDiscriminator().HasValue("SzonarAgyu");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.VizalattiHarcmuveszet", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes");

                    b.HasDiscriminator().HasValue("VizalattiHarcmuveszet");
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
                    b.HasOne("StrategyGame.Model.Entities.Models.Allapot", "Allapot")
                        .WithMany()
                        .HasForeignKey("AllapotId");

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
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag")
                        .WithMany("Fejleszteses")
                        .HasForeignKey("OrszagId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.AdoNovelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes", "Fejlesztes")
                        .WithMany()
                        .HasForeignKey("FejlesztesId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.KorallNovelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes", "Fejlesztes")
                        .WithMany()
                        .HasForeignKey("FejlesztesId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.TamadasNovelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes", "Fejlesztes")
                        .WithMany()
                        .HasForeignKey("FejlesztesId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Novelok.VedekezesNovelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Fejlesztesek.Fejlesztes", "Fejlesztes")
                        .WithMany()
                        .HasForeignKey("FejlesztesId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.EgysegTermelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Epuletek.Epulet", "epulet")
                        .WithMany()
                        .HasForeignKey("epuletId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.KorallTermelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Epuletek.Epulet", "epulet")
                        .WithMany()
                        .HasForeignKey("epuletId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Termelok.NepessegTermelo", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Epuletek.Epulet", "epulet")
                        .WithMany()
                        .HasForeignKey("epuletId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epuletek.AramlasIranyito", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Termelok.KorallTermelo", "Korall")
                        .WithMany()
                        .HasForeignKey("Korallid");

                    b.HasOne("StrategyGame.Model.Entities.Models.Termelok.NepessegTermelo", "Nepesseg")
                        .WithMany()
                        .HasForeignKey("Nepessegid");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epuletek.ZatonyVar", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Termelok.EgysegTermelo", "Szallas")
                        .WithMany()
                        .HasForeignKey("Szallasid");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.Alkimia", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Novelok.AdoNovelo", "Gyöngy")
                        .WithMany()
                        .HasForeignKey("Gyöngyid");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.IszapKombajn", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Novelok.KorallNovelo", "Korall")
                        .WithMany()
                        .HasForeignKey("Korallid");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.IszapTraktor", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Novelok.KorallNovelo", "Korall")
                        .WithMany()
                        .HasForeignKey("Korallid");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.KorallFal", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Novelok.VedekezesNovelo", "Vedekezes")
                        .WithMany()
                        .HasForeignKey("Vedekezesid");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztesek.SzonarAgyu", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Novelok.TamadasNovelo", "Tamadas")
                        .WithMany()
                        .HasForeignKey("Tamadasid");
                });
#pragma warning restore 612, 618
        }
    }
}
