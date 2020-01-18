using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CCL_WEB.Migrations
{
    public partial class UpdateModelDealer01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<string>(maxLength: 50, nullable: false),
                    DealerName = table.Column<string>(maxLength: 100, nullable: false),
                    DealerUrl = table.Column<string>(maxLength: 500, nullable: false),
                    Date_Visited = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingID = table.Column<string>(maxLength: 50, nullable: false),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Price = table.Column<string>(maxLength: 50, nullable: false),
                    Location = table.Column<string>(maxLength: 500, nullable: true),
                    Make = table.Column<string>(maxLength: 200, nullable: true),
                    Model = table.Column<string>(maxLength: 200, nullable: true),
                    Year = table.Column<string>(maxLength: 100, nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(maxLength: 200, nullable: true),
                    Engine = table.Column<string>(maxLength: 100, nullable: true),
                    Vin = table.Column<string>(maxLength: 100, nullable: true),
                    StockNumber = table.Column<string>(maxLength: 100, nullable: true),
                    DealerName = table.Column<string>(maxLength: 500, nullable: true),
                    DealerUrl = table.Column<string>(nullable: true),
                    MainImgUrl = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogId = table.Column<int>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    LogMessage = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dealer");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
