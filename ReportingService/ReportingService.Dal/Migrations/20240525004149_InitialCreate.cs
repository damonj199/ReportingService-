using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .Annotation("Npgsql:Enum:currency_type", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .Annotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block")
                .Annotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer");

            migrationBuilder.CreateTable(
                name: "leads",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_leads", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    leads_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_accounts_leads_leads_id",
                        column: x => x.leads_id,
                        principalTable: "leads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    accounts_id_id = table.Column<Guid>(type: "uuid", nullable: false),
                    transaction_type = table.Column<int>(type: "integer", nullable: false),
                    currency_type = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_transactions_accounts_accounts_id_id",
                        column: x => x.accounts_id_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_accounts_leads_id",
                table: "accounts",
                column: "leads_id");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_accounts_id_id",
                table: "transactions",
                column: "accounts_id_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "leads");
        }
    }
}
