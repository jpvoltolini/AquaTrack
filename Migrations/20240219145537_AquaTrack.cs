using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AquaTrack.Migrations
{
    /// <inheritdoc />
    public partial class AquaTrack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leituras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Apartamento = table.Column<int>(type: "integer", nullable: false),
                    Bloco = table.Column<string>(type: "text", nullable: false),
                    LeituraAnterior = table.Column<int>(type: "integer", nullable: false),
                    LeituraAtual = table.Column<int>(type: "integer", nullable: false),
                    Consumo = table.Column<int>(type: "integer", nullable: false),
                    DataLeitura = table.Column<DateTime>(type: "data", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leituras", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leituras");
        }
    }
}
