namespace ArrayManipulator.CommandInterpreter.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public interface IArrayCommandConventionBuilder
    {
        Func<IEnumerable<ConstructorInfo>, ConstructorInfo> BuildConstructorFilter(int countOfArgsToPass);

        Func<IEnumerable<Type>, Type> BuildTypeFilter(string commandName);
    }
}
