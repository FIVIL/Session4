using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Session4.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "f",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_f", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proffosers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PersonalID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 40, nullable: true),
                    Phone = table.Column<string>(maxLength: 13, nullable: true),
                    Mobile = table.Column<string>(maxLength: 13, nullable: true),
                    ShomarePersoneli = table.Column<int>(nullable: false),
                    SaleVorudBeDaneshgah = table.Column<DateTime>(nullable: false),
                    MratabelEmli = table.Column<int>(nullable: false),
                    FacultyID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proffosers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proffosers_f_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "f",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PersonalID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 40, nullable: true),
                    Phone = table.Column<string>(maxLength: 13, nullable: true),
                    Mobile = table.Column<string>(maxLength: 13, nullable: true),
                    StudentNumber = table.Column<int>(nullable: false),
                    Avg = table.Column<double>(nullable: false),
                    Passed = table.Column<int>(nullable: false),
                    Enrolled = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FacultyID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_f_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "f",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proffosers_FacultyID",
                table: "Proffosers",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Proffosers_ShomarePersoneli",
                table: "Proffosers",
                column: "ShomarePersoneli",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyID",
                table: "Students",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNumber_PersonalID",
                table: "Students",
                columns: new[] { "StudentNumber", "PersonalID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proffosers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "f");
        }
    }
}
