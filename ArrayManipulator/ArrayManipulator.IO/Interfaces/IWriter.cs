namespace ArrayManipulator.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string textToWrite, params object[] args);

        void WriteLine(string textToWrite, params object[] args);
    }
}
