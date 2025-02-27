using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MessagesEndpoints;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Implementations;

public class MessengerDestination : IDestination
{
    private readonly IMessenger _messenger;

    public MessengerDestination(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void GetMessage(Message message)
    {
        _messenger.OutputMessage(message);
    }
}