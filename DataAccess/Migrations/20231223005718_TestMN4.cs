using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestMN4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialInteraction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialInteraction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialInteractionMapPets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PetId = table.Column<int>(type: "integer", nullable: false),
                    DestinationPetId = table.Column<int>(type: "integer", nullable: false),
                    SocialInteractionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialInteractionMapPets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialInteractionMapPets_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialInteractionMapPets_SocialInteraction_SocialInteractio~",
                        column: x => x.SocialInteractionId,
                        principalTable: "SocialInteraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialInteractionMapPets_PetId",
                table: "SocialInteractionMapPets",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialInteractionMapPets_SocialInteractionId",
                table: "SocialInteractionMapPets",
                column: "SocialInteractionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialInteractionMapPets");

            migrationBuilder.DropTable(
                name: "SocialInteraction");
        }
    }
}
