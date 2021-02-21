using System.Collections.Generic;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace MelloApiV4.Validation
{
    public abstract class BaseValidator<T> : AbstractValidator<T>, IValidatorInterceptor
    {
/*        public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
        {
            return validationContext;
        }

        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                throw new ValidationResultException(result);
            }

            return result;
        }*/

        public IValidationContext BeforeMvcValidation(ControllerContext controllerContext, IValidationContext commonContext)
        {
            return commonContext;
        }

        public FluentValidation.Results.ValidationResult AfterMvcValidation(ControllerContext controllerContext, IValidationContext commonContext, FluentValidation.Results.ValidationResult result)
        {
            if (!result.IsValid)
            {
                throw new ValidationResultException(result);
            }

            return result;
        }

        public class Factory
        {
            public static FluentValidation.Results.ValidationResult CreateNonPropertyValidationResult(string message)
            {
                return
                    new FluentValidation.Results.ValidationResult(
                        new List<ValidationFailure>
                        {
                            new ValidationFailure("NonPropertyFailure", message)
                        });
            }
        }
    }
}
