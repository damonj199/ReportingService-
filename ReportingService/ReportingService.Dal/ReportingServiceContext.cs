using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Dal;

public class ReportingServiceContext : DbContext
{
    public DbSet<AccountDto> Accounts { get; set; }
    public DbSet<LeadDto> Leads { get; set; }
    public DbSet<TransactionDto> Transactions {  get; set; }
    public DbSet<StatusHistoryDto> StatusHistory { get; set; }

    public ReportingServiceContext(DbContextOptions<ReportingServiceContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StatusHistoryDto>()
            .HasOne(s => s.Lead)
            .WithMany(l => l.StatusHistory);

        modelBuilder
            .Entity<LeadDto>()
            .HasMany(l => l.Accounts)
            .WithOne(a => a.Leads);

        modelBuilder.Entity<LeadDto>()
            .Property(a => a.Address)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("character varying(50)")
            .HasColumnName("address"); ;

        modelBuilder.Entity<LeadDto>()
            .Property(a => a.Mail)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnType("character varying(30)")
            .HasColumnName("mail");

        modelBuilder.Entity<LeadDto>()
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnType("character varying(30)")
            .HasColumnName("name");

        modelBuilder.Entity<LeadDto>()
            .Property(a => a.Phone)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnType("character varying(12)")
            .HasColumnName("phone");

        modelBuilder
            .Entity<AccountDto>()
            .HasMany(a => a.Transactions)
            .WithOne(t => t.Account);

        modelBuilder.Entity<TransactionDto>()
            .Property(a => a.Amount)
            .HasPrecision(11, 4);

        modelBuilder.HasPostgresEnum<AccountStatus>();
        modelBuilder.HasPostgresEnum<CurrencyType>();
        modelBuilder.HasPostgresEnum<LeadStatus>();
        modelBuilder.HasPostgresEnum<TransactionType>();
    }
}
