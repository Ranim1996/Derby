using UserService.DataLibrary.DataAccess;
using UserService.DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserData _userData;
        public UserController(IUserData userData)
        {
            _userData = userData;
        }

        [HttpGet]
        [Route("getusers")]
        public List<UserModel> GetUsers()
        {
            return _userData.GetUsers();
        }

        [HttpGet]
        [Route("getuserbyId")]
        public List<UserModel> GetUserById(string id)
        {
            return _userData.GetUserById(id);
        }

        [HttpPut]
        [Route("updateuser")]
        public void UpdateUser(UserModel userModel)
        {
            _userData.UpdateUser(userModel);
        }

        [HttpDelete]
        [Route("deleteuser")]
        public void DeleteUser(string id)
        {
            _userData.DeleteUser(id);
        }

    }
}
