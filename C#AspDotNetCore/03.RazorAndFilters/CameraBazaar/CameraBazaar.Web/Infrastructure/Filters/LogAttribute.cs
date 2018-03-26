namespace CameraBazaar.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // use async only if you expected to have huge users otherwise there is no poin of using it
            Task.Run(async () =>
            {
                var date = DateTime.UtcNow;
                var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
                var user = context.HttpContext.User?.Identity?.Name ?? "anonymous";

                //var pathValues = context.HttpContext.Request.Path.Value.Split("/", StringSplitOptions.RemoveEmptyEntries);
                //var controller = $"{pathValues[0]}Controller";
                //var action = pathValues[1];
                var controller = context.Controller.GetType().Name;
                var action = context.RouteData.Values["action"];

                var logMessage = $"{date} – {ipAddress} – {user} – {controller}.{action}";

                using (var writer = new StreamWriter("logs.txt", true))
                {
                    if (context.Exception != null)
                    {
                        var exceptionType = context.Exception.GetType().Name;
                        var exceptionMessage = context.Exception.Message;

                        logMessage = $"[!] {logMessage} - {exceptionType} - {exceptionMessage}";
                    }

                    await writer.WriteLineAsync(logMessage);
                }
            })
            .GetAwaiter()
            .GetResult();

            base.OnActionExecuted(context);
        }
    }
}
