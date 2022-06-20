using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Antra.CRMApp.WebAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerFactory _loggerFactory;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            //_loggerFactory = loggerFactory;
        }

        public async Task  Invoke(HttpContext httpContext)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Log.Information("This project stated execution");
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                
                //var ex = httpContext.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    
                    //var _logger = _loggerFactory.CreateLogger<GlobalExceptionMiddleware>();
                    //_logger.LogError(ex.StackTrace);//ex.Message
                    //StackTrace can show where the Exception is

                    Log.Error(ex, "Exception has been handled");
                    await httpContext.Response.WriteAsync(ex.Message);//ex.StackTrace
                }
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}

