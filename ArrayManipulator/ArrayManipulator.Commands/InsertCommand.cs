namespace ArrayManipulator.Commands
{
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Utils;
    using ArrayManipulator.Commands.Constants;
    using System;
    using ArrayManipulator.Commands.CommandResults.Interfaces;
    using ArrayManipulator.Commands.CommandResults;

    public class InsertCommand : ArrayCommand
    {
        private int receivedIndex;
        private string recivedString;

        public InsertCommand(int recivedIndex, string recivedString, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.receivedIndex = recivedIndex;
            this.recivedString = recivedString;
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
            (bool isVaild, Exception exception) indexIsValid = Validator.ValidateIndexIsInRangeOfArray(
                                                                            this.receivedIndex, 
                                                                            this.ArrayToManipulate,
                                                                            throwException: false);

            (bool isVaild, Exception exception) stringIsValid = Validator.ValidateStringIsNullEmptyOrWhitespace(
                                                                               this.recivedString,
                                                                               nameof(this.recivedString),
                                                                               CommandConstants.InvalidParametersMessage,
                                                                               throwException: false);

            return new ValidationResult(indexIsValid.isVaild && stringIsValid.isVaild,
                                        indexIsValid.exception, stringIsValid.exception);
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            int size = arrayToManipulate.Length + 1;

            string[] newArray = new string[size];

            int valuesToInserCounter = 0;

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i == this.receivedIndex)
                {
                    newArray[i] = this.recivedString;

                    valuesToInserCounter++;
                }
                else
                {
                    newArray[i] = arrayToManipulate[i - valuesToInserCounter];
                }
            }
            
            return new ArrayCommandResult(newArray);
        }     
    }
}
