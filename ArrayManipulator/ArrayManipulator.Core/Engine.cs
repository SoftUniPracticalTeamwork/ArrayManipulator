namespace ArrayManipulator.Core
{
    using System;
    using System.Linq;
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

        public Engine(IReader reader,
                      IWriter writer,
                      IArrayCommandInterpreter commandInterpreter)
        {
            this.Reader = reader;
            this.Writer = writer;

            this.CommandInterpreter = commandInterpreter;
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
        
        public void Run()
        {
            StringBuilder gatheredOutput = new StringBuilder();
            string[] arrayToManipulate = this.SplitString(this.Reader.Read());
            while (true)
            {
                string[] readArgs = this.SplitString(this.Reader.Read());
                string commandName = readArgs[0];
                string[] commandArgs = readArgs.Skip(1).ToArray();

                IArrayCommandResult arrayCommandResult = default(IArrayCommandResult);
                string commandTextResult = string.Empty;
                try
                {
                    arrayCommandResult =
                                this.CommandInterpreter.Interpred(commandName, commandArgs, arrayToManipulate);

                    commandTextResult = arrayCommandResult.Result;
                    arrayToManipulate = arrayCommandResult.ChangedArray;
                }
                catch (ConventionException ce)
                {
                    commandTextResult = ce.Message;
                }
                catch(FormatException fe)
                {
                    commandTextResult = fe.Message;
                }

                this.Writer.WriteLine(commandTextResult);
            }
        }

        private string[] SplitString(string toSplit)
        {
            return toSplit.Trim().Split();
        }
    }
}
