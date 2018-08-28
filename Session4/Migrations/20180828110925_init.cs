using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_f", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Secconds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secconds", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Thirds",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thirds", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proffosers",
                columns: table => new
                {
                    FacultyID = table.Column<Guid>(nullable: false),
                    ID = table.Column<Guid>(nullable: false),
                    PersonalID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 40, nullable: true),
                    Phone = table.Column<string>(maxLength: 13, nullable: true),
                    Mobile = table.Column<string>(maxLength: 13, nullable: true),
                    ShomarePersoneli = table.Column<int>(nullable: false),
                    SaleVorudBeDaneshgah = table.Column<DateTime>(nullable: false),
                    MratabelEmli = table.Column<int>(nullable: false)
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
                    FacultyID = table.Column<Guid>(nullable: false),
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
                    Type = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Firsts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyProperty = table.Column<double>(nullable: false),
                    SeccondID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firsts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Firsts_Secconds_SeccondID",
                        column: x => x.SeccondID,
                        principalTable: "Secconds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fourths",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyProperty = table.Column<DateTime>(nullable: false),
                    ThirdID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fourths", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fourths_Thirds_ThirdID",
                        column: x => x.ThirdID,
                        principalTable: "Thirds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Fifths",
                columns: table => new
                {
                    FirstID = table.Column<int>(nullable: false),
                    FourthID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fifths", x => new { x.FirstID, x.FourthID });
                    table.ForeignKey(
                        name: "FK_Fifths_Firsts_FirstID",
                        column: x => x.FirstID,
                        principalTable: "Firsts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fifths_Fourths_FourthID",
                        column: x => x.FourthID,
                        principalTable: "Fourths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fifths_FourthID",
                table: "Fifths",
                column: "FourthID");

            migrationBuilder.CreateIndex(
                name: "IX_Firsts_SeccondID",
                table: "Firsts",
                column: "SeccondID");

            migrationBuilder.CreateIndex(
                name: "IX_Fourths_ThirdID",
                table: "Fourths",
                column: "ThirdID");

            migrationBuilder.CreateIndex(
                name: "IX_ProffessorFaculties_FacultyID",
                table: "ProffessorFaculties",
                column: "FacultyID");

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
                name: "Fifths");

            migrationBuilder.DropTable(
                name: "ProffessorFaculties");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Firsts");

            migrationBuilder.DropTable(
                name: "Fourths");

            migrationBuilder.DropTable(
                name: "Proffosers");

            migrationBuilder.DropTable(
                name: "Secconds");

            migrationBuilder.DropTable(
                name: "Thirds");

            migrationBuilder.DropTable(
                name: "f");
        }
    }
}
