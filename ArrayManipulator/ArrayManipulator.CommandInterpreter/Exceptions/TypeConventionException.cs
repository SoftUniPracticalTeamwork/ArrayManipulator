namespace ArrayManipulator.CommandInterpreter.Exceptions
{
    public class TypeConventionException : ConventionException
    {
        public TypeConventionException(string message, params object[] args) 
            : base(message, args)
        {
        }
    }
}
