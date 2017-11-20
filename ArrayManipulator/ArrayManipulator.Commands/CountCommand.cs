﻿namespace ArrayManipulator.Commands
{
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Utils;

    class CountCommand : ArrayCommand
    {
        private string recivedString;

        public CountCommand(string recivedString, string[] arrayToManipulate) : base(arrayToManipulate)
        {
            this.recivedString = recivedString;
        }
        protected override void ValidateCommandParamaters()
        {
            Validator.CheckStringEmptyNullOrWhiteSpace(this.recivedString,
                                         nameof(this.recivedString),
                                         "Error: invalid command parameters");
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            int numberOfMatches = 0;

            foreach(var word in arrayToManipulate)
            {
                if(word == recivedString)
                {
                    numberOfMatches++;
                }
            }

            string numberOfMatchesAsMsg = numberOfMatches.ToString();

            return new ArrayCommandResult(numberOfMatchesAsMsg, arrayToManipulate);
        }      
    }
}
