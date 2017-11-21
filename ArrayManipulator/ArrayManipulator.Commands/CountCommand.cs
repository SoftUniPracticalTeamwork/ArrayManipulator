namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults;
    using ArrayManipulator.Commands.CommandResults.Interfaces;
    using ArrayManipulator.Commands.Constants;
    using ArrayManipulator.Utils;

    class CountCommand : ArrayCommand
    {
        private string receivedString;

        public CountCommand(string recivedString, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.receivedString = recivedString;
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
            (bool isValid, Exception exception) validation = Validator.ValidateStringIsNullEmptyOrWhitespace(
                                                                        this.receivedString,
                                                                        nameof(this.receivedString),
                                                                        CommandConstants.InvalidParametersMessage,
                                                                        throwException: false);


            return new ValidationResult(validation.isValid, validation.exception);
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            int numberOfMatches = 0;

            foreach (var word in arrayToManipulate)
            {
                if (word == this.receivedString)
                {
                    numberOfMatches++;
                }
            }

            string numberOfMatchesAsMsg = numberOfMatches.ToString();
            return new ArrayCommandResult(numberOfMatchesAsMsg, arrayToManipulate);
        }      
    }
}
