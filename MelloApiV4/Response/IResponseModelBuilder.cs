using System.Collections.Generic;

namespace MelloApiV4.Response
{
    public interface IResponseModelBuilder
    {
        IResponseModelBuilder Success();

        IResponseModelBuilder Failed();

        IResponseModelBuilder AddMessage(string message);

        IResponseModelBuilder AddMessages(IEnumerable<string> messages);

        IResponseModel Build();
    }
}