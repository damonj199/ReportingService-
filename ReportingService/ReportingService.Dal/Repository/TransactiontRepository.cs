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

        public async Task<TransactionDto> GetTransactionByIdAsync(Guid id)
        {
            _logger.Information("ReportingService - TransactiontRepository - GetInformationAllTransaction");
            return await _cxt.Transactions
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        //public async Task<List<TransactionDto>> GetTransactionsByLeadIdAsync(Guid id)
        //{
        //    _logger.Information("ReportingService - TransactiontRepository - GetTransactionsByLeadIdAsynk");
        //    return await _cxt.Transactions
        //        .AsNoTracking()
        //        .Where(t => t.Account.Lead.Id == id)
        //        .ToListAsync();
        //}

        public async Task<List<TransactionDto>> GetTransactionsByPeriodDayAsync(int countDays)
        {
            DateTime startDate = DateTime.UtcNow.AddDays(-countDays);

            _logger.Information("ReportingService - TransactiontRepository - GetTransactionsByAccountIdAsynk");
            return await _cxt.Transactions
                .AsNoTracking()
                .Where(t => t.Date >= startDate)
                .Take(5000)
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
                .Take(5000)
                .ToListAsync();
        }
    }
}
