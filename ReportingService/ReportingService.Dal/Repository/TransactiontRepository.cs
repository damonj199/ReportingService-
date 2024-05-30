using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.Dal.Repository
{
    public  class TransactiontRepository : BaseRepository, ITransactiontRepository
    {
        private readonly ILogger _logger = Log.ForContext<TransactiontRepository>();

        public TransactiontRepository(ReportingServiceContext context) : base(context)
        {

        }

        public List<TransactionDto> GetInformationAllTransaction()
        {
            //return new List<TransactionDto> { new TransactionDto( ) };
            return _cxt.Transactions.ToList();
        }
    }
}
