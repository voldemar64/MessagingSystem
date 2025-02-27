using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filters;

public class SeverityFilter : IFilter
{
    private readonly int _requiredSeverityLevel;

    public SeverityFilter(int requiredSeverityLevel)
    {
        _requiredSeverityLevel = requiredSeverityLevel;
    }

    public bool Filter(Message message)
    {
        return message.SeverityLevel >= _requiredSeverityLevel;
    }
}