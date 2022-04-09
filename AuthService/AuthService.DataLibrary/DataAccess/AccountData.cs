using AuthService.DataLibrary.Internal.DataAccess;
using AuthService.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.DataLibrary.DataAccess
{
    public class AccountData : IAccountData
    {
        private readonly ISqlDataAccess _sql;

        public AccountData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task CreateAccount(AccountModel account)
        {
            await _sql.SaveData("dbo.CreateAccount", new { userId=account.Id, userFirstName=account.FirstName, userLastName=account.LastName, userEmail=account.EmailAddress }, "AuthDB");
        }

        public List<AccountModel> GetAccounts()
        {
            var output = _sql.LoadData<AccountModel, dynamic>("dbo.GetAccounts", new { }, "AuthDB");

            return output;
        }
    }
}
