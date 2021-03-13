using Microsoft.EntityFrameworkCore.Migrations;

namespace DottyLogs.Server.Sqlite.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Spans_DottySpanId",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "ParentSpanIdentifier",
                table: "Spans",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DottySpanId",
                table: "Logs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Spans_DottySpanId",
                table: "Logs",
                column: "DottySpanId",
                principalTable: "Spans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Spans_DottySpanId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ParentSpanIdentifier",
                table: "Spans");

            migrationBuilder.AlterColumn<long>(
                name: "DottySpanId",
                table: "Logs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Spans_DottySpanId",
                table: "Logs",
                column: "DottySpanId",
                principalTable: "Spans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
