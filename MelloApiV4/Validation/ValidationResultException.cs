using System;
using FluentValidation.Results;


namespace MelloApiV4.Validation
{
    public class ValidationResultException : Exception
    {
        private readonly ValidationResult _result;

        public ValidationResultException(ValidationResult result)
        {
            _result = result;
        }

        public ValidationResult GetValidationResult()
        {
            return _result;
        }
    }
}
