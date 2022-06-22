using Newtonsoft.Json;

using ALTPOINT_CRUD.API.Errors;
using ALTPOINT_CRUD.Application.Exceptions;
using ALTPOINT_CRUD.API.JsonContractResolvers;

namespace ALTPOINT_CRUD.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new LowerCaseContractResolver();

            try
            {
                await _next(context);
            }

            catch(Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch(error)
                {
                    case EntityNotFoundException:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        var entitynotFoundError = new EntityNotFoundError();
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(entitynotFoundError, serializerSettings));
                        break;

                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        var defaultServerError = new ServerError();
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(defaultServerError, serializerSettings));
                        break;
                }
            }
        }
    }
}
