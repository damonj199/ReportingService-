using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Core.Emums;

namespace ReportingService.Dal;

public class ReportingServiceContext(DbContextOptions<ReportingServiceContext> options) : DbContext(options)
{
    public DbSet<AccountsDto> Accounts { get; set; }
    public DbSet<LeadsDto> Leads { get; set; }
    public DbSet<TransactionsDto> Transactions {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<LeadsDto>()
            .HasMany(l => l.Accounts)
            .WithOne(a => a.Leads);

        modelBuilder
            .Entity<AccountsDto>()
            .HasMany(a => a.Transactions)
            .WithOne(t => t.AccountsId);

        modelBuilder.HasPostgresEnum<AccountStatus>();
        modelBuilder.HasPostgresEnum<CurrencyType>();
        modelBuilder.HasPostgresEnum<LeadStatus>();
        modelBuilder.HasPostgresEnum<TransactionType>();
    }
}
