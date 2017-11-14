namespace ArrayManipulator.IO
{
    using System;
    using ArrayManipulator.IO.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void Write(string textToWrite, params object[] args)
        {
            Console.Write(textToWrite, args);
        }

        public void WriteLine(string textToWrite, params object[] args)
        {
            Console.WriteLine(textToWrite, args);
        }
    }
}
