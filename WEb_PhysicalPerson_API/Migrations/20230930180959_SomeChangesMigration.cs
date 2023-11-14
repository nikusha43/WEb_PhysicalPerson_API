using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEb_PhysicalPerson_API.Migrations
{
    /// <inheritdoc />
    public partial class SomeChangesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedPersonId",
                table: "ConnectedPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedPersonId",
                table: "ConnectedPersons");
        }
    }
}
