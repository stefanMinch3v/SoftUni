namespace BookLy.ViewModels.Comment
{
    using Microsoft.Build.Framework;

    public class CommentCreateViewModel
    {
        [Required]
        public string Content { get; set; }

        public int BookId { get; set; }
    }
}
