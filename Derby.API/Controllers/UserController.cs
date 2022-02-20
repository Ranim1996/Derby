using Derby.DataLibrary.DataAccess;
using Derby.DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Derby.API.Controllers
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
        public List<UserModel> GetUsers()
        {
            return _userData.GetUsers();
        }
    }
}
