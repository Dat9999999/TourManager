using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourManagerment.Migrations
{
    /// <inheritdoc />
    public partial class V11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_TourOrders_TourOrderID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TourOrders_Customers_CustomerID",
                table: "TourOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TourOrders_Tours_TourID",
                table: "TourOrders");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_TourOrderID",
                table: "Invoices");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TourID",
                table: "TourOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "TourOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TourOrderID",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TourOrderID",
                table: "Invoices",
                column: "TourOrderID",
                unique: true,
                filter: "[TourOrderID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_TourOrders_TourOrderID",
                table: "Invoices",
                column: "TourOrderID",
                principalTable: "TourOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourOrders_Customers_CustomerID",
                table: "TourOrders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourOrders_Tours_TourID",
                table: "TourOrders",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_TourOrders_TourOrderID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TourOrders_Customers_CustomerID",
                table: "TourOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TourOrders_Tours_TourID",
                table: "TourOrders");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_TourOrderID",
                table: "Invoices");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TourID",
                table: "TourOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "TourOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TourOrderID",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TourOrderID",
                table: "Invoices",
                column: "TourOrderID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_TourOrders_TourOrderID",
                table: "Invoices",
                column: "TourOrderID",
                principalTable: "TourOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourOrders_Customers_CustomerID",
                table: "TourOrders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourOrders_Tours_TourID",
                table: "TourOrders",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
