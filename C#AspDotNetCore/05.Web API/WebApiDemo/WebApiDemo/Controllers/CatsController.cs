using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class CatsController : BaseApiController
    {
        private readonly IData data;

        public CatsController(IData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IEnumerable<Cat> Get() => this.data.All();

        [HttpGet("{id}")]
        public Cat Get(int id) => this.data.Find(id);

        [HttpPost]
        public IActionResult Post([FromBody]Cat cat)
        {
            // frombody asp core new, mvc5 will work without it

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = this.data.Add(cat);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Cat cat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dataCat = this.data.Find(id);
            if (dataCat == null)
            {
                return NotFound();
            }

            dataCat.Name = cat.Name;
            dataCat.Age = cat.Age;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cat = this.data.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            this.data.Delete(id);

            return Ok();
        }
    }
}
 