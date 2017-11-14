namespace ArrayManipulator.CommandInterpreter.Interfaces
{
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    
    public interface IArrayCommandInterpreter
    {
        IArrayCommandResult Interpred(string commandName, string[] args, string[] arrayToManipulate);
    }
}
