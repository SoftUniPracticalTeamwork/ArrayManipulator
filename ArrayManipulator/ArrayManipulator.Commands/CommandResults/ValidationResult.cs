namespace ArrayManipulator.Commands.CommandResults
{
    using System;
    using System.Linq;
    using ArrayManipulator.Commands.CommandResults.Interfaces;

    public class ValidationResult : IValidationResult
    {
        private bool isValid;
        private Exception[] exception;

        public ValidationResult(bool isValid)
            : this(isValid, default(Exception))
        {
        }

        public ValidationResult(bool isValid, params Exception[] exception)
        {
            this.IsValid = isValid;
            this.Exception = exception;
        }

        public bool IsValid
        {
            get
            {
                return this.isValid;
            }

            private set
            {
                this.isValid = value;
            }
        }

        public Exception[] Exception
        {
            get
            {
                return this.exception;
            }

            private set
            {
                this.exception = value.Where(e => e != null).ToArray();
            }
        }
    }
}
