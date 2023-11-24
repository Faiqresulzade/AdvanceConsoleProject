using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updateallmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "Pharamcies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pharamcies_EmployeId",
                table: "Pharamcies",
                column: "EmployeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharamcies_Employes_EmployeId",
                table: "Pharamcies",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharamcies_Employes_EmployeId",
                table: "Pharamcies");

            migrationBuilder.DropIndex(
                name: "IX_Pharamcies_EmployeId",
                table: "Pharamcies");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Pharamcies");
        }
    }
}
