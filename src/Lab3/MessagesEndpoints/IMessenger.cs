using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessagesEndpoints;

public interface IMessenger
{
    void OutputMessage(Message message);
}