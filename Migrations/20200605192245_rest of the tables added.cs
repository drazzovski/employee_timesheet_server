using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTimesheet.Migrations
{
    public partial class restofthetablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipZadatka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipZadatka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zadaci",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    TipId = table.Column<int>(nullable: false),
                    Aktivan = table.Column<bool>(nullable: false),
                    KreiranOd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadaci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zadaci_AspNetUsers_KreiranOd",
                        column: x => x.KreiranOd,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zadaci_TipZadatka_TipId",
                        column: x => x.TipId,
                        principalTable: "TipZadatka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RadniSati",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ZadatakId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UtrosenoVrijeme = table.Column<long>(nullable: false),
                    DatumUnosa = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniSati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadniSati_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RadniSati_Zadaci_ZadatakId",
                        column: x => x.ZadatakId,
                        principalTable: "Zadaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6CAC3ED9-597A-4319-87E4-1AB92823B152",
                column: "ConcurrencyStamp",
                value: "551838dc-233a-4e0a-9533-d715bbfb6ffd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711E84F4-9AA5-42E0-8118-B25F4F6C2B12",
                column: "ConcurrencyStamp",
                value: "2b8904cd-1f36-44b9-8171-b7bc157e2e84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E91AA16-4C34-44DD-B9E3-27A7918E401E",
                column: "ConcurrencyStamp",
                value: "46d4f028-79e0-4648-bf1f-93a5bdd0a3c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E357EEF-3591-4F7E-8CF1-120DA7016486",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3231586c-3db4-401b-a6d5-564925e75c41", "AQAAAAEAACcQAAAAEADs1rK11sEghvwkhisSUuR9+y6NYFAMNZeLOdrYWaUmhaUVB4NCM7Cog6seb2mLaw==", "07633F8D-D645-4495-B51C-2AD424E66390" });

            migrationBuilder.InsertData(
                table: "TipZadatka",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Projekat" },
                    { 2, "Aktivnost" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RadniSati_UserId",
                table: "RadniSati",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniSati_ZadatakId",
                table: "RadniSati",
                column: "ZadatakId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_KreiranOd",
                table: "Zadaci",
                column: "KreiranOd");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_TipId",
                table: "Zadaci",
                column: "TipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RadniSati");

            migrationBuilder.DropTable(
                name: "Zadaci");

            migrationBuilder.DropTable(
                name: "TipZadatka");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6CAC3ED9-597A-4319-87E4-1AB92823B152",
                column: "ConcurrencyStamp",
                value: "8b427496-9428-4313-8cf7-c449295cc06f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711E84F4-9AA5-42E0-8118-B25F4F6C2B12",
                column: "ConcurrencyStamp",
                value: "29536c21-f87e-40f4-aadc-50e9a4d843eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E91AA16-4C34-44DD-B9E3-27A7918E401E",
                column: "ConcurrencyStamp",
                value: "fa845be9-00ae-461e-9c46-52edb8b49fc5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E357EEF-3591-4F7E-8CF1-120DA7016486",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0689a116-a1f5-4e30-ac4b-2eee51cc087d", "AQAAAAEAACcQAAAAEA3oLpY/H9N0/Au+ebmLVO8dys88HlwbokkxwOP2+zLeWwv5NP4eaYVly26c0W5ppg==", "40C19088-2A96-4D48-A2DC-C94C7C3CB13A" });
        }
    }
}
