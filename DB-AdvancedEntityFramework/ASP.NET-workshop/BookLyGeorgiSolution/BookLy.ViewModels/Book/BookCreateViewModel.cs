namespace BookLy.ViewModels.Book
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;

    public class BookCreateViewModel
    {
        public BookCreateViewModel()
        {
            this.PossibleGenres = new List<ListItem>();
            this.SelectedGenres = new List<string>();
        }

        public string Name { get; set; }

        public string Resume { get; set; }

        public int Pages { get; set; }

        public string ContentSource { get; set; }

        public string AuthorId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [DisplayName("Genres")]
        public IEnumerable<ListItem> PossibleGenres { get; set; }

        public IEnumerable<string> SelectedGenres { get; set; }
    }
}
