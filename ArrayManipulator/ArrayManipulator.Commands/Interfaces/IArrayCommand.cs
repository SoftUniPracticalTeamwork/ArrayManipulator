namespace ArrayManipulator.Commands.Interfaces
{
    using ArrayManipulator.Commands.CommandResult.Interfaces;
    
    public interface IArrayCommand
    {
        IArrayCommandResult Execute();
    }
}
