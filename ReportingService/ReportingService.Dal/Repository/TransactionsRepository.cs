using Messaging.Shared;
using Microsoft.EntityFrameworkCore;
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
            _logger.Information("ReportingService - TransactiontRepository - GetInformationAllTransaction");
            return await _cxt.Transactions
                .AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TransactionDto>> GetTransactionsByPeriodDayAsync(int countDays)
        {
            DateTime startDate = DateTime.UtcNow.AddDays(-countDays);

            _logger.Information("ReportingService - TransactiontRepository - GetTransactionsByAccountIdAsynk");

            var transactions = _cxt.Transactions.Include(a => a.Account)
                .AsNoTracking()
                .Where(t => t.Date >= startDate);

            return await transactions.ToListAsync();
        }

        public async Task<List<AccountNegativBalanceDto>> GetAccountsWithNegativeBalanceAsync()
        {
            _logger.Information("Идем в базу искать акк с отрицательным балансом");
            var acc = _cxt.Transactions
                .AsNoTracking()
                .GroupBy(a => a.Account.Id)
                .Select(j => new AccountNegativBalanceDto
                {
                    AccountId = j.Key,
                    Sum = j.Sum(t => t.Amount)
                })
                .Where(t => t.Sum < 0);

             return await acc.ToListAsync();
        }

        public async Task<TransactionDto> AddTransactionsAsync(TransactionDto transaction)
        {
            _logger.Information($"polychili dto s service {transaction.Date}");

            await _cxt.Transactions.AddAsync(transaction);
            _logger.Information($"dobavlyem v dataBase {transaction.Currency}");
            await _cxt.SaveChangesAsync();

            _logger.Information($"Saving the transaction in the database. {transaction.Id} / Сохранение транзакции в базе.");
            return transaction;
        }
    }
}
