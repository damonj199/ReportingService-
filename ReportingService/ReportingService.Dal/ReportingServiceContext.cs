using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Dal;

public class ReportingServiceContext(DbContextOptions<ReportingServiceContext> options) : DbContext(options)
{
    public DbSet<AccountDto> Accounts { get; set; }
    public DbSet<LeadDto> Leads { get; set; }
    public DbSet<TransactionDto> Transactions {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<LeadDto>()
            .HasMany(l => l.Accounts)
            .WithOne(a => a.Leads);

        modelBuilder.Entity<LeadDto>()
            .Property(a => a.Address)
            .HasColumnType("nvarchar(50)"); ;

        modelBuilder.Entity<LeadDto>()
            .Property(a => a.Mail)
            .HasColumnType("nvarchar(30)");

        modelBuilder.Entity<LeadDto>()
            .Property(a => a.Name)
            .HasColumnType("nvarchar(30)");

        modelBuilder.Entity<LeadDto>()
            .Property(a => a.Phone)
            .HasColumnType("nvarchar(12)");

        modelBuilder
            .Entity<AccountDto>()
            .HasMany(a => a.Transactions)
            .WithOne(t => t.AccountId);

        modelBuilder.Entity<TransactionDto>()
            .Property(a => a.Amount)
            .HasPrecision(11, 4);

        modelBuilder.HasPostgresEnum<AccountStatus>();
        modelBuilder.HasPostgresEnum<CurrencyType>();
        modelBuilder.HasPostgresEnum<LeadStatus>();
        modelBuilder.HasPostgresEnum<TransactionType>();
    }
}
