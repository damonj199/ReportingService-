using System;
using Microsoft.EntityFrameworkCore.Migrations;
using ReportingService.Core.Enums;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class updateDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "status_history");

            migrationBuilder.AlterColumn<decimal>(
                name: "commission_amount",
                table: "transactions",
                type: "numeric(11,4)",
                precision: 11,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount_in_rub",
                table: "transactions",
                type: "numeric(11,4)",
                precision: 11,
                scale: 4,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "commission_amount",
                table: "transactions",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(11,4)",
                oldPrecision: 11,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "amount_in_rub",
                table: "transactions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(11,4)",
                oldPrecision: 11,
                oldScale: 4,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "status_history",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    lead_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<LeadStatus>(type: "lead_status", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_status_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_status_history_leads_lead_id",
                        column: x => x.lead_id,
                        principalTable: "leads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_status_history_lead_id",
                table: "status_history",
                column: "lead_id");
        }
    }
}
