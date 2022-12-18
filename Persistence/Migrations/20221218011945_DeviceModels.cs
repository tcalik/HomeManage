using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeviceModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceModel_DeviceBrand_DeviceBrandId",
                table: "DeviceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceModel_RechangeObjects_DefaultRechangeId",
                table: "DeviceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDevice_DeviceModel_DeviceModelId",
                table: "IndividualDevice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceModel",
                table: "DeviceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceBrand",
                table: "DeviceBrand");

            migrationBuilder.RenameTable(
                name: "DeviceModel",
                newName: "DeviceModels");

            migrationBuilder.RenameTable(
                name: "DeviceBrand",
                newName: "DeviceBrands");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "DeviceModels",
                newName: "DeviceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceModel_DeviceBrandId",
                table: "DeviceModels",
                newName: "IX_DeviceModels_DeviceBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceModel_DefaultRechangeId",
                table: "DeviceModels",
                newName: "IX_DeviceModels_DefaultRechangeId");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "IndividualDevice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceBrandId",
                table: "DeviceModels",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceModels",
                table: "DeviceModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceBrands",
                table: "DeviceBrands",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceModels_DeviceTypeId",
                table: "DeviceModels",
                column: "DeviceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceModels_DeviceBrands_DeviceBrandId",
                table: "DeviceModels",
                column: "DeviceBrandId",
                principalTable: "DeviceBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceModels_DeviceTypes_DeviceTypeId",
                table: "DeviceModels",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceModels_RechangeObjects_DefaultRechangeId",
                table: "DeviceModels",
                column: "DefaultRechangeId",
                principalTable: "RechangeObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDevice_DeviceModels_DeviceModelId",
                table: "IndividualDevice",
                column: "DeviceModelId",
                principalTable: "DeviceModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceModels_DeviceBrands_DeviceBrandId",
                table: "DeviceModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceModels_DeviceTypes_DeviceTypeId",
                table: "DeviceModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceModels_RechangeObjects_DefaultRechangeId",
                table: "DeviceModels");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDevice_DeviceModels_DeviceModelId",
                table: "IndividualDevice");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceModels",
                table: "DeviceModels");

            migrationBuilder.DropIndex(
                name: "IX_DeviceModels_DeviceTypeId",
                table: "DeviceModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceBrands",
                table: "DeviceBrands");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "IndividualDevice");

            migrationBuilder.RenameTable(
                name: "DeviceModels",
                newName: "DeviceModel");

            migrationBuilder.RenameTable(
                name: "DeviceBrands",
                newName: "DeviceBrand");

            migrationBuilder.RenameColumn(
                name: "DeviceTypeId",
                table: "DeviceModel",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceModels_DeviceBrandId",
                table: "DeviceModel",
                newName: "IX_DeviceModel_DeviceBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceModels_DefaultRechangeId",
                table: "DeviceModel",
                newName: "IX_DeviceModel_DefaultRechangeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceBrandId",
                table: "DeviceModel",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceModel",
                table: "DeviceModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceBrand",
                table: "DeviceBrand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceModel_DeviceBrand_DeviceBrandId",
                table: "DeviceModel",
                column: "DeviceBrandId",
                principalTable: "DeviceBrand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceModel_RechangeObjects_DefaultRechangeId",
                table: "DeviceModel",
                column: "DefaultRechangeId",
                principalTable: "RechangeObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDevice_DeviceModel_DeviceModelId",
                table: "IndividualDevice",
                column: "DeviceModelId",
                principalTable: "DeviceModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
