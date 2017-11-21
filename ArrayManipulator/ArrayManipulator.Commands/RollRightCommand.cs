namespace ArrayManipulator.Commands
{
    using ArrayManipulator.Commands.CommandResult.Interfaces;

    class RollRightCommand : ArrayCommand
    {
        public RollRightCommand(string[] arrayToManipulate) 
            : base(arrayToManipulate)
        { }


        protected override void ValidateCommandParamaters()
        {
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            string[] rotatedArray = new string[arrayToManipulate.Length];

            string tempString = arrayToManipulate[arrayToManipulate.Length - 1];

            rotatedArray[0] = tempString;

            for(int i = 1; i < arrayToManipulate.Length; i++)
            {
                rotatedArray[i] = arrayToManipulate[i - 1];
            }

            string rotatedArrayAsText = string.Join(" ", rotatedArray);

            return new ArrayCommandResult(rotatedArrayAsText, rotatedArray);
        }
    }
}
