using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScontrinoSaga.Migrations
{
    /// <inheritdoc />
    public partial class Producttypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesRows_Products_InvoicRowProductsProductID",
                table: "InvoicesRows");

            migrationBuilder.RenameColumn(
                name: "InvoicRowProductsProductID",
                table: "InvoicesRows",
                newName: "InvoiceRowProductProductID");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesRows_InvoicRowProductsProductID",
                table: "InvoicesRows",
                newName: "IX_InvoicesRows_InvoiceRowProductProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesRows_Products_InvoiceRowProductProductID",
                table: "InvoicesRows",
                column: "InvoiceRowProductProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesRows_Products_InvoiceRowProductProductID",
                table: "InvoicesRows");

            migrationBuilder.RenameColumn(
                name: "InvoiceRowProductProductID",
                table: "InvoicesRows",
                newName: "InvoicRowProductsProductID");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesRows_InvoiceRowProductProductID",
                table: "InvoicesRows",
                newName: "IX_InvoicesRows_InvoicRowProductsProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesRows_Products_InvoicRowProductsProductID",
                table: "InvoicesRows",
                column: "InvoicRowProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
