
using MelloApiV4.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Response
{
    public class ExceptionResponseModelBuilder : ResponseModelBuilder,
        IExceptionResponseModelBuilder
    {
        private Exception _exception;

        public override IResponseModel Build()
        {
            var model = new ExceptionResponseModel
            {
                Success = SuccessValue,
                Messages = new List<string>(Messages),
                ErrorClass = GetErrorClass(),
                ErrorLineNumber = GetErrorLineNumber(),
                ExceptionType = GetExceptionType()
            };

            Messages.Clear();
            SuccessValue = false;
            _exception = null;

            return model;
        }

        private StackFrame GetFirstStackFrame()
        {
            if (_exception == null)
            {
                return null;
            }

            var stackTrace = new StackTrace(_exception, true);
            return stackTrace.GetFrame(0);
        }

        private string GetExceptionType()
        {
            return _exception?.GetType().FullName;
        }

        private string GetErrorClass()
        {
            var firstStackFrame = GetFirstStackFrame();
            return firstStackFrame?.GetMethod().ReflectedType?.FullName;
        }

        private int GetErrorLineNumber()
        {
            var firstStackFrame = GetFirstStackFrame();
            return firstStackFrame?.GetFileLineNumber() ?? 0;
        }

        public IExceptionResponseModelBuilder WithException(Exception exception)
        {
            _exception = exception;
            return this;
        }
    }
}