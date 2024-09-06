using ASP.Aplication.Exceptions;
using ASP.Aplication;

namespace ASP.API.Core
{
    public class GlobalExtensionHandlingMiddleware(RequestDelegate next, IExceptionLogger logger, IAplicationActor actor)
    {
        private readonly RequestDelegate _next = next;
        private IExceptionLogger _logger = logger;
        private IAplicationActor _actor = actor;



        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                if (exception is UnauthorizedAccessException)
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }
                if (exception is ConflictException c)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                    var body = new { error = c.Message };

                    await httpContext.Response.WriteAsJsonAsync(body);
                    return;
                }


                if (exception is NotFoundEntityException)
                {
                    httpContext.Response.StatusCode = 404;
                    return;
                }


                var errorId = _logger.Log(exception, _actor);

                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new { Message = $"An unexpected error has occured. Please contact our support with this ID - {errorId}." });
            }
        }
    }
}
