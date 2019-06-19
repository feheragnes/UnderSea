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

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Csapat", b =>
                {
                    b.Property<int>("CsapatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllapotId");

                    b.Property<int>("CelpontId");

                    b.Property<int?>("OrszagId");

                    b.HasKey("CsapatId");

                    b.HasIndex("OrszagId");

                    b.ToTable("Csapats");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Egyseg", b =>
                {
                    b.Property<int>("EgysegId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ar");

                    b.Property<int?>("CsapatId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Ellatas");

                    b.Property<int>("Tamadas");

                    b.Property<int>("Vedekezes");

                    b.Property<int>("Zsold");

                    b.HasKey("EgysegId");

                    b.HasIndex("CsapatId");

                    b.ToTable("Egysegs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Egyseg");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epulet", b =>
                {
                    b.Property<int>("EpuletId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ar");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Korok");

                    b.Property<int?>("OrszagId");

                    b.HasKey("EpuletId");

                    b.HasIndex("OrszagId");

                    b.ToTable("Epulets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Epulet");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztes", b =>
                {
                    b.Property<int>("FejlesztesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Korok");

                    b.Property<int?>("OrszagId");

                    b.HasKey("FejlesztesId");

                    b.HasIndex("OrszagId");

                    b.ToTable("Fejleszteses");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Fejlesztes");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Jatek", b =>
                {
                    b.Property<int>("JatekId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Korok");

                    b.HasKey("JatekId");

                    b.ToTable("Jateks");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Orszag", b =>
                {
                    b.Property<int>("OrszagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gyongy");

                    b.Property<int>("Korall");

                    b.HasKey("OrszagId");

                    b.ToTable("Orszags");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.OrszagUser", b =>
                {
                    b.Property<int>("OrszagId");

                    b.Property<Guid>("UserId");

                    b.HasKey("OrszagId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OrszagUser");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.CsataCsiko", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Egyseg");

                    b.HasDiscriminator().HasValue("CsataCsiko");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.LezerCapa", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Egyseg");

                    b.HasDiscriminator().HasValue("LezerCapa");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.RohamFoka", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Egyseg");

                    b.HasDiscriminator().HasValue("RohamFoka");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.AramlasIranyito", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Epulet");

                    b.Property<int>("Korall");

                    b.Property<int>("Nepesseg");

                    b.HasDiscriminator().HasValue("AramlasIranyito");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.ZatonyVar", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Epulet");

                    b.Property<int>("Szallas");

                    b.HasDiscriminator().HasValue("ZatonyVar");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Alkimia", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztes");

                    b.Property<int>("Ado");

                    b.HasDiscriminator().HasValue("Alkimia");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.IszapKombajn", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztes");

                    b.Property<int>("Korall");

                    b.HasDiscriminator().HasValue("IszapKombajn");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.IszapTraktor", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztes");

                    b.Property<int>("Korall")
                        .HasColumnName("IszapTraktor_Korall");

                    b.HasDiscriminator().HasValue("IszapTraktor");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.KorallFal", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztes");

                    b.Property<int>("Vedelem");

                    b.HasDiscriminator().HasValue("KorallFal");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.SzonarAgyu", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztes");

                    b.Property<int>("Tamadas");

                    b.HasDiscriminator().HasValue("SzonarAgyu");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.VizalattiHarcmuveszet", b =>
                {
                    b.HasBaseType("StrategyGame.Model.Entities.Models.Fejlesztes");

                    b.Property<int>("Tamadas")
                        .HasColumnName("VizalattiHarcmuveszet_Tamadas");

                    b.Property<int>("Vedekezes");

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

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Csapat", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag")
                        .WithMany("Csapats")
                        .HasForeignKey("OrszagId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Egyseg", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Csapat")
                        .WithMany("Egysegs")
                        .HasForeignKey("CsapatId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Epulet", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag")
                        .WithMany("Epulets")
                        .HasForeignKey("OrszagId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.Fejlesztes", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag")
                        .WithMany("Fejleszteses")
                        .HasForeignKey("OrszagId");
                });

            modelBuilder.Entity("StrategyGame.Model.Entities.Models.OrszagUser", b =>
                {
                    b.HasOne("StrategyGame.Model.Entities.Models.Orszag", "Orszag")
                        .WithMany("Users")
                        .HasForeignKey("OrszagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StrategyGame.Model.Entities.Identity.StrategyGameUser", "User")
                        .WithMany("Orszags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
