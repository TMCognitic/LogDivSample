using LogDivSample.Models;

namespace LogDivSample.Infrastructure
{
    public class LogMessenger
    {
        public event Action<Message>? NewMessageSended;

        public void Send(Message message)
        {
            Action<Message>? newMessageSended = NewMessageSended;
            newMessageSended?.Invoke(message);
        }
    }
}
