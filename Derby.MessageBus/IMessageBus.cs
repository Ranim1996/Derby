using System;
using System.Threading.Tasks;

namespace Derby.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}
