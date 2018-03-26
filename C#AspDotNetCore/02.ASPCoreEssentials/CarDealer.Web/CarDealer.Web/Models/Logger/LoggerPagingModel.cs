namespace CarDealer.Web.Models.Logger
{
    using Services.Models;
    using System.Collections.Generic;

    public class LoggerPagingModel
    {
        public IEnumerable<LoggerModel> Logs { get; set; }

        public string Search { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
