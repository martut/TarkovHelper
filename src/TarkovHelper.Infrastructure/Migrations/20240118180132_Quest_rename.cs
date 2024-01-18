using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarkovHelper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Quest_rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Quests",
                newName: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Quests",
                newName: "IsCompleted");
        }
    }
}
