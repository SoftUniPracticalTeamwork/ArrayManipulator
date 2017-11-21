namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults;
    using ArrayManipulator.Commands.CommandResults.Interfaces;
    using ArrayManipulator.Commands.Interfaces;

    public class SortCommand : ArrayCommand
    {
        public SortCommand(string[] arrayToManipulate)
            : base(arrayToManipulate)
        {
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
            return new ValidationResult(isValid: true);
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            Array.Sort(arrayToManipulate);
            
            return new ArrayCommandResult(arrayToManipulate);
        }
    }
}
