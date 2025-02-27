using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Implementations;

public class UserDestination : IDestination
{
    private readonly User _user;

    public UserDestination(User user)
    {
        _user = user ?? throw new ArgumentNullException(nameof(user));
    }

    public void GetMessage(Message message)
    {
        _user.GetMessage(message);
    }
}