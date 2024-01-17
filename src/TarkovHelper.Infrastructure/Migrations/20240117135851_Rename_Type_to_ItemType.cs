using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarkovHelper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Type_to_ItemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Items",
                newName: "ItemType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemType",
                table: "Items",
                newName: "Type");
        }
    }
}
