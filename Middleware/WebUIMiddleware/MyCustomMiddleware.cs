using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIMiddleware
{

    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyCustomMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

            _logger = logFactory.CreateLogger("MyCustomMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("My Custom Middleware is executing..");
            string username = httpContext.Request.Query["username"].ToString();
            if (string.IsNullOrWhiteSpace(username))
            {
                httpContext.Response.Headers.Add("username", username);
            }
            await _next(httpContext); // calling next middleware

        }
    }

}
