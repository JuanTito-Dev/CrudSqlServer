using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class RegistroC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "edad",
                table: "Registros",
                newName: "Edad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Edad",
                table: "Registros",
                newName: "edad");
        }
    }
}
