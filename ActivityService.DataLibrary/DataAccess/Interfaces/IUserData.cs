using ActivityService.DataLibrary.Models;

namespace ActivityService.DataLibrary.DataAccess.Interfaces
{
    public interface IUserData
    {
        void AddUser(UserModel userModel);
    }
}
