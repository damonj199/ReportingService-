using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository
{
    public interface ITransactiontRepository
    {
        public Task<List<TransactionDto>> GetInformationAllTransactionAsync();
    }
}
