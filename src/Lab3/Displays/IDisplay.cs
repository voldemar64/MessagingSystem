using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    void Clear();

    void ShowMessage(Message message);
}