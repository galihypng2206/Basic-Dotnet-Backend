using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeretaApiBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keretas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaKereta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kelas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapasitas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keretas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tikets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jadwal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StasiunAsal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StasiunTujuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KeretaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tikets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tikets_Keretas_KeretaId",
                        column: x => x.KeretaId,
                        principalTable: "Keretas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tikets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tikets_KeretaId",
                table: "Tikets",
                column: "KeretaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tikets_UserId",
                table: "Tikets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tikets");

            migrationBuilder.DropTable(
                name: "Keretas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
