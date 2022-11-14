using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubtitlesManagementSystem.Data.Migrations
{
    public partial class AddedCountryAndFilmProductionActorEntityTypeConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmProductions_Countries_CountryId",
                table: "FilmProductions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmProductionActors",
                table: "FilmProductionActors");

            migrationBuilder.DropIndex(
                name: "IX_FilmProductionActors_FilmProductionId",
                table: "FilmProductionActors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FilmProductionActors");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FilmProductionActors");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FilmProductionActors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmProductionActors",
                table: "FilmProductionActors",
                columns: new[] { "FilmProductionId", "ActorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FilmProductions_Countries_CountryId",
                table: "FilmProductions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmProductions_Countries_CountryId",
                table: "FilmProductions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmProductionActors",
                table: "FilmProductionActors");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "FilmProductionActors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FilmProductionActors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FilmProductionActors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmProductionActors",
                table: "FilmProductionActors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FilmProductionActors_FilmProductionId",
                table: "FilmProductionActors",
                column: "FilmProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmProductions_Countries_CountryId",
                table: "FilmProductions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
