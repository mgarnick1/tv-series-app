using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tv_series_app.Migrations
{
    public partial class TVSeries_Network : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Network",
                table: "TVSeries",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Network",
                table: "TVSeries");
        }
    }
}
