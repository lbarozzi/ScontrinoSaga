using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScontrinoSaga.Migrations
{
    /// <inheritdoc />
    public partial class userAndIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductIcon",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIcon",
                table: "Products");
        }
    }
}
