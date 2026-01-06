using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeretaApiBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddNomorKereta_Kereta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomorKereta",
                table: "Keretas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomorKereta",
                table: "Keretas");
        }
    }
}
