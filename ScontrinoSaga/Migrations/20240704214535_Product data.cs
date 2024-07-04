using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScontrinoSaga.Migrations
{
    /// <inheritdoc />
    public partial class Productdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InvoiceRowPrice",
                table: "InvoicesRows",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InvoiceRowPrice",
                table: "InvoicesRows",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
