using System;
namespace UserService.DataLibrary.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedData { get; set; }

        public UserModel()
        {

        }

        public UserModel(string id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
        }
    }
}
