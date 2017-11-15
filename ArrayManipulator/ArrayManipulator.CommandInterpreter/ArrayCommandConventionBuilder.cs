namespace ArrayManipulator.CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ArrayManipulator.CommandInterpreter.Constants;
    using ArrayManipulator.CommandInterpreter.Exceptions;
    using ArrayManipulator.CommandInterpreter.Interfaces;
    using ArrayManipulator.Commands.ExceptionMessagesProviders;
    using ArrayManipulator.Utils;

    public class ArrayCommandConventionBuilder : IArrayCommandConventionBuilder
    {
        private string commandSuffix;
        private Type lastCtorType;

        public ArrayCommandConventionBuilder(string commandNameSufifx, Type lastCtorType)
        {
            this.CommandSuffix = commandNameSufifx;
            this.LastCtorType = lastCtorType;
        }

        private string CommandSuffix
        {
            get
            {
                return this.commandSuffix;
            }

            set
            {
                Validator.CheckStringEmptyNullOrWhiteSpace(value,
                                                           nameof(this.CommandSuffix),
                                                           BasicExceptionMessages.StringIsNullEmptyOrWhiteSpace);

                this.commandSuffix = value;
            }
        }

        private Type LastCtorType
        {
            get
            {
                return this.lastCtorType;
            }

            set
            {
                Validator.CheckNull(value,
                                    nameof(this.LastCtorType),
                                    BasicExceptionMessages.NullObject);

                this.lastCtorType = value;
            }
        }

        private string BuildName(string unresolvedCommandName)
        {
            string constructedName = unresolvedCommandName;
            if (!unresolvedCommandName.EndsWith(this.CommandSuffix))
            {
                constructedName += this.CommandSuffix;
            }

            return constructedName;
        }

        public Func<IEnumerable<Type>, Type> BuildTypeFilter(string commandName)
        {
            string constructedName = this.BuildName(commandName);
            Func<IEnumerable<Type>, Type> filterToReturn = types =>
            {
                Type searchedType = types.SingleOrDefault(t => t.NameEquals(constructedName));

                Validator.CheckNull<Type, TypeConventionException>(searchedType, 
                                                                   ConventionBuilderExceptionMessages.TypeNotFoundByConvention);

                return searchedType;
            };

            return filterToReturn;
        }

        public Func<IEnumerable<ConstructorInfo>, ConstructorInfo> BuildConstructorFilter(int countOfArgsToPass)
        {
            Func<IEnumerable<ConstructorInfo>, ConstructorInfo> filterToReturn = ctors =>
            {
                ConstructorInfo searchedCtor = ctors
                                            .FirstOrDefault(c => c.GetParameters().Last().ParameterType == this.LastCtorType);

                Validator.CheckNull<ConstructorInfo, ConstructorConventionException>(searchedCtor,
                                                                                     ConventionBuilderExceptionMessages.LastCtorTypeMissmatch);

                ParameterInfo[] ctorParams = searchedCtor.GetParameters();
                if (ctorParams.Length != countOfArgsToPass)
                {
                    throw new ConstructorConventionException(ConventionBuilderExceptionMessages.ParametersMissmatch);
                }

                return searchedCtor;
            };

            return filterToReturn;
        }
    }
}
