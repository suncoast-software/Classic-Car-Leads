using Microsoft.EntityFrameworkCore.Migrations;

namespace CCL_WEB.Migrations
{
    public partial class UpdateModelsAll01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Make",
                table: "Make");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Make");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "model");

            migrationBuilder.RenameTable(
                name: "Make",
                newName: "make");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "model",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "model",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "make",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_model",
                table: "model",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_make",
                table: "make",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_model",
                table: "model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_make",
                table: "make");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "model");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "model");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "make");

            migrationBuilder.RenameTable(
                name: "model",
                newName: "Model");

            migrationBuilder.RenameTable(
                name: "make",
                newName: "Make");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Model",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Make",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Make",
                table: "Make",
                column: "Id");
        }
    }
}
