namespace ArrayManipulator.Commands.AssemblyInformation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ArrayManipulator.Commands.Constants;

    public static class CommandsContext
    {
        public static readonly Assembly ExecutingAssembly;
        public static readonly IEnumerable<Type> AllTypes;
        public static readonly IEnumerable<Type> CommandTypesFinalized;

        static CommandsContext()
        {
            ExecutingAssembly = Assembly.GetExecutingAssembly();
            AllTypes = ExecutingAssembly.GetTypes();
            CommandTypesFinalized = AllTypes.Where(t => t.Name.EndsWith(CommandConstants.CommandSuffix,
                                                        StringComparison.InvariantCultureIgnoreCase))
                                            .ToArray();
        }
    }
}
