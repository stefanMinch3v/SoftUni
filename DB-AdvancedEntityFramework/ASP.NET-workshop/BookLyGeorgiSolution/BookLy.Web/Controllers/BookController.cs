namespace BookLy.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;

    using AutoMapper;

    using BookLy.Data;
    using BookLy.Models;
    using BookLy.ViewModels.Book;
    using BookLy.ViewModels.Comment;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class BookController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Evaluate(int id, string status)
        {
            Book book = this.context.Books.Find(id);

            if (book == null)
            {
                return this.RedirectToAction(
                "Details",
                new
                {
                    id = id
                });
            }

            ApplicationUser user = this.context.Users.Find(this.User.Identity.GetUserId());
            if (status == "like")
            {
                if (book.Upvotes.Any(u => u.Id == user.Id))
                {
                    return this.RedirectToAction(
                        "Details",
                        new
                        {
                            id = id
                        });
                }

                if (book.Downvotes.Any(u => u.Id == user.Id))
                {
                   book.Downvotes.Remove(book.Downvotes.SingleOrDefault(u => u.Id == user.Id));
                }

                book.Upvotes.Add(user);
            }
            else if (status == "dislike")
            {
                if (book.Downvotes.Any(u => u.Id == user.Id))
                {
                    return this.RedirectToAction(
                        "Details",
                        new
                        {
                            id = id
                        });
                }

                if (book.Upvotes.Any(u => u.Id == user.Id))
                {
                    book.Upvotes.Remove(book.Upvotes.SingleOrDefault(u => u.Id == user.Id));
                }


                book.Downvotes.Add(user);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            this.context.SaveChanges();

            return this.RedirectToAction(
                "Details",
                new
                {
                    id = id
                });
        }

        // GET: Book
        [AllowAnonymous]
        public ActionResult Index()
        {
            var books = this.context.Books.Include(b => b.Author);
            return this.View(books.ToList());
        }

        // GET: Book/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = this.context.Books.Include(b => b.Comments).SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.HttpNotFound();
            }

            return this.View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            BookCreateViewModel bookViewModel = new BookCreateViewModel();

            bookViewModel.PossibleGenres = this.context.Genres
                .Select(g => new { Id = g.Id, Name = g.Name })
                .ToList()
                .Select(g => new ListItem(g.Name, g.Id.ToString()));

            return this.View(bookViewModel);
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Resume,Pages,ContentSource,Image,SelectedGenres")] BookCreateViewModel bookViewModel)
        {
            if (this.ModelState.IsValid)
            {
                Book book = Mapper.Instance.Map<Book>(bookViewModel);
                book.AuthorId = this.User.Identity.GetUserId();

                book.Genres =
                    this.context.Genres.Where(g => bookViewModel.SelectedGenres.Contains(g.Id.ToString())).ToList();

                if (book.Genres.Count != bookViewModel.SelectedGenres.Count())
                {
                    return new HttpNotFoundResult("Categories not valid!");
                }

                this.context.Books.Add(book);
                this.context.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(bookViewModel);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = this.context.Books.Find(id);
            if (book == null)
            {
                return this.HttpNotFound();
            }

            if (book.AuthorId != this.User.Identity.GetUserId())
            {
                return this.Redirect("Index");
            }

            return this.View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Resume,Pages,ContentSource,Image,AuthorId")] Book book)
        {
            if (book.AuthorId != this.User.Identity.GetUserId())
            {
                return this.Redirect("Index");
            }

            if (this.ModelState.IsValid)
            {
                this.context.Entry(book).State = EntityState.Modified;
                this.context.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(book);
        }

        // GET: Book/Delete/5
        // Be careful when deleting entities e.g: deleting book here will cascade delete
        // comments and votes.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = this.context.Books.Find(id);
            if (book == null)
            {
                return this.HttpNotFound();
            }

            if (book.AuthorId != this.User.Identity.GetUserId())
            {
                return this.Redirect("Index");
            }

            return this.View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = this.context.Books.Find(id);

            if (book == null)
            {
                return this.HttpNotFound();
            }

            if (book.AuthorId != this.User.Identity.GetUserId())
            {
                return this.Redirect("Index");
            }

            this.context.Books.Remove(book);
            this.context.SaveChanges();
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "Content,BookId")]CommentCreateViewModel commentViewModel)
        {
            if (this.ModelState.IsValid)
            {
                Comment comment = Mapper.Instance.Map<Comment>(commentViewModel);
                comment.AuthorId = this.User.Identity.GetUserId();

                this.context.Comments.Add(comment);
                this.context.SaveChanges();

                return this.RedirectToAction("Details", new { id = comment.BookId });
            }

            return this.RedirectToAction("Details", new { id = commentViewModel.BookId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
