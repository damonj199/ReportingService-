using ReportingService.Bll.IServices;
using ReportingService.Dal.IRepository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.Bll.Services;

public class AccountsService : IAccountsService
{
    private readonly IAccountsRepository _accountRepository;
    private readonly ILogger _logger = Log.ForContext<AccountsService>();

    public AccountsService()
    {
        
    }
}
