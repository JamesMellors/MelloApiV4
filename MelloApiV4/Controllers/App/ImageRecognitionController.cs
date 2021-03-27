using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MelloApiV4.Queries.ImageRecognition;
using Microsoft.AspNetCore.Mvc;

namespace MelloApiV4.Controllers.App
{
    [Route("[controller]")]
    [ApiController]
    public class ImageRecognitionController : Controller
    {
        private readonly IMediator _mediator;

        public ImageRecognitionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetImageInfo")]
        public async Task<IActionResult> GetTranslationsByGroup([FromBody] GetImageInfo.Query query)
        {
            var result = await _mediator.Send(query);
            return Json(result);
        }
    }
}