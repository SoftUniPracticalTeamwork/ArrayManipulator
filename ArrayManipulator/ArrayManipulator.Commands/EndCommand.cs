namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults;
    using ArrayManipulator.Commands.CommandResults.Interfaces;

    public class EndCommand : ArrayCommand
    {
        public EndCommand(string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
            return new ValidationResult(isValid: true);
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            Environment.Exit(0);

            return null;
        }
    }
}
