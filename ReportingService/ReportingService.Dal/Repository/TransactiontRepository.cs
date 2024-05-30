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

        public List<TransactionDto> GetInformationAllTransaction()
        {
            _logger.Information("ReportingService - TransactiontRepository - GetInformationAllTransaction");
            return _cxt.Transactions.ToList();
        }
    }
}
