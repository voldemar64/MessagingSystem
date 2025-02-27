using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessagesEndpoints.Implementations;

public class UserEndpoint : IMessageEndpoint
{
    private readonly User _user;

    public UserEndpoint(User user)
    {
        _user = user;
    }

    public void SendMessage(Message message)
    {
        _user.GetMessage(message);
    }
}