﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReportingService.Dal;

#nullable disable

namespace ReportingService.Dal.Migrations
{
    [DbContext(typeof(ReportingServiceContext))]
    [Migration("20240525004149_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "account_status", new[] { "unknown", "active", "blocked" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "currency_type", new[] { "unknown", "rub", "usd", "eur", "jpy", "cny", "rsd", "bgn", "ars" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "lead_status", new[] { "unknown", "vip", "regular", "block" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "transaction_type", new[] { "unknown", "deposit", "withdraw", "transfer" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ReportingService.Core.Dtos.AccountDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Currency")
                        .HasColumnType("integer")
                        .HasColumnName("currency");

                    b.Property<Guid>("LeadsId")
                        .HasColumnType("uuid")
                        .HasColumnName("leads_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
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
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("mail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_leads");

                    b.ToTable("leads", (string)null);
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.TransactionDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountsIdId")
                        .HasColumnType("uuid")
                        .HasColumnName("accounts_id_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("integer")
                        .HasColumnName("currency_type");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer")
                        .HasColumnName("transaction_type");

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.HasIndex("AccountsIdId")
                        .HasDatabaseName("ix_transactions_accounts_id_id");

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

            modelBuilder.Entity("ReportingService.Core.Dtos.TransactionDto", b =>
                {
                    b.HasOne("ReportingService.Core.Dtos.AccountDto", "AccountsId")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountsIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_accounts_accounts_id_id");

                    b.Navigation("AccountsId");
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.AccountDto", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ReportingService.Core.Dtos.LeadDto", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
