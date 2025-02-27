using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public IDisplay Display { get; }

    private ITextModifier? _modifier;

    public ConsoleDisplayDriver(IDisplay display)
    {
        Display = display;
    }

    public void SetModifier(ITextModifier modifier)
    {
        _modifier = modifier;
    }

    public void Clear()
    {
        Display.Clear();
    }

    public void WriteMessage(Message message)
    {
        Clear();

        if (_modifier is not null)
        {
            message.AddModifier(_modifier);
        }

        string coloredText = message.Render();
        Console.WriteLine(coloredText);
    }
}
