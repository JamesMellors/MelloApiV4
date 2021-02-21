using MelloApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Validation
{
    public class ExceptionResponseModel : ResponseModel
    {
        public string ExceptionType { get; set; }
        public string ErrorClass { get; set; }
        public int ErrorLineNumber { get; set; }
    }
}
