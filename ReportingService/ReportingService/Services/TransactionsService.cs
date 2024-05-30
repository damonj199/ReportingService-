using Serilog;
using ReportingService.Bll.IServices;
using ReportingService.Dal.IRepository;
using AutoMapper;
using ReportingService.Core.Dtos;
using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.Services;

public class TransactionsService : ITransactionsService
{
    private readonly ITransactiontRepository _trunsactionRepository;
    private readonly ILogger _logger = Log.ForContext<TransactionsService>();
    private readonly IMapper _mapper;

    public TransactionsService(ITransactiontRepository trunsactionRepository, IMapper mapper)
    {
        _mapper = mapper;
        _trunsactionRepository = trunsactionRepository;
    }

    public List<TransactionResponse> GetInformationAllTransaction()
    {
        _logger.Information("GetCats - CatsService");
        return _mapper.Map<List<TransactionResponse>>(_trunsactionRepository.GetInformationAllTransaction());

    }
}
