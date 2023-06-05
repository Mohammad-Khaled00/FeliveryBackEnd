using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        public IStoreService StoreRepo { get; set; }
        public StoreController(IStoreService storeRepo)
        {
            StoreRepo = storeRepo;
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
        public ActionResult<Restaurant> Delete(int id)
        {
            Restaurant StoreData = StoreRepo.Delete(id);
            return Ok(StoreData);
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
        }

        //Upload Images
        [HttpPost("uploadImage/{storeName}")]
        public ActionResult UploadImage(IFormFile file, string storeName)
        {
            var Results = StoreRepo.UploadImage(file, storeName);
            return Ok(Results);
        }

        [HttpGet("GetPendingStore")]
        public ActionResult<List<Restaurant>> PendingStore()
        {

            return StoreRepo.PendingStore();
        }

        [HttpGet("PendingOrders/{storeID}")]
        public async Task<IActionResult> GetOrdersBystoreIDAsync(int storeID)
        {
            var orders = await StoreRepo.GetOrdersBystoreID(storeID);

            return Ok(orders);
        }

        [HttpGet("FinshedOrders/{storeID}")]
        public async Task<IActionResult> GetFinshedOrdersBystoreID(int storeID)
        {
            var orders = await StoreRepo.GetFinshedOrdersBystoreID(storeID);

            return Ok(orders);
        }

        [HttpGet("StoreMenu/{storeID}")]
        public async Task<IActionResult> GetmenuitemsBystoreIDAsync(int storeID)
        {
            var menuitems = await StoreRepo.GetmenuitemsBystoreID(storeID);

            return Ok(menuitems);
        }

        [HttpGet("StoreOffers/{storeID}")]
        public async Task<IActionResult> GetOffersBystoreID(int storeID)
        {
            var offerItems = await StoreRepo.GetOffersBystoreID(storeID);

            return Ok(offerItems);
        }

        [HttpGet("StoreCategories/{storeID}")]
        public async Task<IActionResult> GetCategoriesBystoreID(int storeID)
        {
            var categories = await StoreRepo.GetCategoriesBystoreID(storeID);

            return Ok(categories);
        }

        [HttpGet("TotalEarnings/{storeID}")]
        public async Task<IActionResult> TotalEarnings(int storeID)
        {
            var earnings = await StoreRepo.TotalEarnings( storeID);
            return Ok(earnings);
        }

        [HttpGet("TotalPendingOrders/{storeID}")]
        public async Task<IActionResult> TotalPendingOrders(int storeID)
        {
            var orders = await StoreRepo.TotalPendingOrders(storeID);
            return Ok(orders);
        }

        [HttpGet("TotalDeliveredOrders/{storeID}")]
        public async Task<IActionResult> TotalDeliveredOrders(int storeID)
        {
            var orders = await StoreRepo.TotalDeliveredOrders(storeID);
            return Ok(orders);
        }

        [HttpPut("DoneOrder/{orderID}")]
        public ActionResult DoneOrder(int orderID)
        {
            StoreRepo.DoneOrder(orderID);
            return Ok();
        }

        [HttpPut("SetRating/{storeID}/{rate}")]
        public ActionResult SetRate(int rate, int storeID)
        {
            StoreRepo.SetRate(rate, storeID);
            return Ok();
        }

        //Search
        [HttpGet("Name")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> Search(string name)
        {
            try
            {
                var result = await StoreRepo.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}