using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Jun.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    CreateStaffName = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    IconResource = table.Column<string>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    SequenceIndex = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false),
                    UpdateStaffName = table.Column<string>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbSet_dbSet_ParentID",
                        column: x => x.ParentID,
                        principalTable: "dbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbSet_ParentID",
                table: "dbSet",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbSet");
        }
    }
}
