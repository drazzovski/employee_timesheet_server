using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTimesheet.Migrations
{
    public partial class RolesAdminAndIdentityConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6CAC3ED9-597A-4319-87E4-1AB92823B152", "8ab1eb9f-1c5f-4fc3-948e-f02009d17e0c", "Administrator", "ADMINISTRATOR" },
                    { "9E91AA16-4C34-44DD-B9E3-27A7918E401E", "abd97102-636b-45c5-876a-a23659711a9a", "Nadredjeni", "NADREDJENI" },
                    { "711E84F4-9AA5-42E0-8118-B25F4F6C2B12", "ebe70d81-3f11-4773-a11a-80408458404b", "Radnik", "RADNIK" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2E357EEF-3591-4F7E-8CF1-120DA7016486", 0, "New Street 2", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MD", "f42c25bd-17c4-4b60-a68c-84d14ed1ef9a", "arandjic@gmail.com", true, "Master", "Admin", false, null, "ARANDJIC@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEEeHa6GFWd368jXzOnAyM4eSchrFCdw+SSoN8dHiIN7R1TE5MDO6jQFFC401HPywxw==", "0000", true, "D54642F3-C41E-4C75-8138-B8B4A23C46A0", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2E357EEF-3591-4F7E-8CF1-120DA7016486", "6CAC3ED9-597A-4319-87E4-1AB92823B152" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711E84F4-9AA5-42E0-8118-B25F4F6C2B12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E91AA16-4C34-44DD-B9E3-27A7918E401E");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2E357EEF-3591-4F7E-8CF1-120DA7016486", "6CAC3ED9-597A-4319-87E4-1AB92823B152" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6CAC3ED9-597A-4319-87E4-1AB92823B152");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E357EEF-3591-4F7E-8CF1-120DA7016486");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
