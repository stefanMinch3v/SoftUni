namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Categories;
    using Services;
    using System.Threading.Tasks;

    using static WebConstants;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => this.OkOrNotFound(await this.categoryService.All(), "");

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.categoryService.Details(id), UnexistingCategory);

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]CategoryRequestModel model)
        {
            if (await this.categoryService.Exists(model.Name))
            {
                return BadRequest(ExistingCategory);
            }

            return Ok(await this.categoryService.Create(model.Name));
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody]CategoryRequestModel model)
        {
            if (!await this.categoryService.Exists(id))
            {
                return BadRequest(UnexistingCategory);
            }

            // could have been done in the the db models with index attribute for unique name 
            if (await this.categoryService.Exists(model.Name))
            {
                return BadRequest(ExistingCategory);
            }

            await this.categoryService.Edit(id, model.Name);

            return Ok();
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.categoryService.Exists(id))
            {
                return NotFound(UnexistingCategory);
            }

            await this.categoryService.Delete(id);

            return Ok();
        }
    }
}
