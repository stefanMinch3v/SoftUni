namespace CameraBazaar.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class TimerAttribute : ActionFilterAttribute
    {
        private Stopwatch stopwatch;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.stopwatch = Stopwatch.StartNew();

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var date = DateTime.UtcNow;
            var controller = context.Controller.GetType().Name;
            var action = context.RouteData.Values["action"];

            using (var writer = new StreamWriter("action-times.txt", true))
            {
                writer.WriteLineAsync($"{date} - {controller}.{action} - {this.stopwatch.Elapsed}");
            }

            base.OnActionExecuted(context);
        }
    }
}
