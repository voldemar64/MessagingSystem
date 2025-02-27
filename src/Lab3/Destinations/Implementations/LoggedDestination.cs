using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Implementations;

public class LoggedDestination : IDestination
{
    private readonly IDestination _innerRecipient;
    private readonly ILogger _logger;

    public LoggedDestination(IDestination innerRecipient, ILogger logger)
    {
        _innerRecipient = innerRecipient ?? throw new ArgumentNullException(nameof(innerRecipient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void GetMessage(Message message)
    {
        _logger.Log($"Message with ID: {message.Id} and severity level: {message.SeverityLevel} delivered to destination");
        _innerRecipient.GetMessage(message);
    }
}