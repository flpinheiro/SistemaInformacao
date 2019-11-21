using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusExpress.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BusExpress");

            migrationBuilder.CreateTable(
                name: "BusStops",
                schema: "BusExpress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStops", x => x.Id);
                    table.UniqueConstraint("Location", x => new { x.Latitude, x.Longitude });
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "BusExpress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRote",
                schema: "BusExpress",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoutesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRote", x => new { x.UserId, x.RoutesId });
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                schema: "BusExpress",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => new { x.CompanyId, x.LicensePlate });
                    table.ForeignKey(
                        name: "FK_Bus_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "BusExpress",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "BusExpress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserRoteRoutesId = table.Column<int>(nullable: true),
                    UserRoteUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRote_UserRoteUserId_UserRoteRoutesId",
                        columns: x => new { x.UserRoteUserId, x.UserRoteRoutesId },
                        principalSchema: "BusExpress",
                        principalTable: "UserRote",
                        principalColumns: new[] { "UserId", "RoutesId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                schema: "BusExpress",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Card_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BusExpress",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                schema: "BusExpress",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    StartPointId = table.Column<int>(nullable: false),
                    EndPointId = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: true),
                    UserRoteRoutesId = table.Column<int>(nullable: true),
                    UserRoteUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => new { x.UserId, x.Name });
                    table.ForeignKey(
                        name: "FK_Route_BusStops_EndPointId",
                        column: x => x.EndPointId,
                        principalSchema: "BusExpress",
                        principalTable: "BusStops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Route_BusStops_StartPointId",
                        column: x => x.StartPointId,
                        principalSchema: "BusExpress",
                        principalTable: "BusStops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Route_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BusExpress",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Route_UserRote_UserRoteUserId_UserRoteRoutesId",
                        columns: x => new { x.UserRoteUserId, x.UserRoteRoutesId },
                        principalSchema: "BusExpress",
                        principalTable: "UserRote",
                        principalColumns: new[] { "UserId", "RoutesId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusLines",
                schema: "BusExpress",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false),
                    DotNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RouteName = table.Column<string>(nullable: true),
                    RouteUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusLines", x => new { x.Number, x.DotNumber });
                    table.ForeignKey(
                        name: "FK_BusLines_Route_RouteUserId_RouteName",
                        columns: x => new { x.RouteUserId, x.RouteName },
                        principalSchema: "BusExpress",
                        principalTable: "Route",
                        principalColumns: new[] { "UserId", "Name" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusStopLine",
                schema: "BusExpress",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false),
                    DotNumber = table.Column<int>(nullable: false),
                    BusStopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStopLine", x => new { x.BusStopId, x.Number, x.DotNumber });
                    table.ForeignKey(
                        name: "FK_BusStopLine_BusStops_BusStopId",
                        column: x => x.BusStopId,
                        principalSchema: "BusExpress",
                        principalTable: "BusStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusStopLine_BusLines_Number_DotNumber",
                        columns: x => new { x.Number, x.DotNumber },
                        principalSchema: "BusExpress",
                        principalTable: "BusLines",
                        principalColumns: new[] { "Number", "DotNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusLines_RouteUserId_RouteName",
                schema: "BusExpress",
                table: "BusLines",
                columns: new[] { "RouteUserId", "RouteName" });

            migrationBuilder.CreateIndex(
                name: "IX_BusStopLine_Number_DotNumber",
                schema: "BusExpress",
                table: "BusStopLine",
                columns: new[] { "Number", "DotNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Route_EndPointId",
                schema: "BusExpress",
                table: "Route",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_StartPointId",
                schema: "BusExpress",
                table: "Route",
                column: "StartPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_UserRoteUserId_UserRoteRoutesId",
                schema: "BusExpress",
                table: "Route",
                columns: new[] { "UserRoteUserId", "UserRoteRoutesId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoteUserId_UserRoteRoutesId",
                schema: "BusExpress",
                table: "Users",
                columns: new[] { "UserRoteUserId", "UserRoteRoutesId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bus",
                schema: "BusExpress");

            migrationBuilder.DropTable(
                name: "BusStopLine",
                schema: "BusExpress");

            migrationBuilder.DropTable(
                name: "Card",
                schema: "BusExpress");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "BusExpress");

            migrationBuilder.DropTable(
                name: "BusLines",
                schema: "BusExpress");

            migrationBuilder.DropTable(
                name: "Route",
                schema: "BusExpress");

            migrationBuilder.DropTable(
                name: "BusStops",
                schema: "BusExpress");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "BusExpress");

            migrationBuilder.DropTable(
                name: "UserRote",
                schema: "BusExpress");
        }
    }
}
