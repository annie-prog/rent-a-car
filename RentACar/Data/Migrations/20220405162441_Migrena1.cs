using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Migrena1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "43cf6ddd-13bc-4680-9e88-21d5bb059012", "5ff048ba-cb37-4966-a7dd-f7b0aa96d730" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58aee2c2-eab0-4448-afde-440707d99128", "5ff048ba-cb37-4966-a7dd-f7b0aa96d730" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43cf6ddd-13bc-4680-9e88-21d5bb059012");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58aee2c2-eab0-4448-afde-440707d99128");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ff048ba-cb37-4966-a7dd-f7b0aa96d730");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0387a4dd-4a2a-4119-b7c9-5d5e7c16b0ed", "cb148526-d897-4dfa-966f-b67b73e16be5", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0aacbe6-4603-4b03-b4e7-b521491bef85", "ef05edac-cedf-488c-9e99-569b0d434c10", "Employee", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalNumber", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b482663b-78bc-4b6a-81a6-75d52d87bbb1", 0, "87ad6f7e-0c13-418e-85bd-de8f713571df", "admin@admin.admin", false, null, null, false, null, null, null, "AQAAAAEAACcQAAAAEDziS8oqC1HTCljBTahrcu4r2yG6Jx9UQwSqWbxyBm2tmq5aKXSnajXslwuEc2AF4Q==", null, null, false, "4323b9d9-b92f-4ef3-94b1-77050d61341a", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0387a4dd-4a2a-4119-b7c9-5d5e7c16b0ed", "b482663b-78bc-4b6a-81a6-75d52d87bbb1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b0aacbe6-4603-4b03-b4e7-b521491bef85", "b482663b-78bc-4b6a-81a6-75d52d87bbb1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0387a4dd-4a2a-4119-b7c9-5d5e7c16b0ed", "b482663b-78bc-4b6a-81a6-75d52d87bbb1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b0aacbe6-4603-4b03-b4e7-b521491bef85", "b482663b-78bc-4b6a-81a6-75d52d87bbb1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0387a4dd-4a2a-4119-b7c9-5d5e7c16b0ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0aacbe6-4603-4b03-b4e7-b521491bef85");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b482663b-78bc-4b6a-81a6-75d52d87bbb1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43cf6ddd-13bc-4680-9e88-21d5bb059012", "4add9b33-0dd3-4301-a5bf-c22d1f6be04d", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58aee2c2-eab0-4448-afde-440707d99128", "091ef9fa-ecf1-4195-b3a3-9d1989cdbc50", "Employee", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalNumber", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5ff048ba-cb37-4966-a7dd-f7b0aa96d730", 0, "bd3f3137-a505-4c21-9392-8cc07b1eac1e", "admin@admin.admin", false, null, null, false, null, null, null, "AQAAAAEAACcQAAAAEPi0dTNwbpnqCBmfVPUqx8rvTNgAcDNC+66x774qyxx0uJUru0hXcxozgjaFx/7MRw==", null, null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "43cf6ddd-13bc-4680-9e88-21d5bb059012", "5ff048ba-cb37-4966-a7dd-f7b0aa96d730" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "58aee2c2-eab0-4448-afde-440707d99128", "5ff048ba-cb37-4966-a7dd-f7b0aa96d730" });
        }
    }
}
