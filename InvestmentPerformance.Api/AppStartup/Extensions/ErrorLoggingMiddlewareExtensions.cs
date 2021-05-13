using InvestmentPerformance.Api.AppStartup.Middleware;
using Microsoft.AspNetCore.Builder;

namespace InvestmentPerformance.Api.AppStartup.Extensions
{
    public static class ErrorLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLoggingMiddleware>();
        }
    }
}
