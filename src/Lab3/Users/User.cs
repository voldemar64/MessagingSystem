using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    private readonly List<ReceivedMessage> _messages = new List<ReceivedMessage>();

    public Guid Id { get; }

    public string Name { get; }

    public IReadOnlyCollection<ReceivedMessage> Messages => _messages.AsReadOnly();

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public void GetMessage(Message message)
    {
        var receivedMessage = new ReceivedMessage(message);
        _messages.Add(receivedMessage);
    }

    public void ReadMessage(Guid id)
    {
        ReceivedMessage? message = _messages.FirstOrDefault(m => m.Id == id);

        if (message == null)
        {
            Console.WriteLine("No such message");
            return;
        }

        message.GetRead();
    }
}