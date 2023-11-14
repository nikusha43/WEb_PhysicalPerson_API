using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEb_PhysicalPerson_API.Migrations
{
    /// <inheritdoc />
    public partial class ConnPersonChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelatedPersonId",
                table: "ConnectedPersons",
                newName: "connectionPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "connectionPersonId",
                table: "ConnectedPersons",
                newName: "RelatedPersonId");
        }
    }
}
