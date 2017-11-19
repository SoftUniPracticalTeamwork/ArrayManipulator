namespace ArrayManipulator.Commands
{
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Utils;

    /// <summary>
    /// The name of the command must start with the name of the command form the provided document.
    /// For example if the command is to append (•	append <string>) the class name must be AppendCommand
    /// As you may notice the command also must end with Command to be discoverable from the command interpreter.
    /// Lastly the class should inherit from ArrayCommand class as in the example.
    /// </summary>
    public class SampleArrayCommand : ArrayCommand
    {
        /// <summary>
        /// Here you place all the needed parameters for the command
        /// For example if the command is to append (•	append <string>) here you must have a string field
        /// </summary>
        private string neededStringForCommand;
        private int neededIntForCommand;

        /// <summary>
        /// The needed parameters must be provided in the constructor so the CommandInterpreter can inject them.
        /// Also the parameters MUST be in the order described in the document and the ArrayToManopulate MUST always be the last parameter.
        /// </summary>
        public SampleArrayCommand(string neededStringForCommand, int neededIntForCommand, string[] arrayToManipulate)
            : base(arrayToManipulate)
        {
            this.neededStringForCommand = neededStringForCommand;
            this.neededIntForCommand = neededIntForCommand;
        }

        /// <summary>
        /// In this method you should validate all the data and the call of this method is done in the Base/Super class.
        /// The only thing you do in this method is to make sure all the passed parameters are valid and throw the appropriate exception.
        /// You dont have to call this method nowhere becuase as described above the call is done by the Base/Super class.
        /// You can use the static validator class from the ArrayManipulator.Validators assembly for more common validations such as null check.
        /// If you see that in many commands the same validation is repeated you can extract it in the Validator static class.
        /// There should be no "magic" strings and so on. If you use a string for an exception message or for result 
        /// please create a static class which holds the needed messages!!!
        /// </summary>
        protected override void ValidateCommandParamaters()
        {
            if (this.neededIntForCommand < 0)
            {
                throw new System.Exception();
            }

            Validator.CheckStringEmptyNullOrWhiteSpace(this.neededStringForCommand,
                                                       nameof(this.neededStringForCommand),
                                                       "Message from the static class");
        }

        /// <summary>
        /// Here you manipulate the array. 
        /// You must not manipulate the provided array directly but instead initialize a new one so you can work with it.
        /// You must return an ArrayCommandResult with the message of the Command and the NewArray that is ready.
        /// There should be no "magic" strings and so on. If you use a string for an exception message or for result 
        /// please create a static class which holds the needed messages!!!
        /// </summary>
        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            string[] newArray = new[] { "test","test2" };
            string message = "some message";

            return new ArrayCommandResult(message, newArray);
        }
    }
}
