using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public IStoreService StoreRepo { get; set; }
        public StoreController(IStoreService storeRepo, IWebHostEnvironment environment)
        {
            StoreRepo = storeRepo;
            _environment = environment;
        }


        [HttpGet]
        public ActionResult<List<Restaurant>> GetRestaurants()
        {

            return StoreRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetById(int id)
        {
            return StoreRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = StoreRepo.GetDetails(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            StoreRepo.Delete(id);
            return Ok(restaurant);
        }
        [HttpPut]
        public ActionResult Put(Restaurant restaurant)
        {
            if (restaurant != null && restaurant.Id != 0)
            {
                StoreRepo.Update(restaurant);
                return Ok(restaurant);
            }
            return NotFound();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registeration([FromBody] RegData Data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await StoreRepo.Register(Data);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
            //return Ok();
            //return Ok(new { token = result.Token, expiration = result.ExpiresOn});
        }
    }
}