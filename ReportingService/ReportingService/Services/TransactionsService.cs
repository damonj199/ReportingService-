using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Bll.Services;

public class TransactionsService : ITransactionsService
{
    private readonly ITransactiontRepository _transactionRepository;
    private readonly ILogger _logger = Log.ForContext<TransactionsService>();
    private readonly IMapper _mapper;

    public TransactionsService(ITransactiontRepository trunsactionRepository, IMapper mapper)
    {
        _mapper = mapper;
        _transactionRepository = trunsactionRepository;
    }

    public async Task<List<TransactionResponse>> GetInformationAllTransactionAsync()
    {
        _logger.Information("ReportingService - TransactionsService - GetInformationAllTransaction");
        var transactions = await _transactionRepository.GetInformationAllTransactionAsync();

        return _mapper.Map<List<TransactionResponse>>(transactions);

    }
}
