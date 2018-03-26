namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Books;
    using Services;
    using System.Threading.Tasks;

    using static WebConstants;

    public class BooksController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.bookService.Details(id), UnexistingBook);


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
            => this.OkOrNotFound(await this.bookService.TopTen(search), "");

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] PostBookRequestModel model)
        {
            if (!await this.authorService.Exists(model.AuthorId))
            {
                return BadRequest(UnexistingAuthor);
            }

            return this.Ok(await this.bookService.Create(
                  model.Title,
                  model.Description,
                  model.Price,
                  model.Copies,
                  model.Edition,
                  model.AgeRestriction,
                  model.ReleaseDate,
                  model.AuthorId,
                  model.Categories));
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            if(!await this.bookService.Exists(id))
            {
                return NotFound(UnexistingBook);
            }

            await this.bookService.Delete(id);

            return Ok();
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody]EditBookRequestModel model)
        {
            if(!await this.bookService.Exists(id))
            {
                return NotFound(UnexistingBook);
            }

            if (!await this.authorService.Exists(model.AuthorId))
            {
                return BadRequest(UnexistingAuthor);
            }

            await this.bookService.Edit(
                id,
                model.Title,
                model.Description,
                model.Price,
                model.Copies,
                model.Edition,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId);

            return Ok();
        }
    }
}
