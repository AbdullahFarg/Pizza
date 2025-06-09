using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddPizzaSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "size",
                table: "Pizzas");
        }
    }
}
