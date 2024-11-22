using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Http;
using System.Net;

namespace Sober.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors[0];
            var statusCode = (int)(firstError.Type switch
            {
                ErrorType.Conflict => HttpStatusCode.Conflict,
                ErrorType.Validation => HttpStatusCode.BadRequest,
                ErrorType.NotFound => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            });

            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}
