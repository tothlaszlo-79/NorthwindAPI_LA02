using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI_LA02.Data;
using NorthwindAPI_LA02.Domain;

namespace NorthwindAPI_LA02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CategoryController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories;

            if (categories == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(categories);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            var adat = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (adat == null)
            {
                return NotFound();
            }
            else
            {
                { return Ok(adat); }
            }
        }

        [HttpGet("count")]
        public int Count() => _context.Categories.Count();

       
        [HttpGet("{id}/products")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_context.Products.Where(p => p.CategoryId == id));
        }
    }
}
