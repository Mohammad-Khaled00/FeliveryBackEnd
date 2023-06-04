using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IRepository<Category> CategoryRepo { get; set; }
        public CategoryController(IRepository<Category> categoryRepo)
        {
            CategoryRepo = categoryRepo;
        }
        [HttpGet]
        public ActionResult<List<Category>> GetCategories()
        {
            return CategoryRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            return CategoryRepo.GetDetails(id);
        }
        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            Category CategoryData = CategoryRepo.Delete(id);
            return Ok(CategoryData);
        }
        [HttpPut]
        public ActionResult Put(Category category)
        {
            if (category != null && category.Id != 0)
            {
                CategoryRepo.Update(category);
                return Ok(category);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoryRepo.Insert(category);
                    return Created("url", category);
                    // return 201 & Url is the place where you added the object
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message); // Return 400!
                }
            }
            return BadRequest();
        }
    }
}
