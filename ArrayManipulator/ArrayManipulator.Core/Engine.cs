namespace ArrayManipulator.Core
{
    using System;
    using System.Text;
    using ArrayManipulator.CommandInterpreter.Exceptions;
    using ArrayManipulator.CommandInterpreter.Interfaces;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Core.Interfaces;
    using ArrayManipulator.IO.Interfaces;
    using ArrayManipulator.Utils;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IArrayCommandInterpreter commandInterpreter;
        private IDataParser dataParser;

        public Engine(IReader reader,
                      IWriter writer,
                      IArrayCommandInterpreter commandInterpreter,
                      IDataParser dataParser)
        {
            this.Reader = reader;
            this.Writer = writer;

            this.CommandInterpreter = commandInterpreter;
            this.DataParser = dataParser;
        }

        private IReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                Validator.CheckNull(value,
                                    nameof(this.Reader),
                                    BasicExceptionMessages.NullObject);

                this.reader = value;
            }
        }

        private IWriter Writer
        {
            get
            {
                return this.writer;
            }

            set
            {
                Validator.CheckNull(value,
                                    nameof(this.writer),
                                    BasicExceptionMessages.NullObject);

                this.writer = value;
            }
        }

        private IArrayCommandInterpreter CommandInterpreter
        {
            get
            {
                return this.commandInterpreter;
            }

            set
            {
                Validator.CheckNull(value,
                                    nameof(this.CommandInterpreter),
                                    BasicExceptionMessages.NullObject);

                this.commandInterpreter = value;
            }
        }

        private IDataParser DataParser
        {
            get
            {
                return this.dataParser;
            }

            set
            {
                Validator.CheckNull(value,
                                    nameof(this.DataParser),
                                    BasicExceptionMessages.NullObject);

                this.dataParser = value;
            }
        }
        
        public void Run()
        {
            StringBuilder gatheredOutput = new StringBuilder();
            string readString = this.Reader.Read();
            string[] arrayToManipulate = this.DataParser.ParseStartingArray(readString);
            while (true)
            {
                readString = this.Reader.Read();
                this.DataParser.ParseString(readString);
                string commandName = this.DataParser.CommandName;
                string[] commandArgs = this.DataParser.CommandArgs;

                IArrayCommandResult arrayCommandResult = this.InterpredCommand(arrayToManipulate, commandName, commandArgs);
                arrayToManipulate = arrayCommandResult.ChangedArray;

                gatheredOutput.AppendLine(arrayCommandResult.Result);
            }
        }

        private IArrayCommandResult InterpredCommand(string[] arrayToManipulate, string commandName, string[] commandArgs)
        {
            IArrayCommandResult arrayCommandResult = default(IArrayCommandResult);
            string commandTextResult = string.Empty;
            try
            {
                arrayCommandResult =
                            this.CommandInterpreter.Interpred(commandName, commandArgs, arrayToManipulate);
            }
            catch (ConventionException ce)
            {
                arrayCommandResult.Result = ce.Message;
            }
            catch (FormatException fe)
            {
                arrayCommandResult.Result = fe.Message;
            }

            return arrayCommandResult;
        }
    }
}
