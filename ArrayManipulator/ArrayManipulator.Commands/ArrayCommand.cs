namespace ArrayManipulator.Commands
{
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Commands.Interfaces;
    using ArrayManipulator.Utils;

    public abstract class ArrayCommand : IArrayCommand
    {
        private string[] arrayToManipulate;

        protected ArrayCommand(string[] arrayToManipulate)
        {
            this.ArrayToManipulate = arrayToManipulate;
        }

        private string[] ArrayToManipulate
        {
            get
            {
                return this.arrayToManipulate;
            }

            set
            {
                Validator.CheckNull(value, 
                                    nameof(this.ArrayToManipulate), 
                                    BasicExceptionMessages.NullArray);

                this.arrayToManipulate = value;
            }
        }

        protected abstract void ValidateCommandParamaters();

        protected abstract IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate);

        public IArrayCommandResult Execute()
        {
            this.ValidateCommandParamaters();

            IArrayCommandResult manipulationResult = this.ManipulateTheArray(this.arrayToManipulate);

            return manipulationResult;
        }
    }
}
