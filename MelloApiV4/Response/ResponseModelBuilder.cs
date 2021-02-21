using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Response
{
    public abstract class ResponseModelBuilder : IResponseModelBuilder
    {
        protected bool SuccessValue;
        protected readonly List<string> Messages = new List<string>();
        public IResponseModelBuilder Success()
        {
            SuccessValue = true;
            return this;
        }

        public IResponseModelBuilder Failed()
        {
            SuccessValue = false;
            return this;
        }

        public IResponseModelBuilder AddMessage(string message)
        {
            Messages.Add(message);
            return this;
        }

        public IResponseModelBuilder AddMessages(IEnumerable<string> messages)
        {
            Messages.AddRange(messages);
            return this;
        }

        public abstract IResponseModel Build();
    }
}
