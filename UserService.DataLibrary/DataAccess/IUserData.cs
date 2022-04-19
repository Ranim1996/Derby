using UserService.DataLibrary.Models;
using System.Collections.Generic;

namespace UserService.DataLibrary.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUsers();
        void UpdateUser(UserModel user);
        List<UserModel> GetUserById(string id);
        void DeleteUser(string id);
    }
}