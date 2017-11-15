namespace ArrayManipulator.CommandInterpreter.Constants
{
    public static class ConventionBuilderExceptionMessages
    {
        public const string TypeNotFoundByConvention = "No type was found by convention";
        public const string ParameterCountMissmatch = "The provided parameters don't match the needed from the command constructor";
        public const string LastCtorTypeMissmatch = "The last type of the constructor doesn't match the one provided as conventional";
    }
}
