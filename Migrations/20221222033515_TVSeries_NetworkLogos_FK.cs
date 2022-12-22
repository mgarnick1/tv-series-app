using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tv_series_app.Migrations
{
    public partial class TVSeries_NetworkLogos_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVSeries_NetworkLogos_NetworkLogoId",
                table: "TVSeries");

            migrationBuilder.DropIndex(
                name: "IX_TVSeries_NetworkLogoId",
                table: "TVSeries");

            migrationBuilder.DropColumn(
                name: "Network",
                table: "TVSeries");

            migrationBuilder.DropColumn(
                name: "NetworkLogoId",
                table: "TVSeries");

            migrationBuilder.AddColumn<int>(
                name: "NetworkId",
                table: "TVSeries",
                type: "int",
                maxLength: 32,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TVSeries_NetworkId",
                table: "TVSeries",
                column: "NetworkId",
                unique: true,
                filter: "[NetworkId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TVSeries_NetworkLogos_NetworkId",
                table: "TVSeries",
                column: "NetworkId",
                principalTable: "NetworkLogos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVSeries_NetworkLogos_NetworkId",
                table: "TVSeries");

            migrationBuilder.DropIndex(
                name: "IX_TVSeries_NetworkId",
                table: "TVSeries");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "TVSeries");

            migrationBuilder.AddColumn<string>(
                name: "Network",
                table: "TVSeries",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NetworkLogoId",
                table: "TVSeries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TVSeries_NetworkLogoId",
                table: "TVSeries",
                column: "NetworkLogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TVSeries_NetworkLogos_NetworkLogoId",
                table: "TVSeries",
                column: "NetworkLogoId",
                principalTable: "NetworkLogos",
                principalColumn: "Id");
        }
    }
}
