
using MelloApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Validation
{
    public class ValidationResponseModel : ResponseModel
    {
        public int ErrorCount { get; set; }

        public ValidationResponseModel(bool success, IList<string> messages, int errorCount) : this()
        {
            Success = success;
            Messages = messages;
            ErrorCount = errorCount;
        }
        public ValidationResponseModel() { }
    }
}
