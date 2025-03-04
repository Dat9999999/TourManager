using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourManagerment.Migrations
{
    /// <inheritdoc />
    public partial class V10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourGuides_TourGuideID",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "TourGuideID",
                table: "Tours",
                newName: "TourGuideId");

            migrationBuilder.RenameIndex(
                name: "IX_Tours_TourGuideID",
                table: "Tours",
                newName: "IX_Tours_TourGuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_TourGuides_TourGuideId",
                table: "Tours",
                column: "TourGuideId",
                principalTable: "TourGuides",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourGuides_TourGuideId",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "TourGuideId",
                table: "Tours",
                newName: "TourGuideID");

            migrationBuilder.RenameIndex(
                name: "IX_Tours_TourGuideId",
                table: "Tours",
                newName: "IX_Tours_TourGuideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_TourGuides_TourGuideID",
                table: "Tours",
                column: "TourGuideID",
                principalTable: "TourGuides",
                principalColumn: "Id");
        }
    }
}
