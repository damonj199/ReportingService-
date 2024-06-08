using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UdateEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .Annotation("Npgsql:Enum:currency_type", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .Annotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block,administrator")
                .Annotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer")
                .OldAnnotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .OldAnnotation("Npgsql:Enum:currency_type", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .OldAnnotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block")
                .OldAnnotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .Annotation("Npgsql:Enum:currency_type", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .Annotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block")
                .Annotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer")
                .OldAnnotation("Npgsql:Enum:account_status", "unknown,active,blocked")
                .OldAnnotation("Npgsql:Enum:currency_type", "unknown,rub,usd,eur,jpy,cny,rsd,bgn,ars")
                .OldAnnotation("Npgsql:Enum:lead_status", "unknown,vip,regular,block,administrator")
                .OldAnnotation("Npgsql:Enum:transaction_type", "unknown,deposit,withdraw,transfer");
        }
    }
}
