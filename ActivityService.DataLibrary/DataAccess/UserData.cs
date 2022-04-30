using ActivityService.DataLibrary.Internal.DataAccess;
using ActivityService.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityService.DataLibrary.DataAccess.Interfaces
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sql;

        public UserData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void AddUser(UserModel userModel)
        {
            var p = new
            {
                userId = userModel.Id,
                userFirstName = userModel.FirstName,
                userLastName = userModel.LastName
            };

            _sql.SaveData("dbo.AddUser", p, "ActivityDB");
        }
    }
}
