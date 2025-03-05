using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourManagerment.Migrations
{
    /// <inheritdoc />
    public partial class V5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourGuides_TourGuideID",
                table: "Tours");

            migrationBuilder.AlterColumn<int>(
                name: "TourGuideID",
                table: "Tours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_TourGuides_TourGuideID",
                table: "Tours",
                column: "TourGuideID",
                principalTable: "TourGuides",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourGuides_TourGuideID",
                table: "Tours");

            migrationBuilder.AlterColumn<int>(
                name: "TourGuideID",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_TourGuides_TourGuideID",
                table: "Tours",
                column: "TourGuideID",
                principalTable: "TourGuides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
