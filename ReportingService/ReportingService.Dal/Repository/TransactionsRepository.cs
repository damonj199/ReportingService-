﻿using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Dal.Repository
{
    public class TransactionsRepository : BaseRepository, ITransactiontRepository
    {
        private readonly ILogger _logger = Log.ForContext<TransactionsRepository>();

        public TransactionsRepository(ReportingServiceContext context) : base(context)
        {
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(Guid id)
        {
            _logger.Information("receiving in Db transactions by id");
            return await _cxt.Transactions
                .AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TransactionDto>> GetTransactionsByPeriodDayAsync(int countDays)
        {
            DateTime startDate = DateTime.UtcNow.AddDays(-countDays);

            _logger.Information("receiving in Db transactions for a period");

            return await _cxt.Transactions
                .Include(a => a.Account)
                .AsNoTracking()
                .Where(t => t.Date >= startDate)
                .ToListAsync();
        }

        public async Task<List<AccountNegativBalanceDto>> GetAccountsWithNegativeBalanceAsync()
        {
            _logger.Information("search for accounts in the database with negative balances");
            return await _cxt.Transactions
                .AsNoTracking()
                .GroupBy(a => a.Account.Id)
                .Select(j => new AccountNegativBalanceDto
                {
                    AccountId = j.Key,
                    Sum = j.Sum(t => t.Amount)
                })
                .Where(t => t.Sum < 0)
                .Take(5000)
                .ToListAsync();
        }

        public async Task<TransactionDto> AddTransactionsAsync(TransactionDto transaction)
        {
            _logger.Information($"polychili dto s service {transaction.Date}");

            await _cxt.Transactions.AddAsync(transaction);
            _logger.Information($"dobavlyem v dataBase {transaction.Currency}");
            _logger.Information($"Add transactions for data {transaction.Id}, {transaction.AccountId}, {transaction.TransactionType}," +
                $" {transaction.Amount}, {transaction.Date}, {transaction.Currency}, {transaction.CommissionAmount}, {transaction.AmountInRUB}");

            await _cxt.SaveChangesAsync();
            _logger.Information($"Saving the transaction in the database. {transaction.Id}");

            return transaction;
        }
    }
}
