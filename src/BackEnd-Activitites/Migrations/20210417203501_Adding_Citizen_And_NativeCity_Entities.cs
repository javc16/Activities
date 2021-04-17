using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndActivitites.Migrations
{
    public partial class Adding_Citizen_And_NativeCity_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NativeCity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NativeCity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citizen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdNAtiveCity = table.Column<int>(nullable: false),
                    NativeCityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citizen_NativeCity_NativeCityId",
                        column: x => x.NativeCityId,
                        principalTable: "NativeCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citizen_NativeCityId",
                table: "Citizen",
                column: "NativeCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citizen");

            migrationBuilder.DropTable(
                name: "NativeCity");
        }
    }
}
