using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CandidateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "CandidateName_FirstName",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateName_LastName",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateName_FirstName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CandidateName_LastName",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
