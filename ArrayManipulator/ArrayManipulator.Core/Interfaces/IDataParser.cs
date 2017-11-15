namespace ArrayManipulator.Core.Interfaces
{
    public interface IDataParser
    {
        string CommandName { get; }

        string[] CommandArgs { get; }

        void ParseString(string stringToParse);

        string[] ParseStartingArray(string stringToParse);
    }
}
