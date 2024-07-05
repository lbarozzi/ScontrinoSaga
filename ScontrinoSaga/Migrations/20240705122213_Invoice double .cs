using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScontrinoSaga.Migrations
{
    /// <inheritdoc />
    public partial class Invoicedouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InvoiceGrandTotal",
                table: "Invoices",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "InvoiceGrandTotal",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
