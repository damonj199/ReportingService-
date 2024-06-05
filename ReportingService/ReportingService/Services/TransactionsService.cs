using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;
using ReportingService.Dal.Repository;
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

    public async Task<List<TransactionResponse>> GetAllTransactionsAsync()
    {
        _logger.Information("ReportingService - TransactionsService - GetInformationAllTransaction");
        var transactions = await _transactionRepository.GetAllTransactionsAsync();

        return _mapper.Map<List<TransactionResponse>>(transactions);

    }

    public async Task<List<TransactionResponse>> GetTransactionsByLeadIdAsync(Guid id)
    {
        _logger.Information($"ReportingService - TransactionController - GetInformationByAccountIdAsync");
        List<TransactionDto> transactions = await _transactionRepository.GetTransactionsByLeadIdAsync(id);
        return _mapper.Map<List<TransactionResponse>>(transactions);
    }

    public async Task<List<TransactionWithAccountIdResponse>> GetTransactionsByAccountIdAsync(Guid id)
    {
        _logger.Information($"ReportingService - TransactionController - GetTransactionsByAccountIdAsynk");
        List<TransactionDto> transactions = await _transactionRepository.GetTransactionsByAccountIdAsync(id);
        return _mapper.Map<List<TransactionWithAccountIdResponse>>(transactions);
    }
}
