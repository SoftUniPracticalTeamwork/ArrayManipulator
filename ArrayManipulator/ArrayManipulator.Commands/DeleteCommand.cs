namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults;
    using ArrayManipulator.Commands.CommandResults.Interfaces;
    using ArrayManipulator.Utils;

    public class DeleteCommand : ArrayCommand
    {
        private int specifiedIndex;

        public  DeleteCommand(int specifiedIndex, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.specifiedIndex = specifiedIndex;
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {  
            string[] array = new string[arrayToManipulate.Length - 1];

            int count = 0;
            for (int i = 0; i < arrayToManipulate.Length; i++)
            {
                if (i != this.specifiedIndex)
                {
                    array[count] = arrayToManipulate[i];
                    count++;
                }
            }
            
            return new ArrayCommandResult(array);
        }

        protected override IValidationResult ValidateCommandParamaters()
        {
           (bool isValid, Exception exception) validationResult = Validator.ValidateIndexIsInRangeOfArray(
                                                                        this.specifiedIndex,
                                                                        this.ArrayToManipulate,
                                                                        throwException: false);

            return new ValidationResult(validationResult.isValid, validationResult.exception);
        }
    }
}
