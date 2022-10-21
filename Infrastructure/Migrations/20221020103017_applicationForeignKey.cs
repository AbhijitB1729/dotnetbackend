using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class applicationForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationalDetails",
                columns: table => new
                {
                    EducationalDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfCompletion = table.Column<int>(type: "int", nullable: false),
                    ApplicantDetailApplicantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalDetails", x => x.EducationalDetailId);
                    table.ForeignKey(
                        name: "FK_EducationalDetails_ApplicantDetails_ApplicantDetailApplicantId",
                        column: x => x.ApplicantDetailApplicantId,
                        principalTable: "ApplicantDetails",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationalDetails_ApplicantDetailApplicantId",
                table: "EducationalDetails",
                column: "ApplicantDetailApplicantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationalDetails");
        }
    }
}
