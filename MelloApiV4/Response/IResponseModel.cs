using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MelloApiV4.Response
{
    public interface IResponseModel
    {
        bool Success { get; set; }
        IList<string> Messages { get; set; }
        HttpStatusCode StatusCode { get; set; }
    }
}
