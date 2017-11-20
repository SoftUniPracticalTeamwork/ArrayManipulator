namespace ArrayManipulator.Commands
{
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Utils;
    using System;

    public class InsertCommand : ArrayCommand
    {
        private int recivedIndex;
        private string recivedString;
        private string[] arrToManipulate;

        public InsertCommand(int recivedIndex, string recivedString, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.recivedIndex = recivedIndex;
            this.recivedString = recivedString;
            this.arrToManipulate = arrayToManipulate;
        }

        protected override void ValidateCommandParamaters()
        {
            if (this.recivedIndex < 0 || this.recivedIndex > arrToManipulate.Length)
            {
                throw new ArgumentException($"Error: invalid index {this.recivedIndex}");
            }

            Validator.CheckStringEmptyNullOrWhiteSpace(this.recivedString,
                                                       nameof(this.recivedString),
                                                       BasicExceptionMessages.StringIsNullEmptyOrWhiteSpace);
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            int size = arrayToManipulate.Length + 1;

            string[] newArray = new string[size];

            int valuesToInserCounter = 0;

            for(int i = 0; i < newArray.Length; i++)
            {
                if (i == recivedIndex)
                {
                    newArray[i] = recivedString;

                    valuesToInserCounter++;
                }
                else
                {
                    newArray[i] = arrayToManipulate[i - valuesToInserCounter];
                }
            }

            string message = string.Join(" ", newArray);

            return new ArrayCommandResult(message, newArray);
        }     
    }
}
