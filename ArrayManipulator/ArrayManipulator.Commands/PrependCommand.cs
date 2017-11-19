namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
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
            string[] arrayToPrepend = stringToBePrepended.Split();
            string[] resultArray = GenerateResultArray(arrayToPrepend, arrayToManipulate);

            string message = string.Join(" ", resultArray);
            return new ArrayCommandResult(message, resultArray);
        }

        protected override void ValidateCommandParamaters()
        {
            Validator.CheckStringEmptyNullOrWhiteSpace(this.stringToBePrepended,
                                                      nameof(this.stringToBePrepended),
                                                      //"Message from the static class"
                                                      "Error: invalid command parameters");
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
