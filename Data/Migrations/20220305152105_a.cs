using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    Cin = table.Column<string>(nullable: true),
                    fk_Filliale = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "RoleOfUser",
                columns: table => new
                {
                    roleofuserId = table.Column<Guid>(nullable: false),
                    Fk_User = table.Column<Guid>(nullable: false),
                    FK_Role = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOfUser", x => x.roleofuserId);
                    table.ForeignKey(
                        name: "FK_RoleOfUser_Roles_FK_Role",
                        column: x => x.FK_Role,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleOfUser_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleOfUser_FK_Role",
                table: "RoleOfUser",
                column: "FK_Role");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOfUser_Fk_User",
                table: "RoleOfUser",
                column: "Fk_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleOfUser");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
