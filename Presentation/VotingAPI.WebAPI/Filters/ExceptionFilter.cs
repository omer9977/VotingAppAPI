using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VotingAPI.WebAPI.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public async override Task OnExceptionAsync(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            switch (context.Exception)
            {
                case DataNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ArgumentNullException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ArgumentOutOfRangeException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    break;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;

            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                statusCode = (int)statusCode,
                stackTrace = context.Exception.StackTrace
            });
        }
    }
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(object id)
            : base($"{id} id object could not be found.") { }
    }
}
