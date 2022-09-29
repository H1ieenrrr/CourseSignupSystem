using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseSignupSystem.Migrations
{
    public partial class allTable03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TurnoverTotalTuition",
                table: "Turnover",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurnoverTotalTuition",
                table: "Turnover");
        }
    }
}
