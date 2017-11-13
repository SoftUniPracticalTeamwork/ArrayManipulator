namespace ArrayManipulator.Validators
{
    using System;
    
    public static class Validator
    {
        public static void CheckNull<T>(T valueToCheck, string parameterName, string exceptionMessage)
                            where T : class
        {
            if (valueToCheck == default(T))
            {
                throw new ArgumentNullException(parameterName, exceptionMessage);
            }
        }

        public static void CheckStringEmptyNullOrWhiteSpace(string stringToCheck, string parameterName, string exceptionMessage)
        {
            if (string.IsNullOrEmpty(stringToCheck) ||
                string.IsNullOrWhiteSpace(stringToCheck))
            {
                throw new ArgumentException(exceptionMessage, parameterName);
            }
        }
    }
}
