using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface ITransactionsService
{
    public Task<List<TransactionResponse>> GetInformationAllTransactionAsync();
}
