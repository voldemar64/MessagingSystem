using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessagesEndpoints.Implementations;

public class Messenger : IMessenger
{
    public void OutputMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        Console.WriteLine("Message in messenger:");
        Console.WriteLine($"ID: {message.Id}");
        Console.WriteLine($"Title: {message.Title}");
        Console.WriteLine($"Body: {message.Body}");
        Console.WriteLine($"Severity level: {message.SeverityLevel}");
    }
}