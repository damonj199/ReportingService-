using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Bll.Models.Responses
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }
        public AccountDto Account { get; set; }
        public TransactionType TransactionType { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public double Commission { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

    }
}

