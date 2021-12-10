using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DDona.KongPoC.ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IEnumerable<string> _Products = new[] { "Apple", "Banana", "Lemon" };

        [HttpGet]
        public ActionResult<string[]> Get()
        {
            return Ok(_Products);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= _Products.Count())
                return BadRequest("Out of bounds");

            return Ok($"{id} - {_Products.ElementAt(id)}");
        }
    }
}
