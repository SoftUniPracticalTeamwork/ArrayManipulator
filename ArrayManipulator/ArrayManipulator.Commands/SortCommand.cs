using System;
using System.Collections.Generic;
using System.Text;
using ArrayManipulator.Commands.CommandResult.Interfaces;

namespace ArrayManipulator.Commands
{
    public class SortCommand : ArrayCommand
    {
        public SortCommand(string[] arrayToManipulate) : base(arrayToManipulate)
        { }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateCommandParamaters()
        {
            throw new NotImplementedException();
        }
    }
}
