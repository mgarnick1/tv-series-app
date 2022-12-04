using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tv_series_app.Migrations
{
    public partial class TVSeries_UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVSeries_AspNetUsers_UserKeyId",
                table: "TVSeries");

            migrationBuilder.RenameColumn(
                name: "UserKeyId",
                table: "TVSeries",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TVSeries_UserKeyId",
                table: "TVSeries",
                newName: "IX_TVSeries_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TVSeries_AspNetUsers_UserId",
                table: "TVSeries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVSeries_AspNetUsers_UserId",
                table: "TVSeries");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TVSeries",
                newName: "UserKeyId");

            migrationBuilder.RenameIndex(
                name: "IX_TVSeries_UserId",
                table: "TVSeries",
                newName: "IX_TVSeries_UserKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TVSeries_AspNetUsers_UserKeyId",
                table: "TVSeries",
                column: "UserKeyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
