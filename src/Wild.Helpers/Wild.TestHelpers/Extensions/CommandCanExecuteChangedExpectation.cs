using System;
using System.Windows.Input;
using FluentAssertions;

// ReSharper disable UnusedMember.Global
namespace Wild.TestHelpers.Extensions;

public class CommandCanExecuteChangedExpectation<T>
    where T : class
{
    private readonly T _owner;
    private readonly ICommand _command;
    private readonly string _commandName;
    private readonly bool _eventExpected;

    public CommandCanExecuteChangedExpectation(T owner,
        string commandName, ICommand command, bool eventExpected)
    {
        _owner = owner;
        _command = command;
        _commandName = commandName;
        _eventExpected = eventExpected;
    }

    public void When(Action<T> action)
    {
        var eventWasRaised = false;
        _command.CanExecuteChanged += (_, _) =>
        {
            eventWasRaised = true;
        };

        action(_owner);

        eventWasRaised
            .Should()
            .Be(_eventExpected, $"CanExecuteChanged on {_commandName}");
    }
}