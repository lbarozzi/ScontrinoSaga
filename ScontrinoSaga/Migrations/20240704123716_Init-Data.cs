using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScontrinoSaga.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceGrandTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ProductVat = table.Column<double>(type: "REAL", nullable: false),
                    IsAvaialable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "InvoicesRows",
                columns: table => new
                {
                    InvoiceRowID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentInvoiceInvoiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoicRowProductsProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceRowQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceRowPrice = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesRows", x => x.InvoiceRowID);
                    table.ForeignKey(
                        name: "FK_InvoicesRows_Invoice_ParentInvoiceInvoiceId",
                        column: x => x.ParentInvoiceInvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicesRows_Products_InvoicRowProductsProductID",
                        column: x => x.InvoicRowProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesRows_InvoicRowProductsProductID",
                table: "InvoicesRows",
                column: "InvoicRowProductsProductID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesRows_ParentInvoiceInvoiceId",
                table: "InvoicesRows",
                column: "ParentInvoiceInvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoicesRows");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
