using UserService.DataLibrary.Internal.DataAccess;
using UserService.DataLibrary.Models;
using System.Collections.Generic;

namespace UserService.DataLibrary.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sql;

        public UserData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void UpdateUser(UserModel user)
        {
            var p = new
            {
                userId = user.Id,
                userFirstName = user.FirstName,
                userLastName = user.LastName,
                userEmail = user.EmailAddress
            };
            _sql.SaveData("dbo.UpdateUser", p , "UserDB");
        }

        public List<UserModel> GetUsers()
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.GetUsers", new {  }, "UserDB");

            return output;
        }

        public List<UserModel> GetUserById(string id)
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.GetUserById", new { userId=id }, "UserDB");

            return output;
        }

        public void DeleteUser(string id)
        {
            _sql.SaveData("dbo.DeleteUser", new { userId=id }, "UserDB");
        }
    }
}
