namespace ArrayManipulator.Commands.CommandResult.Interfaces
{
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Utils;
    
    public class ArrayCommandResult : IArrayCommandResult
    {
        private string result;
        private string[] changedArray;

        public ArrayCommandResult(string result, string[] changedArray)
        {
            this.Result = result;
            this.ChangedArray = changedArray;
        }

        public string Result
        {
            get
            {
                return this.result;
            }

            set
            {
                Validator.CheckStringEmptyNullOrWhiteSpace(value,
                                                           nameof(this.Result),
                                                           BasicExceptionMessages.StringIsNullEmptyOrWhiteSpace);

                this.result = value;
            }
        }

        public string[] ChangedArray
        {
            get
            {
                return this.changedArray;
            }

            private set
            {
                Validator.CheckNull(value,
                                    nameof(this.ChangedArray),
                                    BasicExceptionMessages.NullArray);

                this.changedArray = value;
            }
        }
    }
}
