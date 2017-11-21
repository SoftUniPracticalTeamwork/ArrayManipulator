namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults;
    using ArrayManipulator.Commands.CommandResults.Interfaces;
    using ArrayManipulator.Commands.Constants;
    using ArrayManipulator.Utils;

    public class PrependCommand : ArrayCommand
    {
        private string stringToBePrepended;

        public  PrependCommand(string stringToBePrepended, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.stringToBePrepended = stringToBePrepended;
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            string[] arrayToPrepend = this.stringToBePrepended.Split();
            string[] resultArray = GenerateResultArray(arrayToPrepend, arrayToManipulate);
            
            return new ArrayCommandResult(resultArray);
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
           (bool isValid, Exception exception) isValid = Validator.ValidateStringIsNullEmptyOrWhitespace(
                                                      this.stringToBePrepended,
                                                      nameof(this.stringToBePrepended),
                                                      CommandConstants.InvalidParametersMessage,
                                                      throwException: false);

            return new ValidationResult(isValid.isValid, isValid.exception);
        }

        private string[] GenerateResultArray(string[] arrayToPrepend, string[] arrayToManipulate)
        {
            int size = arrayToPrepend.Length + arrayToManipulate.Length;
            string[] result = new string[size];

            var count = 0;
            foreach (var substring in arrayToPrepend)
            {
                result[count] = substring;
                count++;
            }

            foreach (var substring in arrayToManipulate)
            {
                result[count] = substring;
                count++;
            }

            return result;
        }
    }
}
