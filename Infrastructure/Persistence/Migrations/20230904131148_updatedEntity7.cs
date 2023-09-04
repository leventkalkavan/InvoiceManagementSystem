using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedEntity7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserHouse_AspNetUsers_AppUserId",
                table: "AppUserHouse");

            migrationBuilder.DropTable(
                name: "HouseInvoice");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "AppUserHouse",
                newName: "AppUsersId");

            migrationBuilder.AlterColumn<string>(
                name: "HouseId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_HouseId",
                table: "Invoices",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserHouse_AspNetUsers_AppUsersId",
                table: "AppUserHouse",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Houses_HouseId",
                table: "Invoices",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserHouse_AspNetUsers_AppUsersId",
                table: "AppUserHouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Houses_HouseId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_HouseId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "AppUsersId",
                table: "AppUserHouse",
                newName: "AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "HouseId",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "HouseInvoice",
                columns: table => new
                {
                    HousesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoicesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseInvoice", x => new { x.HousesId, x.InvoicesId });
                    table.ForeignKey(
                        name: "FK_HouseInvoice_Houses_HousesId",
                        column: x => x.HousesId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseInvoice_Invoices_InvoicesId",
                        column: x => x.InvoicesId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseInvoice_InvoicesId",
                table: "HouseInvoice",
                column: "InvoicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserHouse_AspNetUsers_AppUserId",
                table: "AppUserHouse",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
