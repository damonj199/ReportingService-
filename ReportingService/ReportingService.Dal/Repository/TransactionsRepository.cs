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

        public async Task<TransactionDto> AddTransactions(TransactionDto transaction)
        {
            if (transaction == null)
            {
                _logger.Information("Throwing an error if the transaction is null. / Выдача ошибки, если транзакция равна null.");
                throw new();
            }
            
            _logger.Information($"Saving the transaction in the database. / Сохранение транзакции в базе.");
            _cxt.Transactions.Add(transaction);

            await _cxt.SaveChangesAsync();
            return transaction;
        }
    }
}
