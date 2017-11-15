namespace ArrayManipulator.CommandInterpreter.Exceptions
{
    public class ConstructorConventionException : ConventionException
    {
        public ConstructorConventionException(string message, params object[] args) 
            : base(message, args)
        {
        }
    }
}
