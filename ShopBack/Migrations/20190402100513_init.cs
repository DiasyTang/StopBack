using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBack.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    MenuUrl = table.Column<string>(nullable: false),
                    MenuAlias = table.Column<string>(nullable: false),
                    MenuIcon = table.Column<string>(nullable: true),
                    ParentMenuCode = table.Column<string>(type: "nvarchar(6)", nullable: true),
                    ParentMenuName = table.Column<string>(nullable: true),
                    Level = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Sort = table.Column<long>(nullable: false),
                    MenuStatus = table.Column<int>(nullable: false),
                    IsDefaultRouter = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuCode);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    RoleName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RoleStatus = table.Column<int>(nullable: false),
                    IsSuperAdminstrator = table.Column<bool>(nullable: false),
                    IsBuiltin = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleCode);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    MenuCode = table.Column<string>(nullable: true),
                    PermissionName = table.Column<string>(nullable: true),
                    ActionCode = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PermissionStatus = table.Column<int>(nullable: false),
                    PermissionType = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionCode);
                    table.ForeignKey(
                        name: "FK_Permission_Menu_MenuCode",
                        column: x => x.MenuCode,
                        principalTable: "Menu",
                        principalColumn: "MenuCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    LoginName = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    UserStatus = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsLogined = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true),
                    RoleCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserCode);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "Role",
                        principalColumn: "RoleCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionMapping",
                columns: table => new
                {
                    PermissionCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionMapping", x => new { x.PermissionCode, x.RoleCode });
                    table.ForeignKey(
                        name: "FK_RolePermissionMapping_Permission_PermissionCode",
                        column: x => x.PermissionCode,
                        principalTable: "Permission",
                        principalColumn: "PermissionCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissionMapping_Role_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "Role",
                        principalColumn: "RoleCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuCode",
                table: "Menu",
                column: "MenuCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_MenuCode",
                table: "Permission",
                column: "MenuCode");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionCode",
                table: "Permission",
                column: "PermissionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleCode",
                table: "Role",
                column: "RoleCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionMapping_RoleCode",
                table: "RolePermissionMapping",
                column: "RoleCode");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleCode",
                table: "User",
                column: "RoleCode");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserCode",
                table: "User",
                column: "UserCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissionMapping");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
