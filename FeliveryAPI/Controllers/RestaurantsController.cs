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
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        public IRepository<Restaurant> RestaurantRepo { get; set; }
        public RestaurantsController(IRepository<Restaurant> restaurantRepo, IWebHostEnvironment environment)
        {
            RestaurantRepo = restaurantRepo;
            _environment = environment;
        }


        [HttpGet]
        public ActionResult<List<Restaurant>> getRestaurants()
        {

            return RestaurantRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Restaurant> getById(int id)
        {
            return RestaurantRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Restaurant restaurant = RestaurantRepo.GetDetails(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            RestaurantRepo.Delete(id);
            return Ok(restaurant);
        }
        [HttpPut]
        public ActionResult put(int id, Restaurant rstrnt)
        {
            if (rstrnt != null && rstrnt.Id != 0)
            {
                RestaurantRepo.Update(rstrnt);
                return Ok(rstrnt);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RestaurantRepo.Insert(restaurant);
                    return Created("url", restaurant);
                    // return 201 & Url is the place where you added the object
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message); // Return 400!
                }
            }
            return BadRequest();
        }
        //Upload Images
        [HttpPost("uploadImage")]
       
        public async Task<ActionResult> uploadImage(IFormFileCollection uploadFiles)
        {
            bool Results =false;
            try
            {
                //var uploadFiles = Request.Form.Files;
                foreach (IFormFile file in uploadFiles)
                {
                    string Filename = file.FileName;
                    string Filepath = GetFilePath(Filename);
                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }

                    string imagepath = Filepath + "\\image.png";
                    if (System.IO.Directory.Exists(imagepath))
                    {
                        System.IO.Directory.Delete(imagepath);
                    }
                    using(FileStream stream = System.IO.File.Create(imagepath)) {
                    await file.CopyToAsync(stream);
                        Results = true;
                    }
                }

            }
            catch (Exception ex) { }
            return Ok(Results);
        }
        [NonAction]
        private string GetFilePath(string ProductCode)
        {
            return this._environment.WebRootPath+ "\\Uploads\\Product\\" + ProductCode;
        }

    }
}
