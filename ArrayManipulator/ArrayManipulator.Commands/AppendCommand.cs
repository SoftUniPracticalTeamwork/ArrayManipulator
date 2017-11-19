﻿namespace ArrayManipulator.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Utils;

    public class AppendCommand : ArrayCommand
    {
        private string stringToBeAppended;

        public  AppendCommand(string stringToBeAppended, string[] arrayToManipulate) 
            : base(arrayToManipulate)
        {
            this.stringToBeAppended = stringToBeAppended;
        }

        protected override IArrayCommandResult ManipulateTheArray(string[] arrayToManipulate)
        {
            string[] arrayToAppend = stringToBeAppended.Split();
            string[] resultArray = GenerateResultArray(arrayToAppend, arrayToManipulate);
            
            string message = string.Join(" ", resultArray);
            return new ArrayCommandResult(message, resultArray);
        }

        protected override void ValidateCommandParamaters()
        {
            Validator.CheckStringEmptyNullOrWhiteSpace(this.stringToBeAppended,
                                                      nameof(this.stringToBeAppended),
                                                      //"Message from the static class"
                                                      "Error: invalid command parameters");
        }

        private string[] GenerateResultArray (string[] arrayToAppend, string[] arrayToManipulate)
        {
            int size = arrayToAppend.Length + arrayToManipulate.Length;
            string[] result = new string[size];

            var count = 0;
            foreach (var substring in arrayToManipulate)
            {
                result[count] = substring;
                count++;
            }
            foreach (var substring in arrayToAppend)
            {
                result[count] = substring;
                count++;
            }

            return result;
        } 
    }
}
