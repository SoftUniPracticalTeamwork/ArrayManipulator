namespace ArrayManipulator.CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using ArrayManipulator.CommandInterpreter.Interfaces;
    using ArrayManipulator.Commands.AssemblyInformation;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Commands.Interfaces;
    using ArrayManipulator.CommandInterpreter.Constants;
    using ArrayManipulator.Utils;
    using ArrayManipulator.CommandInterpreter.Exceptions;

    public class ArrayCommandInterpreter : IArrayCommandInterpreter
    {
        private IArrayCommandConventionBuilder conventionBuilder;

        public ArrayCommandInterpreter(IArrayCommandConventionBuilder conventionBuilder)
        {
            this.ConventionBuilder = conventionBuilder;
        }

        private IArrayCommandConventionBuilder ConventionBuilder
        {
            get
            {
                return this.conventionBuilder;
            }

            set
            {
                Validator.CheckNull(value,
                                    nameof(this.ConventionBuilder),
                                    BasicExceptionMessages.NullObject);

                this.conventionBuilder = value;
            }
        }

        public IArrayCommandResult Interpred(string commandName, string[] args, string[] arrayToManipulate)
        {
            Type commandType = this.GetCommandTypeByConvention(commandName);

            int countOfArgsToPass = args.Length + 1;
            ConstructorInfo commandCtor = this.GetCommandCtorByConvention(commandType, countOfArgsToPass);

            ParameterInfo[] ctorParameters = commandCtor.GetParameters();

            object[] parsedParams = default(object[]);
            try
            {
                parsedParams = this.ParseCommandCtorParameters(args, arrayToManipulate, ctorParameters);
            }
            catch (FormatException)
            {
                throw new ConstructorArgsConventionException(ConventionBuilderExceptionMessages.ParametersMissmatch);
            }

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
        
        private ConstructorInfo GetCommandCtorByConvention(Type commandType, int countOfArgsToPass)
        {
            Func<IEnumerable<ConstructorInfo>, ConstructorInfo> ctorFinderByConvention =
                                                    this.ConventionBuilder.BuildConstructorFilter(countOfArgsToPass);

            return ctorFinderByConvention(commandType.GetConstructors());
        }

        private Type GetCommandTypeByConvention(string commandName)
        {
            Func<IEnumerable<Type>, Type> typeFinderByConvention =
                                        this.ConventionBuilder.BuildTypeFilter(commandName);

            return typeFinderByConvention(CommandsContext.CommandTypesFinalized);
        }
    }
}
