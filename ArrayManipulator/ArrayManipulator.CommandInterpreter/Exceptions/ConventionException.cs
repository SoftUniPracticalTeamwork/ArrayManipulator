namespace ArrayManipulator.CommandInterpreter.Exceptions
{
    using System;

    public class ConventionException : Exception
    {
        public ConventionException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }
    }
}
