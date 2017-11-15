namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;

    public class EndCommand : ArrayCommand
    {
        public EndCommand(string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
        }

        protected override void ValidateCommandParamaters()
        {
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            Environment.Exit(0);

            return null;
        }
    }
}
