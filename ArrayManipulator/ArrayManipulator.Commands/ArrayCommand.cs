namespace ArrayManipulator.Commands
{
    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.CommandResults.Interfaces;
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

        protected string[] ArrayToManipulate
        {
            get
            {
                return this.arrayToManipulate;
            }

            private set
            {
                Validator.CheckNull(value, 
                                    nameof(this.ArrayToManipulate), 
                                    BasicExceptionMessages.NullArray);

                this.arrayToManipulate = value;
            }
        }

        protected abstract IValidationResult ValidateCommandParamaters();

        protected abstract IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate);

        public IArrayCommandResult Execute()
        {
            IValidationResult validationResult = this.ValidateCommandParamaters();
            if (!validationResult.IsValid)
            {
                throw new AggregateException(validationResult.Exception);
            }

            IArrayCommandResult manipulationResult = this.ManipulateTheArray(this.arrayToManipulate);

            return manipulationResult;
        }
    }       
}
