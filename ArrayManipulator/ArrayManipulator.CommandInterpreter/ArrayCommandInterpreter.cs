namespace ArrayManipulator.CommandInterpreter
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ArrayManipulator.CommandInterpreter.Constants;
    using ArrayManipulator.CommandInterpreter.Interfaces;
    using ArrayManipulator.Commands.AssemblyInformation;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Commands.Interfaces;
    using ArrayManipulator.Utils;

    public class ArrayCommandInterpreter : IArrayCommandInterpreter
    {
        private static readonly Type lastCtorConventionType = typeof(string[]);

        private ICommandNameConstructor commandNameConstructor;

        public ArrayCommandInterpreter(ICommandNameConstructor commandNameConstructor)
        {
            this.CommandNameConstructor = commandNameConstructor;
        }

        private ICommandNameConstructor CommandNameConstructor
        {
            get
            {
                return this.commandNameConstructor;
            }

            set
            {
                Validator.CheckNull(value,
                                    nameof(this.CommandNameConstructor),
                                    BasicExceptionMessages.NullObject);

                this.commandNameConstructor = value;
            }
        }

        public IArrayCommandResult Interpred(string commandName, string[] args, string[] arrayToManipulate)
        {
            string constructedCommandName = this.CommandNameConstructor.ConstructName(commandName);
            Type commandType = this.GetCommandTypeByConvention(commandName, constructedCommandName);

            ConstructorInfo commandCtor = this.GetCommandCtorByConvention(commandType);

            ParameterInfo[] ctorParameters = this.GetParametersByConvention(commandCtor, args);

            object[] parsedParams = this.ParseCommandCtorParameters(args, arrayToManipulate, ctorParameters);

            IArrayCommand arrayCommand = (IArrayCommand)Activator.CreateInstance(commandType, parsedParams);

            return arrayCommand.Execute();
        }

        private object[] ParseCommandCtorParameters(string[] args, string[] arrayToManipulate, ParameterInfo[] ctorParameters)
        {
            int countOfCtorParameters = ctorParameters.Length;
            object[] parsedParams = new object[countOfCtorParameters];

            int i = 0;
            for (; i < countOfCtorParameters - 1; i++)
            {
                Type currentParamType = ctorParameters[i].ParameterType;
                string argToConvert = args[i];

                parsedParams[i] = Convert.ChangeType(argToConvert, currentParamType);
            }

            Type lastCtorParamType = ctorParameters[i].ParameterType;
            parsedParams[i] = Convert.ChangeType(arrayToManipulate, lastCtorParamType);

            return parsedParams;
        }

        private ParameterInfo[] GetParametersByConvention(ConstructorInfo commandCtor, string[] args)
        {
            ParameterInfo[] ctorParameters = commandCtor.GetParameters();
            int countOfCtorParameters = ctorParameters.Length;

            if (countOfCtorParameters != args.Length + 1)
            {
                throw new ArgumentException(ExceptionMessages.ParameterCountMissmatch);
            }

            return ctorParameters;
        }

        private ConstructorInfo GetCommandCtorByConvention(Type commandType)
        {
            ConstructorInfo commandCtor = commandType.GetConstructors()
                                                     .FirstOrDefault(c => c.GetParameters().Last().ParameterType == lastCtorConventionType);

            Validator.CheckNull(commandCtor,
                                nameof(commandCtor),
                                BasicExceptionMessages.NullObject);

            return commandCtor;
        }

        private Type GetCommandTypeByConvention(string commandName, string constructedCommandName)
        {
            Type commandType = CommandsContext.CommandTypesFinalized
                                              .SingleOrDefault(t => t.NameEquals(constructedCommandName));

            Validator.CheckNull(commandName,
                                nameof(commandType),
                                BasicExceptionMessages.NullObject);

            return commandType;
        }
    }
}
