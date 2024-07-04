using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_transactions_accounts_account_id_id",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "account_id_id",
                table: "transactions",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "ix_transactions_account_id_id",
                table: "transactions",
                newName: "ix_transactions_account_id");

            migrationBuilder.AddForeignKey(
                name: "fk_transactions_accounts_account_id",
                table: "transactions",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_transactions_accounts_account_id",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "transactions",
                newName: "account_id_id");

            migrationBuilder.RenameIndex(
                name: "ix_transactions_account_id",
                table: "transactions",
                newName: "ix_transactions_account_id_id");

            migrationBuilder.AddForeignKey(
                name: "fk_transactions_accounts_account_id_id",
                table: "transactions",
                column: "account_id_id",
                principalTable: "accounts",
                principalColumn: "id");
        }
    }
}
