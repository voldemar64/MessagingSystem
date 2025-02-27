using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Implementations;

public class DisplayDestination : IDestination
{
    private readonly IDisplay _display;

    public DisplayDestination(IDisplay display)
    {
        _display = display;
    }

    public void GetMessage(Message message)
    {
        _display.ShowMessage(message);
    }
}