using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Response
{
    public interface IValidationResponseModelBuilder : IResponseModelBuilder
    {
        IValidationResponseModelBuilder AddErrorCount(IEnumerable<string> messages);
    }

}
