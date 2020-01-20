using Microsoft.EntityFrameworkCore.Migrations;

namespace CCL_WEB.Migrations
{
    public partial class UpdateModelDealer02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date_Visited",
                table: "Dealer",
                newName: "DateVisited");

            migrationBuilder.AddColumn<string>(
                name: "StockNumber",
                table: "Dealer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dealer",
                table: "Dealer",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dealer",
                table: "Dealer");

            migrationBuilder.DropColumn(
                name: "StockNumber",
                table: "Dealer");

            migrationBuilder.RenameColumn(
                name: "DateVisited",
                table: "Dealer",
                newName: "Date_Visited");
        }
    }
}
