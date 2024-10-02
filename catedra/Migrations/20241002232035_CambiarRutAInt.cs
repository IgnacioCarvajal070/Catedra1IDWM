using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace catedra.Migrations
{
    /// <inheritdoc />
    public partial class CambiarRutAInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rut",
                table: "Users",
                newName: "Rut");

            migrationBuilder.AlterColumn<int>(
                name: "Rut",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "Users",
                newName: "rut");

            migrationBuilder.AlterColumn<string>(
                name: "rut",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
