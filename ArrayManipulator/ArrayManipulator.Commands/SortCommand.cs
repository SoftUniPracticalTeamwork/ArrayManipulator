namespace ArrayManipulator.Commands
{
using ArrayManipulator.Commands.CommandResult.Interfaces;

    public class SortCommand : ArrayCommand
    {
        public SortCommand(string[] arrayToManipulate) : base(arrayToManipulate)
        { }

        protected override void ValidateCommandParamaters()
        {           
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {

            for(int i = 1; i < arrayToManipulate.Length;)
            {
                string currentWord = arrayToManipulate[i];
                string previousWord = arrayToManipulate[i - 1];

                if (currentWord[0] >= previousWord[0])
                {
                    i++;
                }
                else
                {
                    string tempValue = previousWord;

                    arrayToManipulate[i - 1] = currentWord;
                    arrayToManipulate[i] = tempValue;

                    i--;

                    if(i == 0)
                    {
                        i = 1;
                    }
                }
            }

            string sortedText = string.Join(" ", arrayToManipulate);

            return new ArrayCommandResult(sortedText, arrayToManipulate);
        }
    }
}
