using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CorrectDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDevice_RechangeTypes_DeviceRechangeTypeId",
                table: "IndividualDevice");

            migrationBuilder.RenameColumn(
                name: "DeviceRechangeTypeId",
                table: "IndividualDevice",
                newName: "DeviceRechangeObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualDevice_DeviceRechangeTypeId",
                table: "IndividualDevice",
                newName: "IX_IndividualDevice_DeviceRechangeObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDevice_RechangeObjects_DeviceRechangeObjectId",
                table: "IndividualDevice",
                column: "DeviceRechangeObjectId",
                principalTable: "RechangeObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDevice_RechangeObjects_DeviceRechangeObjectId",
                table: "IndividualDevice");

            migrationBuilder.RenameColumn(
                name: "DeviceRechangeObjectId",
                table: "IndividualDevice",
                newName: "DeviceRechangeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualDevice_DeviceRechangeObjectId",
                table: "IndividualDevice",
                newName: "IX_IndividualDevice_DeviceRechangeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDevice_RechangeTypes_DeviceRechangeTypeId",
                table: "IndividualDevice",
                column: "DeviceRechangeTypeId",
                principalTable: "RechangeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
