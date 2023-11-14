using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEb_PhysicalPerson_API.Migrations
{
    /// <inheritdoc />
    public partial class ImStupid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Persons_PersonId",
                table: "Phones");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Phones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Persons_PersonId",
                table: "Phones",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Persons_PersonId",
                table: "Phones");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Persons_PersonId",
                table: "Phones",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
