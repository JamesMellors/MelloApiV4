using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MelloApiV4.Queries;
using MelloApiV4.Queries.Language;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MelloApiV4.Controllers.App
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : Controller
    {
        // GET: /<controller>/
        private readonly IMediator _mediator;
      
        /*    public IActionResult Index()
            {
                return View();
            }*/

        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("test")]
        public async Task<IActionResult> ApiTest([FromQuery] TestResult.Query query)
        {
            var result = await _mediator.Send(query);
            return Json(result);
            //return _actionResultFactory.CreateResultFromResponseModel(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetAllTranslations")]
        public async Task<IActionResult> GetAllTranslations([FromQuery] GetAllTranslations.Query query)
        {
            var result = await _mediator.Send(query);
            return Json(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetTranslationsByGroup")]
        public async Task<IActionResult> GetTranslationsByGroup([FromQuery] GetTranlsationsBasedOnGroup.Query query)
        {
            var result = await _mediator.Send(query);
            return Json(result);
        }

    }
}
