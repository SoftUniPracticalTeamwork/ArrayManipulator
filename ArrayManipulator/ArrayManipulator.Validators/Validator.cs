namespace ArrayManipulator.Utils
{
    using System;
    
    public static class Validator
    {
        private const string DefaultOutOfArrayFormatMessage = "Error: invalid index {0}";

        public static void CheckNull<T>(T valueToCheck, string parameterName, string exceptionMessage)
                            where T : class
        {
            if (valueToCheck == default(T))
            {
                throw new ArgumentNullException(parameterName, exceptionMessage);
            }
        }

        public static void CheckNull<TValue, TException>(TValue valueToCheck, string exceptionMessage)
                            where TValue : class
                            where TException : Exception
        {
            if (valueToCheck == default(TValue))
            {
                TException exception = (TException)Activator.CreateInstance(typeof(TException), exceptionMessage);
                throw exception;
            }
        }

        public static (bool, Exception) ValidateStringIsNullEmptyOrWhitespace(string stringToCheck, string parameterName, string exceptionMessage, bool throwException = true)
        {
            bool isValid = true;
            ArgumentException argumentException = default(ArgumentException);
            if (string.IsNullOrEmpty(stringToCheck) ||
                string.IsNullOrWhiteSpace(stringToCheck))
            {
                isValid = false;
                argumentException = new ArgumentException(exceptionMessage, parameterName);
                if (throwException)
                {
                    throw argumentException;
                }
            }

            return (isValid, argumentException);
        }

        public static (bool, Exception) ValidateIndexIsInRangeOfArray<T>(int indexToCheck, T[] array, bool throwException = true)
        {
            bool isValid = true;
            ArgumentOutOfRangeException argumentOutOfRangeException = default(ArgumentOutOfRangeException);
            if (indexToCheck < 0 || indexToCheck >= array.Length)
            {
                isValid = false;

                string message = string.Format(DefaultOutOfArrayFormatMessage, indexToCheck);
                argumentOutOfRangeException = new ArgumentOutOfRangeException(message);
                if (throwException)
                {
                    throw argumentOutOfRangeException;
                }
            }

            return (isValid, argumentOutOfRangeException);
        }
    }
}
