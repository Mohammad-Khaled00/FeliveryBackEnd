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
    public class RestaurantController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        public IParentStoreService ParentStoretRepo { get; set; }
        public RestaurantController(IParentStoreService parentStoretRepo, IWebHostEnvironment environment)
        {
            ParentStoretRepo = parentStoretRepo;
            _environment = environment;
        }


        [HttpGet]
        public ActionResult<List<Restaurant>> getRestaurants()
        {

            return ParentStoretRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Restaurant> getById(int id)
        {
            return ParentStoretRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Restaurant restaurant = ParentStoretRepo.GetDetails(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            ParentStoretRepo.Delete(id);
            return Ok(restaurant);
        }
        [HttpPut]
        public ActionResult put(int id, Restaurant rstrnt)
        {
            if (rstrnt != null && rstrnt.Id != 0)
            {
                ParentStoretRepo.Update(rstrnt);
                return Ok(rstrnt);
            }
            return NotFound();
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

        [HttpPost]
        public ActionResult Post(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ParentStoretRepo.Insert(restaurant);
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

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await ParentStoretRepo.RegisterAsync(model);


            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
            //return Ok(new { token = result.Token, expiration = result.ExpiresOn});

        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await ParentStoretRepo.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await ParentStoretRepo.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }
    }
}
