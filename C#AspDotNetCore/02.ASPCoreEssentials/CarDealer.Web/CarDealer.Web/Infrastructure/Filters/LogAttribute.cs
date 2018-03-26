namespace CarDealer.Web.Infrastructure.Filters
{
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection; // is a must for taking the cardealer context below
    using System;

    public class LogAttribute : ActionFilterAttribute
    {
        private readonly OperationCode operation;

        public LogAttribute(OperationCode operation)
        {
            this.operation = operation;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            var user = context.HttpContext.User.Identity.Name;
            var path = context.HttpContext.Request.Path.Value; // example: suppliers/edit/44
            var pathTokens = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            var modifiedTable = pathTokens[0]; // take controller name

            var db = context
                .HttpContext
                .RequestServices
                .GetService<CarDealerDbContext>(); // here DI

            var log = new Logger
            {
                Username = user,
                ModifiedTable = modifiedTable,
                Operation = this.operation,
                Time = DateTime.UtcNow
            };

            db.Logs.Add(log);
            db.SaveChanges();
        }
    }
}
