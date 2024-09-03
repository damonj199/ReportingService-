using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddComission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "comission",
                table: "transactions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comission",
                table: "transactions");
        }
    }
}
