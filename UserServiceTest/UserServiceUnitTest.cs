using System;
using UserService.DataLibrary.DataAccess;
using UserService.DataLibrary.Models;
using Xunit;

namespace UserServiceTest
{
    public class UserServiceUnitTest
    {
        [Fact]
        public void ValidateIdIsNull()
        {
            var userData = new UserData();

            Assert.Throws<ArgumentException>(() => userData.GetUserById(null));
        }

        [Fact]
        public void ValidateIdIsEmpty()
        {
            var userData = new UserData();

            Assert.Throws<ArgumentException>(() => userData.DeleteUser(""));
        }

        [Fact]
        public void ValidateFirstNameIsNull()
        {
            var userData = new UserData();
            var user = new UserModel("Id", null, "Last Name", "Email");

            Assert.Throws<ArgumentException>(() => userData.UpdateUser(user));
        }

        [Fact]
        public void ValidateFirstNameIsEmpty()
        {
            var userData = new UserData();
            var user = new UserModel("Id", "", "Last Name", "Email");

            Assert.Throws<ArgumentException>(() => userData.UpdateUser(user));
        }

        [Fact]
        public void ValidateLastNameIsNull()
        {
            var userData = new UserData();
            var user = new UserModel("Id", "First Name", null, "Email");

            Assert.Throws<ArgumentException>(() => userData.UpdateUser(user));
        }

        [Fact]
        public void ValidateLastNameIsEmpty()
        {
            var userData = new UserData();
            var user = new UserModel("Id", "First Name", "", "Email");

            Assert.Throws<ArgumentException>(() => userData.UpdateUser(user));
        }

        [Fact]
        public void ValidateEmailIsNull()
        {
            var userData = new UserData();
            var user = new UserModel("Id", "First Name", "Last Name", null);

            Assert.Throws<ArgumentException>(() => userData.UpdateUser(user));
        }

        [Fact]
        public void ValidateEmailIsEmpty()
        {
            var userData = new UserData();
            var user = new UserModel("Id", "First Name", "Last Name", "");

            Assert.Throws<ArgumentException>(() => userData.UpdateUser(user));
        }

    }
}
