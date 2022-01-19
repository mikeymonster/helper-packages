using System;
using AutoFixture.Idioms;

namespace Wild.TestHelpers.Extensions;

public class ArgumentBehaviorException : IBehaviorExpectation
{
    public void Verify(IGuardClauseCommand command)
    {
        try
        {
            command.Execute(null);
        }
        catch (ArgumentNullException)
        {
            return;
        }
        catch (ArgumentException)
        {
            return;
        }

        throw new GuardClauseException();
    }
}