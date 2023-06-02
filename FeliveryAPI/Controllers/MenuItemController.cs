using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        public IMenuItemService MenuItemRepo { get; set; }
        public MenuItemController(IMenuItemService menuItemRepo)
        {
            MenuItemRepo = menuItemRepo;
        }
        [HttpGet]
        public ActionResult<List<MenuItem>> GetFoodServed()
        {
            var listOfMenuItem = MenuItemRepo.GetAll();

            if (listOfMenuItem != null && listOfMenuItem.Count() > 0)
            {
                return Ok(listOfMenuItem);
            }
            return Ok(listOfMenuItem);
        }
        [HttpGet("{id}")]
        public ActionResult<MenuItem> GetById(int id)
        {
            return MenuItemRepo.GetDetails(id);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        { 
            MenuItemRepo.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(MenuItem menuItem)
        {
            if (menuItem != null && menuItem.Id != 0)
            {
                MenuItemRepo.Update(menuItem);

                return Ok(menuItem);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Post([FromBody] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MenuItemRepo.Insert(menuItem);
                    return Created("url", menuItem);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }
        //Upload Images
        [HttpPost("uploadImage/{storename}/{ItemName}")]
        public ActionResult UploadImage(IFormFile? file, string storename, string ItemName)
        {
            var Results = MenuItemRepo.UploadImage(file, storename, ItemName);
            return Ok(Results);
        }
    }
}
