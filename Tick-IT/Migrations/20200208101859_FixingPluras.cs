using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tick_IT.Migrations
{
    public partial class FixingPluras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Issue",
                table: "Issue");

            migrationBuilder.RenameTable(
                name: "Issue",
                newName: "Issues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issues",
                table: "Issues",
                column: "Issues_ID");

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Responses_ID = table.Column<Guid>(nullable: false),
                    Responses_TicketID = table.Column<Guid>(nullable: false),
                    Responses_UserID = table.Column<Guid>(nullable: false),
                    Responses_DateTime = table.Column<DateTime>(nullable: false),
                    Responses_Message = table.Column<string>(nullable: true),
                    Responses_CreatedBy = table.Column<string>(nullable: true),
                    Issues_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Responses_ID);
                    table.ForeignKey(
                        name: "FK_Responses_Issues_Issues_ID",
                        column: x => x.Issues_ID,
                        principalTable: "Issues",
                        principalColumn: "Issues_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_Issues_ID",
                table: "Responses",
                column: "Issues_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Issues",
                table: "Issues");

            migrationBuilder.RenameTable(
                name: "Issues",
                newName: "Issue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issue",
                table: "Issue",
                column: "Issues_ID");

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Responses_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Issues_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Responses_CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responses_DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Responses_Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responses_TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Responses_UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Responses_ID);
                    table.ForeignKey(
                        name: "FK_Response_Issue_Issues_ID",
                        column: x => x.Issues_ID,
                        principalTable: "Issue",
                        principalColumn: "Issues_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Response_Issues_ID",
                table: "Response",
                column: "Issues_ID");
        }
    }
}
