using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MelloApiV4.Response
{
    public class ActionResultFactory : Controller, IActionResultFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public IActionResult CreateResultFromResponseModel(IResponseModel response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Accepted:
                    return Accepted(response);
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.OK:
                    return Json(response);
                case HttpStatusCode.Created:
                    {
                        var url = ControllerContext?
                            .HttpContext?
                            .Request?
                            .GetDisplayUrl();

                        return Created(url ?? "", response);
                    }
                default:
                    return StatusCode((int)response.StatusCode, response);
            }
        }
    }
}
