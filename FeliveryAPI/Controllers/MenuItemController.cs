using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeliveryAPI.Data;
using FeliveryAPI.Models;
using FeliveryAPI.Repository;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        public IRepository<MenuItem> MenuItemRepo { get; set; }
        public MenuItemController(IRepository<MenuItem> menuItemRepo)
        {
            MenuItemRepo = menuItemRepo;
        }
        [HttpGet]
        public ActionResult<List<MenuItem>> getFoodServed()
        {
            var listOfMenuItem = MenuItemRepo.GetAll();

            if (listOfMenuItem != null && listOfMenuItem.Count() > 0)
            {
                return Ok(listOfMenuItem);
            }
            return Ok(listOfMenuItem);
        }
        [HttpGet("{id}")]
        public ActionResult<MenuItem> getById(int id)
        {
            return MenuItemRepo.GetDetails(id);
        }
        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        { 
            MenuItemRepo.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult put(MenuItem menuItem)
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
