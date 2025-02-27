namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class ReceivedMessage
{
    public Guid Id { get; }

    public Message Message { get; }

    public bool IsRead { get; private set; }

    public ReceivedMessage(Message message)
    {
        Id = message.Id;
        Message = message;
        IsRead = false;
    }

    public void GetRead()
    {
        if (IsRead)
        {
            throw new InvalidOperationException("Message is already read");
        }

        IsRead = true;
    }
}