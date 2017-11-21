namespace ArrayManipulator.IO
{
    using System;
    using ArrayManipulator.IO.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void Write(string textToWrite, params object[] args)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(textToWrite, args);

            Console.ForegroundColor = consoleColor;
        }

        public void WriteLine(string textToWrite, params object[] args)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(textToWrite, args);

            Console.ForegroundColor = consoleColor;
        }
    }
}
