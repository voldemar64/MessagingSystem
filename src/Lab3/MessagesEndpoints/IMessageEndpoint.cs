using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessagesEndpoints;

public interface IMessageEndpoint
{
    public void SendMessage(Message message);
}