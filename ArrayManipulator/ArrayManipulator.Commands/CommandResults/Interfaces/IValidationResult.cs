namespace ArrayManipulator.Commands.CommandResults.Interfaces
{
    using System;

    public interface IValidationResult
    {
        bool IsValid { get; }

        Exception[] Exception { get; }
    }
}
