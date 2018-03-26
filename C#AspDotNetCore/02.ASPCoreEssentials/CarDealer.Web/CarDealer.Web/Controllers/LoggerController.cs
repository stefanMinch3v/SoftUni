namespace CarDealer.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Logger;
    using Services;
    using System;
    using System.Linq;

    public class LoggerController : Controller
    {
        private const int ValuesPerPage = 4;

        private readonly ILoggerService logger;

        private int currentPageSize = ValuesPerPage;

        public LoggerController(ILoggerService logger)
        {
            this.logger = logger;
        }

        [Authorize]
        public IActionResult All(string search, int page = 1)
        {
            var logs = this.logger.All();

            if (!string.IsNullOrWhiteSpace(search))
            {
                logs = logs.Where(l => l.Username.ToLower().Contains(search.ToLower()));
                this.currentPageSize = logs.Count();
            }

            if (page < 1)
            {
                page = 1;
            }

            logs = logs
                    .Skip((page - 1) * ValuesPerPage)
                    .Take(ValuesPerPage);

            return View(new LoggerPagingModel
            {
                Logs = logs,
                Search = search,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.logger.Total() / (double)currentPageSize)
            });
        }

        [Authorize]
        public IActionResult Delete()
        {
            this.logger.DeleteAll();

            return RedirectToAction(nameof(All));
        }
    }
}
