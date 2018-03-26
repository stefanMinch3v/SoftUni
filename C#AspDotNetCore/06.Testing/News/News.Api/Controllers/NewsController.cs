namespace News.Api.Controllers
{
    using Data;
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.News;
    using System.Linq;
    using System.Security.Claims;

    using static WebConstants;

    public class NewsController : BaseController
    {
        private readonly NewsDbContext db;

        public NewsController(NewsDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var claimsIdentity = (ClaimsIdentity)HttpContext?.User.Identity;
            //var currentUserEmail = claimsIdentity.Claims.FirstOrDefault(c => c.Type.Contains("email"))?.Value;

            //if (currentUserEmail == "admin@abv.bg")
            //{
            //    return Ok(this.db.News.ToList());
            //}

            return Ok(
                this.db.News
                    .Select(n => new
                    {
                        n.Id,
                        n.Title,
                        n.Content,
                        n.PublishDate,
                        Author = n.Author.UserName
                    })
                    .ToList());
        }

        [Authorize]
        [HttpGet(WithId)]
        public IActionResult Get(int id)
        {
            var news = this.db.News.Find(id);

            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        [Authorize]
        [HttpPost]
        [ValidateModelState] // in order to test attributes behaviour needs an integration test
        public IActionResult Post([FromBody] NewsFormModel model)
        {
            var existingNews = this.db.News.Any(n => n.Title == model.Title);

            if (existingNews)
            {
                return BadRequest($"News with title {model.Title} already exists.");
            }

            var claimsIdentity = (ClaimsIdentity)HttpContext?.User.Identity;
            var authorId = claimsIdentity?.Claims.FirstOrDefault(c => c.Type.Contains(ClaimsIdentityTypeNameId))?.Value;

            if (!ModelState.IsValid)
            {
                return BadRequest(InvalidData); // for test cuz unit tests cant simulate real query and cant catch validate attribute ([ValidateModelState])
            }

            var news = new News
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = model.PublishDate,
                AuthorId = authorId
            };

            this.db.News.Add(news);
            this.db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { news.Id }, model);
        }

        [Authorize]
        [HttpDelete(WithId)]
        public IActionResult Delete(int id)
        {
            var claimsIdentity = (ClaimsIdentity)this.HttpContext?.User.Identity;
            var authorId = claimsIdentity?.Claims.FirstOrDefault(c => c.Type.Contains(ClaimsIdentityTypeNameId))?.Value;

            var existingEntry = this.db.News.Any(n => n.Id == id);

            if (!existingEntry)
            {
                return BadRequest($"News with id {id} doesn`t exist.");
            }

            var news = this.db.News.Find(id);

            if (news.AuthorId != authorId)
            {
                return BadRequest("You are allowed to delete only news posted by you.");
            }

            this.db.News.Remove(news);

            this.db.SaveChanges();

            return Ok(id);
        }

        [Authorize]
        [HttpPut(WithId)]
        [ValidateModelState] // in order to test attributes behaviour needs an integration test
        public IActionResult Put(int id, [FromBody] NewsFormModel model)
        {
            var claimsIdentity = (ClaimsIdentity)this.HttpContext?.User.Identity;
            var authorId = claimsIdentity?.Claims.FirstOrDefault(c => c.Type.Contains(ClaimsIdentityTypeNameId))?.Value;

            var existingNews = this.db.News.Any(n => n.Id == id);

            if (!existingNews)
            {
                return BadRequest("Unexisting entry.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(InvalidData); // for test cuz unit tests cant simulate real query and cant catch validate attr
            }

            var entry = this.db.News.Find(id);

            if (entry.AuthorId != authorId)
            {
                return BadRequest("You can modify only news posted by you.");
            }

            entry.Title = model.Title;
            entry.Content = model.Content;
            entry.PublishDate = model.PublishDate;

            this.db.News.Update(entry);
            this.db.SaveChanges();

            return Ok();
        }
    }
}
