using Microsoft.EntityFrameworkCore.Migrations;

namespace DottyLogs.Server.Sqlite.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpanIdentifier",
                table: "Logs",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpanIdentifier",
                table: "Logs");
        }
    }
}
