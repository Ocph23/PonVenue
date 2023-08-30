using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PonVenue.Migrations
{
    /// <inheritdoc />
    public partial class kotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KotaId",
                table: "DataVenue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DataVenue_KotaId",
                table: "DataVenue",
                column: "KotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataVenue_DataKota_KotaId",
                table: "DataVenue",
                column: "KotaId",
                principalTable: "DataKota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataVenue_DataKota_KotaId",
                table: "DataVenue");

            migrationBuilder.DropIndex(
                name: "IX_DataVenue_KotaId",
                table: "DataVenue");

            migrationBuilder.DropColumn(
                name: "KotaId",
                table: "DataVenue");
        }
    }
}
