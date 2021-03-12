using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DottyLogs.Server.Sqlite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SpanIdentifier = table.Column<string>(type: "TEXT", nullable: true),
                    TraceIdentifier = table.Column<string>(type: "TEXT", nullable: true),
                    HostName = table.Column<string>(type: "TEXT", nullable: true),
                    ApplicationName = table.Column<string>(type: "TEXT", nullable: true),
                    StartedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StoppedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DottySpanId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spans_Spans_DottySpanId",
                        column: x => x.DottySpanId,
                        principalTable: "Spans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DottyLogLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    DateTimeUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DottySpanId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DottyLogLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DottyLogLine_Spans_DottySpanId",
                        column: x => x.DottySpanId,
                        principalTable: "Spans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Traces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraceIdentifier = table.Column<string>(type: "TEXT", nullable: true),
                    StartedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StoppedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RequestUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SpanDataId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traces_Spans_SpanDataId",
                        column: x => x.SpanDataId,
                        principalTable: "Spans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DottyLogLine_DottySpanId",
                table: "DottyLogLine",
                column: "DottySpanId");

            migrationBuilder.CreateIndex(
                name: "IX_Spans_DottySpanId",
                table: "Spans",
                column: "DottySpanId");

            migrationBuilder.CreateIndex(
                name: "IX_Spans_SpanIdentifier",
                table: "Spans",
                column: "SpanIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Spans_TraceIdentifier",
                table: "Spans",
                column: "TraceIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Traces_SpanDataId",
                table: "Traces",
                column: "SpanDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Traces_TraceIdentifier",
                table: "Traces",
                column: "TraceIdentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DottyLogLine");

            migrationBuilder.DropTable(
                name: "Traces");

            migrationBuilder.DropTable(
                name: "Spans");
        }
    }
}
