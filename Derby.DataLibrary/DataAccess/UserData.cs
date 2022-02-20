using Derby.DataLibrary.Internal.DataAccess;
using Derby.DataLibrary.Models;
using System.Collections.Generic;

namespace Derby.DataLibrary.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sql;

        public UserData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<UserModel> GetUsers()
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.GetUsers", new {  }, "DerbyDB");

            return output;
        }
    }
}
