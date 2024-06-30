using Microsoft.EntityFrameworkCore.Migrations;
using ReportingService.Core.Enums;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .Annotation("Npgsql:Enum:currency", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .Annotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block,administrator")
                .Annotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer")
                .OldAnnotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .OldAnnotation("Npgsql:Enum:currency_type", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .OldAnnotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block,administrator")
                .OldAnnotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer");

            migrationBuilder.AlterColumn<Currency>(
                name: "currency",
                table: "accounts",
                type: "currency",
                nullable: false,
                oldClrType: typeof(Currency),
                oldType: "currency_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .Annotation("Npgsql:Enum:currency_type", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .Annotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block,administrator")
                .Annotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer")
                .OldAnnotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .OldAnnotation("Npgsql:Enum:currency", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .OldAnnotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block,administrator")
                .OldAnnotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer");

            migrationBuilder.AlterColumn<Currency>(
                name: "currency",
                table: "accounts",
                type: "currency_type",
                nullable: false,
                oldClrType: typeof(Currency),
                oldType: "currency");
        }
    }
}
