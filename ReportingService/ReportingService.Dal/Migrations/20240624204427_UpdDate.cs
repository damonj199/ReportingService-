using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UpdDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "day",
                table: "leads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "month",
                table: "leads",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "day",
                table: "leads");

            migrationBuilder.DropColumn(
                name: "month",
                table: "leads");
        }
    }
}
