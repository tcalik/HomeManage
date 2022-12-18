using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RechargeObjectsTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RechangeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RechangeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RechangeObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RechangeTypeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RechangeObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RechangeObjects_RechangeTypes_RechangeTypeId",
                        column: x => x.RechangeTypeId,
                        principalTable: "RechangeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    BrandId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceBrandId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DefaultRechangeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefaulRechangeQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceModel_DeviceBrand_DeviceBrandId",
                        column: x => x.DeviceBrandId,
                        principalTable: "DeviceBrand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeviceModel_RechangeObjects_DefaultRechangeId",
                        column: x => x.DefaultRechangeId,
                        principalTable: "RechangeObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualDevice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DeviceModelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceRechangeTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceRechangeQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualDevice_DeviceModel_DeviceModelId",
                        column: x => x.DeviceModelId,
                        principalTable: "DeviceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualDevice_RechangeTypes_DeviceRechangeTypeId",
                        column: x => x.DeviceRechangeTypeId,
                        principalTable: "RechangeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualDevice_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceModel_DefaultRechangeId",
                table: "DeviceModel",
                column: "DefaultRechangeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceModel_DeviceBrandId",
                table: "DeviceModel",
                column: "DeviceBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDevice_DeviceModelId",
                table: "IndividualDevice",
                column: "DeviceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDevice_DeviceRechangeTypeId",
                table: "IndividualDevice",
                column: "DeviceRechangeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDevice_RoomId",
                table: "IndividualDevice",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RechangeObjects_RechangeTypeId",
                table: "RechangeObjects",
                column: "RechangeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualDevice");

            migrationBuilder.DropTable(
                name: "DeviceModel");

            migrationBuilder.DropTable(
                name: "DeviceBrand");

            migrationBuilder.DropTable(
                name: "RechangeObjects");

            migrationBuilder.DropTable(
                name: "RechangeTypes");
        }
    }
}
