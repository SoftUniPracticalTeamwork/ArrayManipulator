﻿namespace ArrayManipulator.Commands
{

    using System;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Utils;
    using System.Linq;
    using System.Collections.Generic;

    public class InsertCommand : ArrayCommand
    {
        private int recivedIndex;
        private string recivedString;


        public InsertCommand(int recivedIndex, string recivedString, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.recivedIndex = recivedIndex;
            this.recivedString = recivedString;
        }

        protected override void ValidateCommandParamaters()
        {
            if (this.recivedIndex < 0)
            {
                throw new System.Exception();
            }

            Validator.CheckStringEmptyNullOrWhiteSpace(this.recivedString,
                                                       nameof(this.recivedString),
                                                       "Message from the static class");
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
