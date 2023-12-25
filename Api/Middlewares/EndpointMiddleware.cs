using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    public class EndpointMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<EndpointMiddleware> _logger;

        public EndpointMiddleware(RequestDelegate next, ILogger<EndpointMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            LogEndpointInformation(context);
            await _next(context);
        }


        private void LogEndpointInformation(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var endpointName = endpoint?.DisplayName ?? "Unknown Endpoint";

            var requestPath = context.Request.Path;
            var requestMethod = context.Request.Method;

            // Aquí puedes realizar el registro de la información del endpoint.
            // Puedes almacenar esta información en una base de datos, un archivo de registro, etc.

            _logger.LogInformation($"endpoint: {endpointName}, " +
                $"Path: {requestPath}, Method: {requestMethod}");
        }
    }
}
