using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTimesheet.Migrations
{
    public partial class NadredjeniFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "AspNetUsers",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserID",
                table: "AspNetUsers",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserID",
                table: "AspNetUsers",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApplicationUserID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6CAC3ED9-597A-4319-87E4-1AB92823B152",
                column: "ConcurrencyStamp",
                value: "bb2ea291-0c92-4d10-ab5f-5b8d66f67c1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711E84F4-9AA5-42E0-8118-B25F4F6C2B12",
                column: "ConcurrencyStamp",
                value: "d3f6ebcc-6077-4ea9-92d3-dabd0cb6314e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E91AA16-4C34-44DD-B9E3-27A7918E401E",
                column: "ConcurrencyStamp",
                value: "4a465038-972e-47a3-8e5c-8f05f19afd22");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E357EEF-3591-4F7E-8CF1-120DA7016486",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27f2d18d-e620-437e-8d2d-6973ac12e53b", "AQAAAAEAACcQAAAAENo7aR1lmI5PAwx9wHWXD1JsJLZfjgyF+bOH934hQmi2q2QRTImvquegF1hCYTQ+Qg==", "B179D61B-AB73-4D72-9198-5D329A102FD7" });
        }
    }
}
