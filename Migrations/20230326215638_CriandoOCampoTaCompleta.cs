using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace escoladotnet.Migrations
{
    /// <inheritdoc />
    public partial class CriandoOCampoTaCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TaCompleta",
                table: "Curso",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaCompleta",
                table: "Curso");
        }
    }
}
