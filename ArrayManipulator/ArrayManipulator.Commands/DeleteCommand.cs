namespace ArrayManipulator.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArrayManipulator.Commands.CommandResult.Interfaces;

    public class DeleteCommand : ArrayCommand
    {
        int specifiedIndex;
        string[] arrToManipulate;
        public  DeleteCommand(int specifiedIndex, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.specifiedIndex = specifiedIndex;
            this.arrToManipulate = arrayToManipulate;
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {  
            string[] array = new string[arrayToManipulate.Length - 1];
            int count = 0;
            for (int i = 0; i < arrayToManipulate.Length; i++)
            {
                if (i != specifiedIndex)
                {
                    array[count] = arrayToManipulate[i];
                    count++;
                }
            }

            string message = string.Join(" ", array);
            return new ArrayCommandResult(message, array);
        }

        protected override void ValidateCommandParamaters()
        {
            if (this.specifiedIndex < 0 || this.specifiedIndex > this.arrToManipulate.Length)
            {
                throw new ArgumentException($"Error: invalid index {this.specifiedIndex}");
            }
        }
    }
}
