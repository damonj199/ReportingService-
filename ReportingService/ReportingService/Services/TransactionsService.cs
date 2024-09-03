using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;
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

    public async Task<TransactionDto> AddTransactionsAsync(TransactionDto transaction)
    {
        _logger.Information("polychili dto s api");
        TransactionDto transactions = await _transactionRepository.AddTransactionsAsync(transaction);
        _logger.Information("smogli otdat' v repository?");
        return transactions;
    }
    public async Task<TransactionResponse> GetTransactionByIdsAsync(Guid id)
    {
        _logger.Information("Get transaction by id -> repository");
        TransactionDto transactions = await _transactionRepository.GetTransactionByIdAsync(id);

        return _mapper.Map<TransactionResponse>(transactions);

    }

    public async Task<List<TransactionResponse>> GetTransactionsByPeriodDayAsync(int countDays)
    {
        _logger.Information($"go to -> repository to look for all transactions for {countDays} days");
        List<TransactionDto> transactions = await _transactionRepository.GetTransactionsByPeriodDayAsync(countDays);

        return _mapper.Map<List<TransactionResponse>>(transactions);
    }

    public async Task<List<NegativBalanceResponse>> GetAccountsNegativBalanceAsync()
    {
        _logger.Information("Let's go -> repository look for accounts with a negative balance");
        List<AccountNegativBalanceDto> negBalance = await _transactionRepository.GetAccountsWithNegativeBalanceAsync();

        return _mapper.Map<List<NegativBalanceResponse>>(negBalance);
    }
}
