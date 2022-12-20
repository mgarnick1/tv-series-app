using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tv_series_app.Migrations
{
    public partial class NetworkLogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NetworkLogoId",
                table: "TVSeries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NetworkLogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkLogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkLogos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVSeries_NetworkLogoId",
                table: "TVSeries",
                column: "NetworkLogoId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkLogos_UserId",
                table: "NetworkLogos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TVSeries_NetworkLogos_NetworkLogoId",
                table: "TVSeries",
                column: "NetworkLogoId",
                principalTable: "NetworkLogos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVSeries_NetworkLogos_NetworkLogoId",
                table: "TVSeries");

            migrationBuilder.DropTable(
                name: "NetworkLogos");

            migrationBuilder.DropIndex(
                name: "IX_TVSeries_NetworkLogoId",
                table: "TVSeries");

            migrationBuilder.DropColumn(
                name: "NetworkLogoId",
                table: "TVSeries");
        }
    }
}
