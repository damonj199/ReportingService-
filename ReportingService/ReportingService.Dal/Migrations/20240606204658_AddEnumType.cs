using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "transaction_type",
                table: "transactions",
                type: "TransactionType",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "transactions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "currency_type",
                table: "transactions",
                type: "CurrencyType",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "status_history",
                type: "LeadStatus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "leads",
                type: "LeadStatus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "accounts",
                type: "AccountStatus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "currency",
                table: "accounts",
                type: "CurrencyType",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "transaction_type",
                table: "transactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "TransactionType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "transactions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<int>(
                name: "currency_type",
                table: "transactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "CurrencyType");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "status_history",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "LeadStatus");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "leads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "LeadStatus");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "accounts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "AccountStatus");

            migrationBuilder.AlterColumn<int>(
                name: "currency",
                table: "accounts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "CurrencyType");
        }
    }
}
