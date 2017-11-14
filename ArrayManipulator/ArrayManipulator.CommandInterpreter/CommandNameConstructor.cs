namespace ArrayManipulator.CommandInterpreter
{
    using ArrayManipulator.CommandInterpreter.Interfaces;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Utils;

    public class CommandNameConstructor : ICommandNameConstructor
    {
        private string commandSuffix;

        public CommandNameConstructor(string commandNameSufifx)
        {
            this.commandSuffix = commandNameSufifx;
        }

        private string CommandSuffix
        {
            get
            {
                return this.commandSuffix;
            }

            set
            {
                Validator.CheckStringEmptyNullOrWhiteSpace(value,
                                                           nameof(this.CommandSuffix),
                                                           BasicExceptionMessages.StringIsNullEmptyOrWhiteSpace);

                this.commandSuffix = value;
            }
        }

        public string ConstructName(string unresolvedCommandName)
        {
            string constructedName = unresolvedCommandName + this.CommandSuffix;

            return constructedName;
        }
    }
}
