using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressVoitures.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarTransaction_CarId",
                table: "CarTransaction");

            migrationBuilder.DropIndex(
                name: "IX_CarRepair_CarId",
                table: "CarRepair");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AvailabilityDate",
                table: "CarTransaction",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<double>(
                name: "AdditionalAmount",
                table: "CarTransaction",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_CarTransaction_CarId",
                table: "CarTransaction",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarRepair_CarId",
                table: "CarRepair",
                column: "CarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarTransaction_CarId",
                table: "CarTransaction");

            migrationBuilder.DropIndex(
                name: "IX_CarRepair_CarId",
                table: "CarRepair");

            migrationBuilder.DropColumn(
                name: "AdditionalAmount",
                table: "CarTransaction");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AvailabilityDate",
                table: "CarTransaction",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarTransaction_CarId",
                table: "CarTransaction",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRepair_CarId",
                table: "CarRepair",
                column: "CarId");
        }
    }
}
