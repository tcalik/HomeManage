using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NonRequiredMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDevice_DeviceModels_DeviceModelId",
                table: "IndividualDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDevice_RechangeObjects_DeviceRechangeObjectId",
                table: "IndividualDevice");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDevice_DeviceModels_DeviceModelId",
                table: "IndividualDevice",
                column: "DeviceModelId",
                principalTable: "DeviceModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDevice_RechangeObjects_DeviceRechangeObjectId",
                table: "IndividualDevice",
                column: "DeviceRechangeObjectId",
                principalTable: "RechangeObjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDevice_DeviceModels_DeviceModelId",
                table: "IndividualDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDevice_RechangeObjects_DeviceRechangeObjectId",
                table: "IndividualDevice");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDevice_DeviceModels_DeviceModelId",
                table: "IndividualDevice",
                column: "DeviceModelId",
                principalTable: "DeviceModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDevice_RechangeObjects_DeviceRechangeObjectId",
                table: "IndividualDevice",
                column: "DeviceRechangeObjectId",
                principalTable: "RechangeObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
