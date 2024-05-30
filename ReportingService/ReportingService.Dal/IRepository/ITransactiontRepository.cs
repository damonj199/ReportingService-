using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository
{
    public interface ITransactiontRepository
    {
        public List<TransactionDto> GetInformationAllTransaction();
    }
}
