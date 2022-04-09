using AuthService.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.DataLibrary.DataAccess
{
    public interface IAccountData
    {
        List<AccountModel> GetAccounts();
        Task CreateAccount(AccountModel account);
    }
}
