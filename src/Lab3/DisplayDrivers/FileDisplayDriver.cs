using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDrivers;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _filePath;

    public IDisplay Display { get; }

    private ITextModifier? _modifier;

    public FileDisplayDriver(string filePath, IDisplay display)
    {
        _filePath = filePath;
        Display = display;
    }

    public void SetModifier(ITextModifier modifier)
    {
        _modifier = modifier;
    }

    public void Clear()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void WriteMessage(Message message)
    {
        Clear();

        if (_modifier is not null)
        {
            message.AddModifier(_modifier);
        }

        string coloredText = message.Render();
        File.AppendAllText(_filePath, coloredText + Environment.NewLine);
    }
}