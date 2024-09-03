using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Dal;

public class ReportingServiceContext : DbContext
{
    public DbSet<AccountDto> Accounts { get; set; }
    public DbSet<LeadDto> Leads { get; set; }
    public DbSet<TransactionDto> Transactions { get; set; }

    public ReportingServiceContext(DbContextOptions<ReportingServiceContext> options) : base(options)
    {
    } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<AccountStatus>();
        modelBuilder.HasPostgresEnum<Currency>();
        modelBuilder.HasPostgresEnum<LeadStatus>();
        modelBuilder.HasPostgresEnum<TransactionType>();

        modelBuilder.Entity<TransactionDto>(ConfigureTransactionDto);
        modelBuilder.Entity<LeadDto>(ConfigureLeadDto);
        modelBuilder.Entity<AccountDto>(ConfigureAccountDto);

    }
    private void ConfigureTransactionDto(EntityTypeBuilder<TransactionDto> builder)
    {
        builder.Property(t => t.Amount)
            .HasPrecision(11, 4);

        builder.Property(t => t.CommissionAmount)
            .HasPrecision(11, 4);

        builder.Property(t => t.AmountInRUB)
            .HasPrecision(11, 4);
    }

    private void ConfigureLeadDto(EntityTypeBuilder<LeadDto> builder)
    {
        builder.HasMany(l => l.Accounts)
            .WithOne(a => a.Lead);

        builder.Property(a => a.Address)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("character varying(50)")
            .HasColumnName("address"); ;

        builder.Property(a => a.Mail)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnType("character varying(30)")
            .HasColumnName("mail");

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnType("character varying(30)")
            .HasColumnName("name");

        builder.Property(a => a.Phone)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnType("character varying(12)")
            .HasColumnName("phone");
    }

    private void ConfigureAccountDto(EntityTypeBuilder<AccountDto> builder)
    {
        builder.HasMany(a => a.Transactions)
            .WithOne(t => t.Account);
    }
}
