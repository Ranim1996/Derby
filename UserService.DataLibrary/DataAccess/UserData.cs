using UserService.DataLibrary.Internal.DataAccess;
using UserService.DataLibrary.Models;
using System.Collections.Generic;
using System;

namespace UserService.DataLibrary.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sql;

        public UserData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public UserData()
        {
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

            if (string.IsNullOrEmpty(p.userId))
            {
                throw new ArgumentException("User ID Could not be null or empty");
            }

            if (string.IsNullOrEmpty(p.userFirstName))
            {
                throw new ArgumentException("First Name Could not be null or empty");
            }

            if (string.IsNullOrEmpty(p.userLastName))
            {
                throw new ArgumentException("Last Name Could not be null or empty");
            }

            if (string.IsNullOrEmpty(p.userEmail))
            {
                throw new ArgumentException("Email Could not be null or empty");
            }

            _sql.SaveData("dbo.UpdateUser", p , "UserDB");
        }

        public List<UserModel> GetUsers()
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.GetUsers", new {  }, "UserDB");

            return output;
        }

        public List<UserModel> GetUserById(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id Could not be null or empty");
            }

            var output = _sql.LoadData<UserModel, dynamic>("dbo.GetUserById", new { userId=id }, "UserDB");

            return output;
        }

        public void DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id Could not be null or empty");
            }

            _sql.SaveData("dbo.DeleteUser", new { userId=id }, "UserDB");
        }
    }
}
