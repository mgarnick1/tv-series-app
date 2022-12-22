using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tv_series_app.Migrations
{
    public partial class TVSeries_OneToMany_NetworkLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TVSeries_NetworkId",
                table: "TVSeries");

            migrationBuilder.CreateIndex(
                name: "IX_TVSeries_NetworkId",
                table: "TVSeries",
                column: "NetworkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TVSeries_NetworkId",
                table: "TVSeries");

            migrationBuilder.CreateIndex(
                name: "IX_TVSeries_NetworkId",
                table: "TVSeries",
                column: "NetworkId",
                unique: true,
                filter: "[NetworkId] IS NOT NULL");
        }
    }
}
