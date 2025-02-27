using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDrivers;

public interface IDisplayDriver
{
    void SetModifier(ITextModifier modifier);

    void WriteMessage(Message message);

    void Clear();
}