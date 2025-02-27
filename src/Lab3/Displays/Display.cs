using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    public void Clear()
    {
        Console.Clear();
    }

    public virtual void ShowMessage(Message message)
    {
        Clear();
        Console.WriteLine(message.Render());
    }
}