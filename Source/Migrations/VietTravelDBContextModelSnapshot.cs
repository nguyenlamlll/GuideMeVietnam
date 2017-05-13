using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VietTravel;

namespace Source.Migrations
{
    [DbContext(typeof(VietTravelDBContext))]
    partial class VietTravelDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("VietTravel.DBModels.ACCOUNT", b =>
                {
                    b.Property<short>("accountID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("pass");

                    b.Property<string>("userName");

                    b.HasKey("accountID");

                    b.ToTable("ACCOUNTs");
                });

            modelBuilder.Entity("VietTravel.DBModels.APPRECIATION", b =>
                {
                    b.Property<short>("appreciaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("appreciaSubject");

                    b.Property<string>("content");

                    b.Property<short?>("locationID");

                    b.Property<short?>("numStar");

                    b.Property<short?>("userID");

                    b.HasKey("appreciaID");

                    b.HasIndex("locationID");

                    b.HasIndex("userID");

                    b.ToTable("APPRECIATIONs");
                });

            modelBuilder.Entity("VietTravel.DBModels.ARTICLE", b =>
                {
                    b.Property<short>("articleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content");

                    b.Property<short?>("locationID");

                    b.HasKey("articleID");

                    b.HasIndex("locationID");

                    b.ToTable("ARTICLEs");
                });

            modelBuilder.Entity("VietTravel.DBModels.CITY", b =>
                {
                    b.Property<short>("cityID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("cityName");

                    b.Property<float?>("latitude");

                    b.Property<float?>("longitude");

                    b.Property<float?>("populationCity");

                    b.Property<short?>("provinceID");

                    b.Property<float?>("totalArea");

                    b.HasKey("cityID");

                    b.HasIndex("provinceID");

                    b.ToTable("CITies");
                });

            modelBuilder.Entity("VietTravel.DBModels.ICON", b =>
                {
                    b.Property<short>("iconID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("iconSource");

                    b.HasKey("iconID");

                    b.ToTable("ICONs");
                });

            modelBuilder.Entity("VietTravel.DBModels.IMAGE", b =>
                {
                    b.Property<short>("imageID")
                        .ValueGeneratedOnAdd();

                    b.Property<short?>("articleID");

                    b.Property<string>("imageSource");

                    b.HasKey("imageID");

                    b.HasIndex("articleID");

                    b.ToTable("IMAGES");
                });

            modelBuilder.Entity("VietTravel.DBModels.LOCATION", b =>
                {
                    b.Property<short>("locationID")
                        .ValueGeneratedOnAdd();

                    b.Property<float?>("latitude");

                    b.Property<string>("locationAddress");

                    b.Property<string>("locationName");

                    b.Property<float?>("longitude");

                    b.Property<string>("phoneNumber");

                    b.Property<decimal?>("priceMax");

                    b.Property<decimal?>("priceMin");

                    b.Property<short?>("provinceID");

                    b.Property<short?>("typeID");

                    b.Property<string>("website");

                    b.HasKey("locationID");

                    b.HasIndex("provinceID");

                    b.HasIndex("typeID");

                    b.ToTable("LOCATIONS");
                });

            modelBuilder.Entity("VietTravel.DBModels.LOCATION_TYPE", b =>
                {
                    b.Property<short>("typeID")
                        .ValueGeneratedOnAdd();

                    b.Property<short?>("iconID");

                    b.Property<string>("typeName");

                    b.HasKey("typeID");

                    b.HasIndex("iconID");

                    b.ToTable("LOCATION_TYPE");
                });

            modelBuilder.Entity("VietTravel.DBModels.MAP", b =>
                {
                    b.Property<short>("mapID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("latitude");

                    b.Property<decimal?>("longtitude");

                    b.Property<string>("mapName");

                    b.HasKey("mapID");

                    b.ToTable("MAPs");
                });

            modelBuilder.Entity("VietTravel.DBModels.PLAN_TRIP", b =>
                {
                    b.Property<short>("planID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("detail");

                    b.Property<string>("planName");

                    b.Property<short?>("userID");

                    b.HasKey("planID");

                    b.HasIndex("userID");

                    b.ToTable("PLAN_TRIP");
                });

            modelBuilder.Entity("VietTravel.DBModels.PROVINCE", b =>
                {
                    b.Property<short>("provinceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("imageSource");

                    b.Property<string>("intro");

                    b.Property<float?>("latitude");

                    b.Property<float?>("longtitude");

                    b.Property<float?>("populationProvince");

                    b.Property<string>("provinceName");

                    b.Property<short?>("regionID");

                    b.Property<string>("suggestSentence");

                    b.Property<float?>("totalArea");

                    b.HasKey("provinceID");

                    b.HasIndex("regionID");

                    b.ToTable("PROVINCEs");
                });

            modelBuilder.Entity("VietTravel.DBModels.REGION", b =>
                {
                    b.Property<short>("regionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("regionName");

                    b.HasKey("regionID");

                    b.ToTable("REGIONs");
                });

            modelBuilder.Entity("VietTravel.DBModels.SCHEDULE_TEMPLATE", b =>
                {
                    b.Property<short>("scheduleID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("expectedCharge");

                    b.Property<short?>("locationID");

                    b.Property<string>("scheduleDetail");

                    b.HasKey("scheduleID");

                    b.HasIndex("locationID");

                    b.ToTable("SCHEDULE_TEMPLATE");
                });

            modelBuilder.Entity("VietTravel.DBModels.TRANSPORTATION", b =>
                {
                    b.Property<short>("tranID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("detail");

                    b.Property<short?>("locationID");

                    b.Property<string>("tranName");

                    b.HasKey("tranID");

                    b.HasIndex("locationID");

                    b.ToTable("TRANSPORTATIONs");
                });

            modelBuilder.Entity("VietTravel.DBModels.USER", b =>
                {
                    b.Property<short>("userID")
                        .ValueGeneratedOnAdd();

                    b.Property<short?>("accountID");

                    b.Property<string>("email");

                    b.Property<string>("userName");

                    b.HasKey("userID");

                    b.HasIndex("accountID");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("VietTravel.DBModels.VIDEO", b =>
                {
                    b.Property<short>("videoID")
                        .ValueGeneratedOnAdd();

                    b.Property<short?>("locationID");

                    b.Property<string>("videoName");

                    b.Property<string>("videoSource");

                    b.HasKey("videoID");

                    b.HasIndex("locationID");

                    b.ToTable("VIDEOs");
                });

            modelBuilder.Entity("VietTravel.DBModels.APPRECIATION", b =>
                {
                    b.HasOne("VietTravel.DBModels.LOCATION", "LOCATION")
                        .WithMany("APPRECIATIONs")
                        .HasForeignKey("locationID");

                    b.HasOne("VietTravel.DBModels.USER", "USER")
                        .WithMany("APPRECIATIONs")
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("VietTravel.DBModels.ARTICLE", b =>
                {
                    b.HasOne("VietTravel.DBModels.LOCATION", "LOCATION")
                        .WithMany("ARTICLEs")
                        .HasForeignKey("locationID");
                });

            modelBuilder.Entity("VietTravel.DBModels.CITY", b =>
                {
                    b.HasOne("VietTravel.DBModels.PROVINCE", "PROVINCE")
                        .WithMany("CITies")
                        .HasForeignKey("provinceID");
                });

            modelBuilder.Entity("VietTravel.DBModels.IMAGE", b =>
                {
                    b.HasOne("VietTravel.DBModels.ARTICLE", "ARTICLE")
                        .WithMany("IMAGES")
                        .HasForeignKey("articleID");
                });

            modelBuilder.Entity("VietTravel.DBModels.LOCATION", b =>
                {
                    b.HasOne("VietTravel.DBModels.PROVINCE", "PROVINCE")
                        .WithMany("LOCATIONS")
                        .HasForeignKey("provinceID");

                    b.HasOne("VietTravel.DBModels.LOCATION_TYPE", "LOCATION_TYPE")
                        .WithMany("LOCATIONS")
                        .HasForeignKey("typeID");
                });

            modelBuilder.Entity("VietTravel.DBModels.LOCATION_TYPE", b =>
                {
                    b.HasOne("VietTravel.DBModels.ICON", "ICON")
                        .WithMany("LOCATION_TYPE")
                        .HasForeignKey("iconID");
                });

            modelBuilder.Entity("VietTravel.DBModels.PLAN_TRIP", b =>
                {
                    b.HasOne("VietTravel.DBModels.USER", "USER")
                        .WithMany("PLAN_TRIP")
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("VietTravel.DBModels.PROVINCE", b =>
                {
                    b.HasOne("VietTravel.DBModels.REGION", "REGION")
                        .WithMany("PROVINCEs")
                        .HasForeignKey("regionID");
                });

            modelBuilder.Entity("VietTravel.DBModels.SCHEDULE_TEMPLATE", b =>
                {
                    b.HasOne("VietTravel.DBModels.LOCATION", "LOCATION")
                        .WithMany("SCHEDULE_TEMPLATE")
                        .HasForeignKey("locationID");
                });

            modelBuilder.Entity("VietTravel.DBModels.TRANSPORTATION", b =>
                {
                    b.HasOne("VietTravel.DBModels.LOCATION", "LOCATION")
                        .WithMany("TRANSPORTATIONs")
                        .HasForeignKey("locationID");
                });

            modelBuilder.Entity("VietTravel.DBModels.USER", b =>
                {
                    b.HasOne("VietTravel.DBModels.ACCOUNT", "ACCOUNT")
                        .WithMany("USERS")
                        .HasForeignKey("accountID");
                });

            modelBuilder.Entity("VietTravel.DBModels.VIDEO", b =>
                {
                    b.HasOne("VietTravel.DBModels.LOCATION", "LOCATION")
                        .WithMany("VIDEOs")
                        .HasForeignKey("locationID");
                });
        }
    }
}
