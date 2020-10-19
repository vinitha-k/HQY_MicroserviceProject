using Microsoft.EntityFrameworkCore.Migrations;

namespace HQY_Microservice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "mark.wilson@xyz.com", "Mark", "Wilson", "916-346-7839" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, "ted.parker@xyz.com", "Ted", "Parker", "916-326-7839" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, "lynn.johnson@xyz.com", "Lynn", "Johnson", "516-896-3439" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
