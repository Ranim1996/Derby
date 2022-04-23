using Derby.MessageBus;

namespace AuthService.DataLibrary.Models
{
    public class AccountModel: BaseMessage
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
