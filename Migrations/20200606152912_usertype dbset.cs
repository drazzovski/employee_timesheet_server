using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTimesheet.Migrations
{
    public partial class usertypedbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserType_UserTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserType",
                table: "UserType");

            migrationBuilder.RenameTable(
                name: "UserType",
                newName: "UserTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6CAC3ED9-597A-4319-87E4-1AB92823B152",
                column: "ConcurrencyStamp",
                value: "7e0ce40a-9694-449b-ae60-9c423ddb3394");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711E84F4-9AA5-42E0-8118-B25F4F6C2B12",
                column: "ConcurrencyStamp",
                value: "a29fe9bc-729e-41ef-898a-bb6e4129283c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E91AA16-4C34-44DD-B9E3-27A7918E401E",
                column: "ConcurrencyStamp",
                value: "e1bbacc7-737a-48a1-88df-121f4dee11f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E357EEF-3591-4F7E-8CF1-120DA7016486",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02af0423-ff8a-4e47-9aed-6aedd6f35870", "AQAAAAEAACcQAAAAEM5UwrFyh9J5mq+OP3jXecpZD6Q9Uvg2rr1d9RgNo6FBf7faz6e45cfkyqw6sn+MXw==", "86BAA9B3-96C2-467B-8145-DB3196C54B9E" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserTypes_UserTypeID",
                table: "AspNetUsers",
                column: "UserTypeID",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserTypes_UserTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.RenameTable(
                name: "UserTypes",
                newName: "UserType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserType",
                table: "UserType",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E357EEF-3591-4F7E-8CF1-120DA7016486",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13f172c6-4478-4182-ae90-a8dd066a461e", "AQAAAAEAACcQAAAAEHGevllQ12gm8DtFfS5QdDuo1ePoApBSIsQLlgOXaCNfABx54NgYtUMiohKg9/1vMQ==", "25969C4E-584A-4AE7-BD4B-478D38AEEAF0" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserType_UserTypeID",
                table: "AspNetUsers",
                column: "UserTypeID",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
