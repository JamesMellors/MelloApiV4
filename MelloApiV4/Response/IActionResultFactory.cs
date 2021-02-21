using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Response
{
    public interface IActionResultFactory
    {
        IActionResult CreateResultFromResponseModel(IResponseModel response);
    }
}
