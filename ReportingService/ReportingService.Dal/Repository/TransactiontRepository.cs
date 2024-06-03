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

        public async Task<List<TransactionDto>> GetAllTransactionAsync()
        {
            _logger.Information("ReportingService - TransactiontRepository - GetInformationAllTransaction");
            var transactions = await _cxt.Transactions.ToListAsync();

            return transactions;
        }

        public async Task<List<TransactionDto>> GetTransactionsByLeadIdAsynk(Guid id)
        {
            _logger.Information("ReportingService - TransactiontRepository - GetTransactionsByLeadIdAsynk");
            return await _cxt.Transactions.Where(t => t.Account.Id == id).ToListAsync();
        }

        public async Task<List<TransactionDto>> GetTransactionsByAccountIdAsynk(Guid id)
        {
            _logger.Information("ReportingService - TransactiontRepository - GetTransactionsByAccountIdAsynk");
            return await _cxt.Transactions.Where(t => t.Id == id).ToListAsync();
        }
    }
}
