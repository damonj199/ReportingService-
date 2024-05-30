using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.Bll.IServices
{
    public interface ITransactionsService
    {
        public List<TransactionResponse> GetInformationAllTransaction();
    }
}
