namespace News.Api.Models.News
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewsFormModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
