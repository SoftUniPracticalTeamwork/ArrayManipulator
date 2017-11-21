namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults;
    using ArrayManipulator.Commands.CommandResults.Interfaces;

    public class ReverseCommand : ArrayCommand
    {
        public ReverseCommand(string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            Array.Reverse(arrayToManipulate);
            
            return new ArrayCommandResult(arrayToManipulate);
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
            return new ValidationResult(isValid: true);
        }
    }
}
