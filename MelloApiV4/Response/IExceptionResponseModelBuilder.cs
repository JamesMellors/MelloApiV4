using System;

namespace MelloApiV4.Response
{
    public interface IExceptionResponseModelBuilder : IResponseModelBuilder
    {
        IExceptionResponseModelBuilder WithException(Exception exception);
    }
}