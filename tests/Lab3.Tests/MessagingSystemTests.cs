using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Destinations.Implementations;
using Itmo.ObjectOrientedProgramming.Lab3.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MessagesEndpoints;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class MessagingSystemTests
{
    [Fact]
    public void Receive_Message_IsSavedAsUnread()
    {
        var user = new User("UserName");
        var userDestination = new UserDestination(user);
        var message = new Message("Title", "Body", 2);
        var topic = new Topic("TopicName");
        topic.AddDestination(userDestination);
        topic.SendMessage(message);

        Assert.Single(user.Messages);
        ReceivedMessage receivedMessage = user.Messages.First();
        Assert.False(receivedMessage.IsRead);
        Assert.Equal(message, receivedMessage.Message);
    }

    [Fact]
    public void MarkAsRead_MessageUnread_ShouldChangeStatusToRead()
    {
        var user = new User("UserName");
        var userDestination = new UserDestination(user);
        var message = new Message("Title", "Body", 2);
        userDestination.GetMessage(message);

        user.ReadMessage(message.Id);

        ReceivedMessage receivedMessage = user.Messages.First();
        Assert.True(receivedMessage.IsRead);
    }

    [Fact]
    public void MarkAsRead_MessageAlreadyRead_ShouldThrowException()
    {
        var user = new User("UserName");
        var userDestination = new UserDestination(user);
        var message = new Message("Title", "Body", 2);
        userDestination.GetMessage(message);
        user.ReadMessage(message.Id);

        InvalidOperationException exception =
            Assert.Throws<InvalidOperationException>(() => user.ReadMessage(message.Id));
        Assert.Equal("Message is already read", exception.Message);
    }

    [Fact]
    public void FilteredDestination_ShouldNotReceiveMessageBelowImportance()
    {
        var mockInnerDestination = new Mock<IDestination>();
        var filter = new SeverityFilter(5);
        var filteredDestination = new FilteredDestination(mockInnerDestination.Object, filter);
        var message = new Message("Title", "This is a low importance message.", 3);

        filteredDestination.GetMessage(message);

        mockInnerDestination.Verify(r => r.GetMessage(It.IsAny<Message>()), Times.Never);
    }

    [Fact]
    public void LoggedDestination_ShouldLog_WhenMessageIsReceived()
    {
        var mockInnerDestination = new Mock<IDestination>();
        var mockLogger = new Mock<ILogger>();
        var loggedDestination = new LoggedDestination(mockInnerDestination.Object, mockLogger.Object);
        var message = new Message("Title", "Body", 2);

        loggedDestination.GetMessage(message);

        mockInnerDestination.Verify(r => r.GetMessage(message), Times.Once);
    }

    [Fact]
    public void MessengerDestination_ShouldInvokeMessengerPrint()
    {
        var mockMessenger = new Mock<IMessenger>();
        var messengerDestination = new MessengerDestination(mockMessenger.Object);
        var message = new Message("AGHTUNG!!!", "System is BROKEN!!!", 5);

        messengerDestination.GetMessage(message);

        mockMessenger.Verify(
            m => m.OutputMessage(It.Is<Message>(msg =>
                msg.Id == message.Id &&
                msg.Title == message.Title &&
                msg.Body == message.Body &&
                msg.SeverityLevel == message.SeverityLevel)),
            Times.Once);
    }

    [Fact]
    public void Send_MessageWithLowImportance_UserReceivesOnce()
    {
        var user = new User("UserName");

        var userDestination1 = new UserDestination(user);
        var innerDestination2 = new UserDestination(user);
        var filter = new SeverityFilter(5);
        var filteredDestination2 = new FilteredDestination(innerDestination2, filter);

        var groupDestination = new GroupDestination();
        groupDestination.AddDestination(userDestination1);
        groupDestination.AddDestination(filteredDestination2);

        var message = new Message("Title", "Body", 3);

        groupDestination.GetMessage(message);

        Assert.Single(user.Messages);
        ReceivedMessage receivedMessage = user.Messages.First();
        Assert.Equal(message.Title, receivedMessage.Message.Title);
        Assert.Equal(message.Body, receivedMessage.Message.Body);
        Assert.Equal(message.SeverityLevel, receivedMessage.Message.SeverityLevel);
        Assert.False(receivedMessage.IsRead);
    }
}