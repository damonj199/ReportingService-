﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReportingService.Core.Enums;
using ReportingService.Dal;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    [DbContext(typeof(ReportingServiceContext))]
    [Migration("20240608004935_UdateEnums")]
    partial class UdateEnums
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "account_status", new[] { "unknown", "active", "blocked" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "currency_type", new[] { "unknown", "rub", "usd", "eur", "jpy", "cny", "rsd", "bgn", "ars" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "lead_status", new[] { "unknown", "vip", "regular", "block", "administrator" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "transaction_type", new[] { "unknown", "deposit", "withdraw", "transfer" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ReportingService.Core.Dtos.AccountDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<CurrencyType>("Currency")
                        .HasColumnType("currency_type")
                        .HasColumnName("currency");

                    b.Property<Guid>("LeadsId")
                        .HasColumnType("uuid")
                        .HasColumnName("leads_id");

                    b.Property<AccountStatus>("Status")
                        .HasColumnType("account_status")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.HasIndex("LeadsId")
                        .HasDatabaseName("ix_accounts_leads_id");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.LeadDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("mail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("phone");

                    b.Property<LeadStatus>("Status")
                        .HasColumnType("lead_status")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_leads");

                    b.ToTable("leads", (string)null);
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.StatusHistoryDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<Guid>("LeadId")
                        .HasColumnType("uuid")
                        .HasColumnName("lead_id");

                    b.Property<LeadStatus>("Status")
                        .HasColumnType("lead_status")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_status_history");

                    b.HasIndex("LeadId")
                        .HasDatabaseName("ix_status_history_lead_id");

                    b.ToTable("status_history", (string)null);
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.TransactionDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

                    b.Property<decimal>("Amount")
                        .HasPrecision(11, 4)
                        .HasColumnType("numeric(11,4)")
                        .HasColumnName("amount");

                    b.Property<double>("Commission")
                        .HasColumnType("double precision")
                        .HasColumnName("commission");

                    b.Property<CurrencyType>("CurrencyType")
                        .HasColumnType("currency_type")
                        .HasColumnName("currency_type");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<TransactionType>("TransactionType")
                        .HasColumnType("transaction_type")
                        .HasColumnName("transaction_type");

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_transactions_account_id");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.AccountDto", b =>
                {
                    b.HasOne("ReportingService.Core.Dtos.LeadDto", "Leads")
                        .WithMany("Accounts")
                        .HasForeignKey("LeadsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_accounts_leads_leads_id");

                    b.Navigation("Leads");
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.StatusHistoryDto", b =>
                {
                    b.HasOne("ReportingService.Core.Dtos.LeadDto", "Lead")
                        .WithMany("StatusHistory")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_status_history_leads_lead_id");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.TransactionDto", b =>
                {
                    b.HasOne("ReportingService.Core.Dtos.AccountDto", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_accounts_account_id");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.AccountDto", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.LeadDto", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("StatusHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
