namespace ArrayManipulator.Commands.CommandResult.Interfaces
{
    public interface IArrayCommandResult
    {
        string Result { get; set; }

        string[] ChangedArray { get; }
    }
}
