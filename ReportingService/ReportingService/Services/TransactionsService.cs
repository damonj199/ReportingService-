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

    public async Task<List<TransactionResponse>> GetAllTransactionAsync()
    {
        _logger.Information("ReportingService - TransactionsService - GetInformationAllTransaction");
        var transactions = await _transactionRepository.GetAllTransactionAsync();

        return _mapper.Map<List<TransactionResponse>>(transactions);

    }

    public async Task<List<TransactionResponse>> GetTransactionsByLeadIdAsynk(Guid id)
    {
        _logger.Information($"ReportingService - TransactionController - GetInformationByAccountIdAsync");
        List<TransactionDto> transactions = await _transactionRepository.GetTransactionsByLeadIdAsynk(id);
        return _mapper.Map<List<TransactionResponse>>(transactions);
    }

    public async Task<List<TransactionWithAccountIdResponse>> GetTransactionsByAccountIdAsynk(Guid id)
    {
        _logger.Information($"ReportingService - TransactionController - GetTransactionsByAccountIdAsynk");
        List<TransactionDto> transactions = await _transactionRepository.GetTransactionsByAccountIdAsynk(id);
        return _mapper.Map<List<TransactionWithAccountIdResponse>>(transactions);
    }
}
