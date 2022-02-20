using Derby.DataLibrary.Models;
using System.Collections.Generic;

namespace Derby.DataLibrary.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUsers();
    }
}