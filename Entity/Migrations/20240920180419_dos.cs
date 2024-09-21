using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class dos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "InputType",
                table: "Supplies");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Modulo",
                newName: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CategorySuppliesId",
                table: "Supplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_CategorySuppliesId",
                table: "Supplies",
                column: "CategorySuppliesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_CategorySupplies_CategorySuppliesId",
                table: "Supplies",
                column: "CategorySuppliesId",
                principalTable: "CategorySupplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_CategorySupplies_CategorySuppliesId",
                table: "Supplies");

            migrationBuilder.DropIndex(
                name: "IX_Supplies_CategorySuppliesId",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "CategorySuppliesId",
                table: "Supplies");

            migrationBuilder.RenameColumn(
                name: "Orders",
                table: "Modulo",
                newName: "Order");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Supplies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "InputType",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
