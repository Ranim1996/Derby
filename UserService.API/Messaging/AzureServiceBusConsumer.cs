using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using UserService.API.Messages;
using UserService.DataLibrary.DataAccess;
using UserService.DataLibrary.Models;

namespace UserService.API.Messaging
{
    public class AzureServiceBusConsumer: IAzureServiceBusConsumer
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _topicName;
        private readonly string _subscriptionName;
        private readonly IUserData _userData;

        private ServiceBusProcessor _checkoutProcessor;

        private readonly IConfiguration _config;

        public AzureServiceBusConsumer(IUserData userData, IConfiguration configuration)
        {
            _userData = userData;
            _config = configuration;

            _serviceBusConnectionString = _config.GetValue<string>("ServiceBusConnectionString");
            _topicName = _config.GetValue<string>("TopicName");
            _subscriptionName = _config.GetValue<string>("SubscriptionName");

            //service bus client
            var client = new ServiceBusClient(_serviceBusConnectionString);
            _checkoutProcessor = client.CreateProcessor(_topicName, _subscriptionName);

        }

        public async Task Start()
        {
            _checkoutProcessor.ProcessMessageAsync += OnCheckOutMessageReceived;
            _checkoutProcessor.ProcessErrorAsync += ErrorHandler;
            await _checkoutProcessor.StartProcessingAsync();
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        public async Task Stop()
        {
            await _checkoutProcessor.StartProcessingAsync();
            await _checkoutProcessor.DisposeAsync();
        }


        private async Task OnCheckOutMessageReceived(ProcessMessageEventArgs args)
        {
            
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            AccountDTO account = JsonConvert.DeserializeObject<AccountDTO>(body);

            //push the retrieved message to the DB
            UserModel userModel = new()
            {
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                EmailAddress = account.EmailAddress
            };

            _userData.AddUser(userModel);
        }
    }
}
