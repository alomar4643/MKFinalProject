using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MortalKombatDB.Migrations
{
    /// <inheritdoc />
    public partial class Moves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Characters_CharacterId",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_CharacterId",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Moves");

            migrationBuilder.CreateTable(
                name: "CharacterMove",
                columns: table => new
                {
                    MovesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    charactersId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMove", x => new { x.MovesId, x.charactersId });
                    table.ForeignKey(
                        name: "FK_CharacterMove_Characters_charactersId",
                        column: x => x.charactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMove_Moves_MovesId",
                        column: x => x.MovesId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMove_charactersId",
                table: "CharacterMove",
                column: "charactersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMove");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "Moves",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moves_CharacterId",
                table: "Moves",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Characters_CharacterId",
                table: "Moves",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
