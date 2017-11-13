namespace ArrayManipulator.Commands.CommandResult.Interfaces
{
    public interface IArrayCommandResult
    {
        string Result { get; }

        string[] ChangedArray { get; }
    }
}
