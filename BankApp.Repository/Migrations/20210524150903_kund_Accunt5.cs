using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Repository.Migrations
{
    public partial class kund_Accunt5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
