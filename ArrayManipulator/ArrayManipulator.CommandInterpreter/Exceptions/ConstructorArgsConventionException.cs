namespace ArrayManipulator.CommandInterpreter.Exceptions
{
    public class ConstructorArgsConventionException
        : ConventionException
    {
        public ConstructorArgsConventionException(string message, params object[] args) 
            : base(message, args)
        {
        }
    }
}
