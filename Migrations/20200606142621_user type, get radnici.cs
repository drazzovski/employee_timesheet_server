using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTimesheet.Migrations
{
    public partial class usertypegetradnici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6CAC3ED9-597A-4319-87E4-1AB92823B152",
                column: "ConcurrencyStamp",
                value: "8fe63bd2-fa9c-4799-8852-5bcebbe6d14b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711E84F4-9AA5-42E0-8118-B25F4F6C2B12",
                column: "ConcurrencyStamp",
                value: "be955491-a976-46ef-8640-6bbba3e5829e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E91AA16-4C34-44DD-B9E3-27A7918E401E",
                column: "ConcurrencyStamp",
                value: "d3818fb5-7851-46b6-8f1b-0a355aec7e7d");

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Nadredjeni" },
                    { 3, "Radnik" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E357EEF-3591-4F7E-8CF1-120DA7016486",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserTypeID" },
                values: new object[] { "13f172c6-4478-4182-ae90-a8dd066a461e", "AQAAAAEAACcQAAAAEHGevllQ12gm8DtFfS5QdDuo1ePoApBSIsQLlgOXaCNfABx54NgYtUMiohKg9/1vMQ==", "25969C4E-584A-4AE7-BD4B-478D38AEEAF0", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeID",
                table: "AspNetUsers",
                column: "UserTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserType_UserTypeID",
                table: "AspNetUsers",
                column: "UserTypeID",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserType_UserTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserTypeID",
                table: "AspNetUsers");

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
        }
    }
}
