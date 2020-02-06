using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tick_IT.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Issues_Number",
                startValue: 10001L);

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Issues_ID = table.Column<Guid>(nullable: false),
                    Issues_UserID = table.Column<Guid>(nullable: false),
                    Issues_Createdby = table.Column<string>(nullable: true),
                    Issues_Number = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR Issues_Number"),
                    Issues_DateTime = table.Column<DateTime>(nullable: false),
                    Issues_Subject = table.Column<string>(nullable: true),
                    Issues_Description = table.Column<string>(nullable: true),
                    Issues_Status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Issues_ID);
                });

            migrationBuilder.CreateTable(
                name: "Response",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropSequence(
                name: "Issues_Number");
        }
    }
}
