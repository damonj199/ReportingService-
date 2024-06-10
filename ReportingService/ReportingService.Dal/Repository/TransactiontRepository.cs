using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Dal.Repository
{
    public class TransactiontRepository : BaseRepository, ITransactiontRepository
    {
        private readonly ILogger _logger = Log.ForContext<TransactiontRepository>();

        public TransactiontRepository(ReportingServiceContext context) : base(context)
        {

        }

        public async Task<List<TransactionDto>> GetAllTransactionsAsync()
        {
            _logger.Information("ReportingService - TransactiontRepository - GetInformationAllTransaction");
            var transactions = await _cxt.Transactions.ToListAsync();

            return transactions;
        }

        public async Task<List<TransactionDto>> GetTransactionsByLeadIdAsync(Guid id)
        {
            _logger.Information("ReportingService - TransactiontRepository - GetTransactionsByLeadIdAsynk");
            return await _cxt.Transactions
                .AsNoTracking()
                .Where(t => t.Account.Id == id)
                .ToListAsync();
        }

        public async Task<List<TransactionDto>> GetTransactionsByAccountIdAsync(Guid id)
        {
            _logger.Information("ReportingService - TransactiontRepository - GetTransactionsByAccountIdAsynk");
            return await _cxt.Transactions
                .AsNoTracking()
                .Where(t => t.Id == id)
                .ToListAsync();
        }

        public async Task<List<AccountNegativBalanceDto>> GetAccountsWithNegativeBalanceAsync()
        {
            _logger.Information("Идем в базу искать акк с отрицательным балансом");
            return await _cxt.Transactions
                .AsNoTracking()
                .GroupBy(a => a.Account.Id)
                .Select(j => new AccountNegativBalanceDto
                {
                    AccountId = j.Key,
                    Sum = j.Sum(t => t.Amount)
                })
                .Where(t => t.Sum < 0)
                .ToListAsync();
        }


    }
}
