using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using UserService.DataLibrary.DataAccess;
using UserService.DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN")]
    public class UserController : ControllerBase
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
            List<UserModel> users = null;
            try
            {
                users = _userData.GetUserById(id);
            }
            catch
            {
                Console.WriteLine("UserId Cannot be null or empty");
            }
            return users;
        }

        [HttpPut]
        [Route("updateuser")]
        public void UpdateUser(UserModel userModel)
        {
            try
            {
                _userData.UpdateUser(userModel);
            }
            catch
            {
                Console.WriteLine("UserId OR FirstName OR LastName OR Email Cannot be null or empty");
            }
        }

        [HttpDelete]
        [Route("deleteuser")]
        public void DeleteUser(string id)
        {
            try
            {
                _userData.DeleteUser(id);
            }
            catch
            {
                Console.WriteLine("UserId Cannot be null or empty");
            }
        }

    }
}
