namespace BookLy.ViewModels.Article
{
    public class ArticleCreateViewModel
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Content { get; set; }
        
        public int? BookId { get; set; }

        public string TagLabels { get; set; }
    }
}
