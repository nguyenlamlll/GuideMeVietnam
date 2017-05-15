using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.Migrations
{
    public partial class OhMyGhost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCOUNTs",
                columns: table => new
                {
                    accountID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pass = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTs", x => x.accountID);
                });

            migrationBuilder.CreateTable(
                name: "ICONs",
                columns: table => new
                {
                    iconID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    iconSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICONs", x => x.iconID);
                });

            migrationBuilder.CreateTable(
                name: "MAPs",
                columns: table => new
                {
                    mapID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    latitude = table.Column<decimal>(nullable: true),
                    longtitude = table.Column<decimal>(nullable: true),
                    mapName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPs", x => x.mapID);
                });

            migrationBuilder.CreateTable(
                name: "REGIONs",
                columns: table => new
                {
                    regionID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    regionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGIONs", x => x.regionID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    userID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    accountID = table.Column<short>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.userID);
                    table.ForeignKey(
                        name: "FK_USERS_ACCOUNTs_accountID",
                        column: x => x.accountID,
                        principalTable: "ACCOUNTs",
                        principalColumn: "accountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOCATION_TYPE",
                columns: table => new
                {
                    typeID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    iconID = table.Column<short>(nullable: true),
                    typeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCATION_TYPE", x => x.typeID);
                    table.ForeignKey(
                        name: "FK_LOCATION_TYPE_ICONs_iconID",
                        column: x => x.iconID,
                        principalTable: "ICONs",
                        principalColumn: "iconID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROVINCEs",
                columns: table => new
                {
                    provinceID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    imageSource = table.Column<string>(nullable: true),
                    intro = table.Column<string>(nullable: true),
                    latitude = table.Column<float>(nullable: true),
                    longtitude = table.Column<float>(nullable: true),
                    populationProvince = table.Column<float>(nullable: true),
                    provinceName = table.Column<string>(nullable: true),
                    regionID = table.Column<short>(nullable: true),
                    suggestSentence = table.Column<string>(nullable: true),
                    totalArea = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVINCEs", x => x.provinceID);
                    table.ForeignKey(
                        name: "FK_PROVINCEs_REGIONs_regionID",
                        column: x => x.regionID,
                        principalTable: "REGIONs",
                        principalColumn: "regionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PLAN_TRIP",
                columns: table => new
                {
                    planID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    detail = table.Column<string>(nullable: true),
                    planName = table.Column<string>(nullable: true),
                    userID = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN_TRIP", x => x.planID);
                    table.ForeignKey(
                        name: "FK_PLAN_TRIP_USERS_userID",
                        column: x => x.userID,
                        principalTable: "USERS",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CITies",
                columns: table => new
                {
                    cityID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cityName = table.Column<string>(nullable: true),
                    latitude = table.Column<float>(nullable: true),
                    longitude = table.Column<float>(nullable: true),
                    populationCity = table.Column<float>(nullable: true),
                    provinceID = table.Column<short>(nullable: true),
                    totalArea = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITies", x => x.cityID);
                    table.ForeignKey(
                        name: "FK_CITies_PROVINCEs_provinceID",
                        column: x => x.provinceID,
                        principalTable: "PROVINCEs",
                        principalColumn: "provinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOCATIONS",
                columns: table => new
                {
                    locationID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    latitude = table.Column<float>(nullable: true),
                    locationAddress = table.Column<string>(nullable: true),
                    locationName = table.Column<string>(nullable: true),
                    longitude = table.Column<float>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    priceMax = table.Column<decimal>(nullable: true),
                    priceMin = table.Column<decimal>(nullable: true),
                    provinceID = table.Column<short>(nullable: true),
                    typeID = table.Column<short>(nullable: true),
                    website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCATIONS", x => x.locationID);
                    table.ForeignKey(
                        name: "FK_LOCATIONS_PROVINCEs_provinceID",
                        column: x => x.provinceID,
                        principalTable: "PROVINCEs",
                        principalColumn: "provinceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOCATIONS_LOCATION_TYPE_typeID",
                        column: x => x.typeID,
                        principalTable: "LOCATION_TYPE",
                        principalColumn: "typeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APPRECIATIONs",
                columns: table => new
                {
                    appreciaID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    appreciaSubject = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    locationID = table.Column<short>(nullable: true),
                    numStar = table.Column<short>(nullable: true),
                    userID = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPRECIATIONs", x => x.appreciaID);
                    table.ForeignKey(
                        name: "FK_APPRECIATIONs_LOCATIONS_locationID",
                        column: x => x.locationID,
                        principalTable: "LOCATIONS",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APPRECIATIONs_USERS_userID",
                        column: x => x.userID,
                        principalTable: "USERS",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ARTICLEs",
                columns: table => new
                {
                    articleID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(nullable: true),
                    locationID = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLEs", x => x.articleID);
                    table.ForeignKey(
                        name: "FK_ARTICLEs_LOCATIONS_locationID",
                        column: x => x.locationID,
                        principalTable: "LOCATIONS",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHEDULE_TEMPLATE",
                columns: table => new
                {
                    scheduleID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    expectedCharge = table.Column<decimal>(nullable: true),
                    locationID = table.Column<short>(nullable: true),
                    scheduleDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHEDULE_TEMPLATE", x => x.scheduleID);
                    table.ForeignKey(
                        name: "FK_SCHEDULE_TEMPLATE_LOCATIONS_locationID",
                        column: x => x.locationID,
                        principalTable: "LOCATIONS",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRANSPORTATIONs",
                columns: table => new
                {
                    tranID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    detail = table.Column<string>(nullable: true),
                    locationID = table.Column<short>(nullable: true),
                    tranName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSPORTATIONs", x => x.tranID);
                    table.ForeignKey(
                        name: "FK_TRANSPORTATIONs_LOCATIONS_locationID",
                        column: x => x.locationID,
                        principalTable: "LOCATIONS",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VIDEOs",
                columns: table => new
                {
                    videoID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    locationID = table.Column<short>(nullable: true),
                    videoName = table.Column<string>(nullable: true),
                    videoSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIDEOs", x => x.videoID);
                    table.ForeignKey(
                        name: "FK_VIDEOs_LOCATIONS_locationID",
                        column: x => x.locationID,
                        principalTable: "LOCATIONS",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IMAGES",
                columns: table => new
                {
                    imageID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    articleID = table.Column<short>(nullable: true),
                    imageSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMAGES", x => x.imageID);
                    table.ForeignKey(
                        name: "FK_IMAGES_ARTICLEs_articleID",
                        column: x => x.articleID,
                        principalTable: "ARTICLEs",
                        principalColumn: "articleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPRECIATIONs_locationID",
                table: "APPRECIATIONs",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_APPRECIATIONs_userID",
                table: "APPRECIATIONs",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_ARTICLEs_locationID",
                table: "ARTICLEs",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_CITies_provinceID",
                table: "CITies",
                column: "provinceID");

            migrationBuilder.CreateIndex(
                name: "IX_IMAGES_articleID",
                table: "IMAGES",
                column: "articleID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATIONS_provinceID",
                table: "LOCATIONS",
                column: "provinceID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATIONS_typeID",
                table: "LOCATIONS",
                column: "typeID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATION_TYPE_iconID",
                table: "LOCATION_TYPE",
                column: "iconID");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_TRIP_userID",
                table: "PLAN_TRIP",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_PROVINCEs_regionID",
                table: "PROVINCEs",
                column: "regionID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULE_TEMPLATE_locationID",
                table: "SCHEDULE_TEMPLATE",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTATIONs_locationID",
                table: "TRANSPORTATIONs",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_accountID",
                table: "USERS",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_VIDEOs_locationID",
                table: "VIDEOs",
                column: "locationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPRECIATIONs");

            migrationBuilder.DropTable(
                name: "CITies");

            migrationBuilder.DropTable(
                name: "IMAGES");

            migrationBuilder.DropTable(
                name: "MAPs");

            migrationBuilder.DropTable(
                name: "PLAN_TRIP");

            migrationBuilder.DropTable(
                name: "SCHEDULE_TEMPLATE");

            migrationBuilder.DropTable(
                name: "TRANSPORTATIONs");

            migrationBuilder.DropTable(
                name: "VIDEOs");

            migrationBuilder.DropTable(
                name: "ARTICLEs");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "LOCATIONS");

            migrationBuilder.DropTable(
                name: "ACCOUNTs");

            migrationBuilder.DropTable(
                name: "PROVINCEs");

            migrationBuilder.DropTable(
                name: "LOCATION_TYPE");

            migrationBuilder.DropTable(
                name: "REGIONs");

            migrationBuilder.DropTable(
                name: "ICONs");
        }
    }
}
