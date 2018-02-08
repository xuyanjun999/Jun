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
                name: "SGEAP_Org_Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    CnName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CompType = table.Column<int>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    ContactTelephone = table.Column<string>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    CreateStaffName = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    Des = table.Column<string>(nullable: true),
                    EnName = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Homepage = table.Column<string>(nullable: true),
                    LogoPath = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Tax = table.Column<string>(nullable: true),
                    UpdateOn = table.Column<DateTime>(nullable: false),
                    UpdateStaffName = table.Column<string>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGEAP_Org_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SGEAP_Sys_Menu",
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
                    ParentId = table.Column<int>(nullable: true),
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
                    table.PrimaryKey("PK_SGEAP_Sys_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SGEAP_Sys_Menu_SGEAP_Sys_Menu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SGEAP_Sys_Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SGEAP_Sys_Menu_ParentId",
                table: "SGEAP_Sys_Menu",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SGEAP_Org_Company");

            migrationBuilder.DropTable(
                name: "SGEAP_Sys_Menu");
        }
    }
}
