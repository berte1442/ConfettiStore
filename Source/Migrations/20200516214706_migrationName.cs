using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfettiStore.Migrations
{
    public partial class migrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Statuses_CustomerId",
                table: "CustomerOrders");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_StatusId",
                table: "CustomerOrders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Statuses_StatusId",
                table: "CustomerOrders",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Statuses_StatusId",
                table: "CustomerOrders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrders_StatusId",
                table: "CustomerOrders");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Statuses_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
