using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessagesEndpoints.Implementations;

public class DisplayEndpoint : IMessageEndpoint
{
    private readonly IDisplay _display;

    public DisplayEndpoint(IDisplay display)
    {
        _display = display ?? throw new ArgumentNullException(nameof(display));
    }

    public void SendMessage(Message message)
    {
        _display.ShowMessage(message);
    }
}