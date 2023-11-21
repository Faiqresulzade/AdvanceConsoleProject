using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addedEmployes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employe_RoleTypes_RoleTypeID",
                table: "Employe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employe",
                table: "Employe");

            migrationBuilder.RenameTable(
                name: "Employe",
                newName: "Employes");

            migrationBuilder.RenameIndex(
                name: "IX_Employe_RoleTypeID",
                table: "Employes",
                newName: "IX_Employes_RoleTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employes",
                table: "Employes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employes_RoleTypes_RoleTypeID",
                table: "Employes",
                column: "RoleTypeID",
                principalTable: "RoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employes_RoleTypes_RoleTypeID",
                table: "Employes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employes",
                table: "Employes");

            migrationBuilder.RenameTable(
                name: "Employes",
                newName: "Employe");

            migrationBuilder.RenameIndex(
                name: "IX_Employes_RoleTypeID",
                table: "Employe",
                newName: "IX_Employe_RoleTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employe",
                table: "Employe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employe_RoleTypes_RoleTypeID",
                table: "Employe",
                column: "RoleTypeID",
                principalTable: "RoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
