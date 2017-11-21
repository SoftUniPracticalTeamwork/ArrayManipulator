﻿namespace ArrayManipulator.Core
{
    using System;
    using System.Linq;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Core.Constants;
    using ArrayManipulator.Core.Interfaces;
    using ArrayManipulator.Utils;

    public class DataParser : IDataParser
    {
        private Func<string, string[]> parsingFunc;

        public DataParser(Func<string, string[]> parsingFunc)
        {
            this.ParsingFunc = parsingFunc;
        }

        private Func<string, string[]> ParsingFunc
        {
            get
            {
                return this.parsingFunc;
            }

            set
            {
                Validator.CheckNull(value,
                                    nameof(this.ParsingFunc),
                                    BasicExceptionMessages.NullObject);

                this.parsingFunc = value;
            }
        }

        public string CommandName { get; private set; }

        public string[] CommandArgs { get; private set; }

        public void ParseString(string stringToParse)
        {
            string[] splittedString = this.ParsingFunc(stringToParse);
            if (splittedString.Length < 1)
            {
                throw new ArgumentException(DataParserExceptionMessages.InvalidNumberOfArgumentsPassed);
            }

            this.CommandName = splittedString[0];
            this.CommandArgs = splittedString.Skip(1).ToArray();
        }

        public string[] ParseStartingArray(string stringToParse)
        {
            return this.ParsingFunc(stringToParse);
        }
    }
}
