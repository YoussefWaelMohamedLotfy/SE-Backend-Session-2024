using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSessionDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddAllSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkingDepartmentID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarLicenses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidityInMonths = table.Column<int>(type: "int", nullable: false),
                    OwningEmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarLicenses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarLicenses_Employees_OwningEmployeeID",
                        column: x => x.OwningEmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    WorkingEmployeesID = table.Column<int>(type: "int", nullable: false),
                    WorkingProjectsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.WorkingEmployeesID, x.WorkingProjectsID });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_WorkingEmployeesID",
                        column: x => x.WorkingEmployeesID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_WorkingProjectsID",
                        column: x => x.WorkingProjectsID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkingDepartmentID",
                table: "Employees",
                column: "WorkingDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CarLicenses_OwningEmployeeID",
                table: "CarLicenses",
                column: "OwningEmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_WorkingProjectsID",
                table: "EmployeeProject",
                column: "WorkingProjectsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_WorkingDepartmentID",
                table: "Employees",
                column: "WorkingDepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_WorkingDepartmentID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "CarLicenses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WorkingDepartmentID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkingDepartmentID",
                table: "Employees");
        }
    }
}
