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

        public async Task<List<TransactionDto>> GetInformationAllTransactionAsync()
        {
            _logger.Information("ReportingService - TransactiontRepository - GetInformationAllTransaction");
            var transactions = await _cxt.Transactions.ToListAsync();

            return transactions;
        }
    }
}
