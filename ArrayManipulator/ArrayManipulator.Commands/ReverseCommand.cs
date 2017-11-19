namespace ArrayManipulator.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArrayManipulator.Commands.CommandResult.Interfaces;

    public class ReverseCommand : ArrayCommand
    {
        public ReverseCommand(string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            Array.Reverse(arrayToManipulate);
            string message = string.Join(" ", arrayToManipulate);
            return new ArrayCommandResult(message, arrayToManipulate);
        }

        protected override void ValidateCommandParamaters()
        {
        }
    }
}
