namespace ArrayManipulator.IO
{
    using System;
    using ArrayManipulator.IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
