﻿namespace CatsServerFDMC.Handlers
{
    using Data;
    using Infrastructure;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class CatDetailsHandler : IHandler
    {
        public int Order => 3;

        public Func<HttpContext, bool> Condition =>
            ctx => ctx.Request.Path.Value.StartsWith("/cat")
                && ctx.Request.Method == HttpMethod.Get;

        public RequestDelegate RequestHandler =>
            async (context) =>
            {
                var urlParts = context.Request.Path.Value.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (urlParts.Length < 2)
                {
                    context.Response.Redirect("/");
                    return;
                }

                int.TryParse(urlParts[1], out int catId);

                if (catId == 0)
                {
                    context.Response.Redirect("/");
                    return;
                }

                var db = context.RequestServices.GetRequiredService<CatsDbContext>();

                using (db)
                {
                    var cat = await db.Cats.FindAsync(catId);
                    if (cat == null)
                    {
                        context.Response.Redirect("/");
                        return;
                    }

                    await context.Response.WriteAsync($"<h1>{cat.Name}</h1>");
                    await context.Response.WriteAsync($@"<img src=""{cat.ImageUrl}"" alt=""{cat.Name}"" width=""300"" />");
                    await context.Response.WriteAsync($"<p><b>Age: {cat.Age}</b></p>");
                    await context.Response.WriteAsync($"<p><b>Breed: {cat.Breed}</p></b>");
                }
            };
    }
}
