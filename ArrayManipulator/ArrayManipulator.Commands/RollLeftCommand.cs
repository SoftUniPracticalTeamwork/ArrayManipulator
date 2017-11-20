namespace ArrayManipulator.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArrayManipulator.Commands.CommandResult.Interfaces;

    public class RollLeftCommand : ArrayCommand
    {
        public RollLeftCommand(string[] arrayToManipulate)
            : base(arrayToManipulate)
        {
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            //easy way
            string[] arr = arrayToManipulate.Skip(1).Concat(arrayToManipulate.Take(1)).ToArray();
            
            string message = string.Join(" ", arr);
            return new ArrayCommandResult(message, arrayToManipulate);
        }

        protected override void ValidateCommandParamaters()
        {
        }
    }
}
