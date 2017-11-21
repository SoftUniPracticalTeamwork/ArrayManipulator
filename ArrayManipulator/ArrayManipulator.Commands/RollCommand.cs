namespace ArrayManipulator.Commands
{
    using System;
    using System.Linq;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults;
    using ArrayManipulator.Commands.CommandResults.Interfaces;
    using ArrayManipulator.Commands.Constants;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Utils;

    public class RollCommand : ArrayCommand
    {
        private const string LeftDirection = "left";
        private const string RightDirection = "right";

        private string direction;

        public RollCommand(string direction, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.direction = direction;
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            string[] arr = default(string[]);
            if (this.direction == LeftDirection)
            {
                arr = arrayToManipulate.Skip(1).Concat(arrayToManipulate.Take(1)).ToArray();
            }
            else if (this.direction == RightDirection)
            {
                arr = arrayToManipulate.TakeLast(1).Concat(arrayToManipulate.SkipLast(1)).ToArray();
            }

            return new ArrayCommandResult(arr);
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
            (bool isValid, Exception exception) stringDirectionIsValid = Validator.ValidateStringIsNullEmptyOrWhitespace(
                                                                                this.direction,
                                                                                nameof(this.direction),
                                                                                BasicExceptionMessages.StringIsNullEmptyOrWhiteSpace,
                                                                                throwException: false);

            bool directionIsValid = false;
            ArgumentException argumentException = default(ArgumentException);
            if (this.direction == LeftDirection || 
                this.direction == RightDirection)
            {
                directionIsValid = true;
                argumentException = new ArgumentException(CommandConstants.InvalidParametersMessage);
            }

            return new ValidationResult(stringDirectionIsValid.isValid && directionIsValid, 
                                        stringDirectionIsValid.exception, argumentException); 
        }
    }
}
