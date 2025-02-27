using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    private readonly List<IDestination> _destinations;

    public string Title { get; }

    public IReadOnlyCollection<IDestination> Destinations => _destinations.AsReadOnly();

    public Topic(string title)
    {
        ArgumentNullException.ThrowIfNull(title);

        Title = title;
        _destinations = new List<IDestination>();
    }

    public void AddDestination(IDestination destination)
    {
        _destinations.Add(destination);
    }

    public void SendMessage(Message message)
    {
        foreach (IDestination destination in Destinations)
        {
            destination.GetMessage(message);
        }
    }
}