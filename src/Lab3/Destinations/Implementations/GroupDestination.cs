using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Implementations;

public class GroupDestination : IDestination
{
    private readonly List<IDestination> _recipients;

    public IReadOnlyList<IDestination> Recipients => _recipients.AsReadOnly();

    public GroupDestination()
    {
        _recipients = new List<IDestination>();
    }

    public void AddDestination(IDestination destination)
    {
        _recipients.Add(destination ?? throw new ArgumentNullException(nameof(destination)));
    }

    public void GetMessage(Message message)
    {
        foreach (IDestination recipient in Recipients)
        {
            recipient.GetMessage(message);
        }
    }
}
