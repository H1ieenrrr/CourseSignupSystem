using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseSignupSystem.Migrations
{
    public partial class allTable02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turnover",
                columns: table => new
                {
                    TurnoverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurnoverStudent = table.Column<int>(type: "int", nullable: false),
                    TurnoverStudentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TurnoverStudentClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TurnoverStudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TurnoverStudyDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TurnoverStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurnoverEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurnoverTuition = table.Column<double>(type: "float", nullable: false),
                    TurnoverTeacher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnover", x => x.TurnoverId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnover");
        }
    }
}
