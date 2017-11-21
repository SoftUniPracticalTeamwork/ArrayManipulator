namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults;
    using ArrayManipulator.Commands.CommandResults.Interfaces;
    using ArrayManipulator.Commands.Constants;
    using ArrayManipulator.Utils;

    public class AppendCommand : ArrayCommand
    {
        private string stringToBeAppended;

        public  AppendCommand(string stringToBeAppended, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.stringToBeAppended = stringToBeAppended;
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            string[] arrayToAppend = this.stringToBeAppended.Split();
            string[] resultArray = GenerateResultArray(arrayToAppend, arrayToManipulate);
            
            return new ArrayCommandResult(resultArray);
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
            (bool isValid, Exception exception) validation = Validator.ValidateStringIsNullEmptyOrWhitespace(
                                                                        this.stringToBeAppended,
                                                                        nameof(this.stringToBeAppended),
                                                                        CommandConstants.InvalidParametersMessage,
                                                                        throwException: false);


            return new ValidationResult(validation.isValid, validation.exception);
        }

        private string[] GenerateResultArray (string[] arrayToAppend, string[] arrayToManipulate)
        {
            int size = arrayToAppend.Length + arrayToManipulate.Length;
            string[] result = new string[size];

            var count = 0;
            foreach (var substring in arrayToManipulate)
            {
                result[count] = substring;
                count++;
            }

            foreach (var substring in arrayToAppend)
            {
                result[count] = substring;
                count++;
            }

            return result;
        } 
    }
}
