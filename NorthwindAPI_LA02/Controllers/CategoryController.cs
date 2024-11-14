using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI_LA02.Data;
using NorthwindAPI_LA02.Domain;

namespace NorthwindAPI_LA02.Controllers
{

    [Authorize]
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

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryRequest category)
        {
            //mapping
            var originalCategory = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            _context.Categories.Add(originalCategory);
            _context.SaveChanges();
            return Created(string.Empty, null);
        }

        [HttpPut("{id}")]
        public IActionResult Update(short id, [FromBody] UpdateCategoryRequest requested)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if(_category == null) {  return NotFound(); }

            _category.CategoryName = requested.CategoryName;
            _category.Description = requested.Description;
            _context.Update(_category);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id) { 
            var category = _context.Categories.SingleOrDefault( c=> c.CategoryId == id);
            if (category == null)  return NotFound(); 

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        
        }

    }
}
