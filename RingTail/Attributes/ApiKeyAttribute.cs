using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RingTail.Attributes {
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter {
        private const string ApiKeyName = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey)) {
                context.Result = new ContentResult {
                    StatusCode = 401,
                    Content = "Api Key was not provided"
                };
                return;
            }

            if (!Common.IsValidApi(Nuix.General.Encrypt(extractedApiKey))) {
                context.Result = new ContentResult {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }

            await next();
        }
    }
}