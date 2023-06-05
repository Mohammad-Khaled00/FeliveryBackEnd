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
        public ActionResult<MenuItem> Delete(int id)
        {
            MenuItem MenuData = MenuItemRepo.Delete(id);
            return Ok(MenuData);
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
        [HttpPost("uploadImage/{StoreId}/{ItemName}")]
        public ActionResult UploadImage(IFormFile? file, int StoreId, string ItemName)
        {
            var Results = MenuItemRepo.UploadImage(file, StoreId, ItemName);
            return Ok(Results);
        }

        [HttpGet("offers")]
        public ActionResult<List<MenuItem>> GetOffers()
        {
            var listOfMenuItem = MenuItemRepo.MenuItemOffer();

            if (listOfMenuItem != null )
            {
                return Ok(listOfMenuItem);
            }
            return Ok(listOfMenuItem);
        }

    }
}
