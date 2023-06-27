using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RamenKing.Migrations
{
    /// <inheritdoc />
    public partial class ramenDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Ramen",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Ramen",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Ramen");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Ramen",
                newName: "Description");
        }
    }
}
