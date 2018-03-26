namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class PublishArticleFormViewModel
    {
        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Content { get; set; }
    }
}
