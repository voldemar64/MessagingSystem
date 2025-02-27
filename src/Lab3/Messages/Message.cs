using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    private readonly List<ITextModifier> _modifiers;

    public Guid Id { get; }

    public string Title { get; }

    public string Body { get; }

    public int SeverityLevel { get; }

    public Message(string title, string body, int severityLevel)
    {
        Id = Guid.NewGuid();
        Title = title;
        Body = body;
        SeverityLevel = severityLevel;
        _modifiers = [];
    }

    public Message AddModifier(ITextModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }

    public string Render()
    {
        return _modifiers.Aggregate(
            Body,
            (b, m) => m.Modify(b));
    }
}