using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Session4.Migrations
{
    public partial class NtoN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProffessorFaculties",
                columns: table => new
                {
                    ProffoserID = table.Column<Guid>(nullable: false),
                    FacultyID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProffessorFaculties", x => new { x.ProffoserID, x.FacultyID });
                    table.ForeignKey(
                        name: "FK_ProffessorFaculties_f_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "f",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProffessorFaculties_Proffosers_ProffoserID",
                        column: x => x.ProffoserID,
                        principalTable: "Proffosers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProffessorFaculties_FacultyID",
                table: "ProffessorFaculties",
                column: "FacultyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProffessorFaculties");
        }
    }
}
