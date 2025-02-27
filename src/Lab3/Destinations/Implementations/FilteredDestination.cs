using Itmo.ObjectOrientedProgramming.Lab3.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Implementations;

public class FilteredDestination : IDestination
{
    private readonly IDestination _innerRecipient;
    private readonly IFilter _filter;

    public FilteredDestination(IDestination innerRecipient, IFilter filter)
    {
        _innerRecipient = innerRecipient ?? throw new ArgumentNullException(nameof(innerRecipient));
        _filter = filter ?? throw new ArgumentNullException(nameof(filter));
    }

    public void GetMessage(Message message)
    {
        if (_filter.Filter(message))
        {
            _innerRecipient.GetMessage(message);
        }
    }
}