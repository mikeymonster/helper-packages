using System;
using System.Linq.Expressions;
using System.Windows.Input;

// ReSharper disable UnusedMember.Global
namespace Wild.Helpers.TestHelpers.Extensions
{
    public static class NotifyCommandCanExecuteChangedTestExtensions
    {
        public static CommandCanExecuteChangedExpectation<T> ShouldRaiseCanExecuteChangedOn<T, TCommand>(
            this T owner, Expression<Func<T, TCommand>> commandPicker)
            where T : class
            where TCommand : ICommand
        {
            return CreateExpectation(owner, commandPicker, true);
        }

        public static CommandCanExecuteChangedExpectation<T> ShouldNotNotifyOn<T, TCommand>(
            this T owner, Expression<Func<T, TCommand>> commandPicker)
            where T : class
            where TCommand : ICommand
        {
            return CreateExpectation(owner, commandPicker, false);
        }

        private static CommandCanExecuteChangedExpectation<T> CreateExpectation<T, TCommand>(
            T owner, Expression<Func<T, TCommand>> pickCommand,
            bool eventExpected) where T : class //INotifyPropertyChanged
            where TCommand : ICommand
        {

            var memberInfo = ((MemberExpression)pickCommand.Body).Member;
            var command = memberInfo.GetValue<ICommand>(owner);
            var commandName = memberInfo.Name;

            return new CommandCanExecuteChangedExpectation<T>(owner, commandName, command, eventExpected);
        }
    }
}
