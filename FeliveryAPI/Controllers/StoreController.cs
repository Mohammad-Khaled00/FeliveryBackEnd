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

        [HttpGet("OstoreID/{OstoreID}")]
        public async Task<IActionResult> GetOrdersBystoreIDAsync(int OstoreID)
        {
            var orders = await StoreRepo.GetOrdersBystoreID(OstoreID);

            return Ok(orders);
        }

        [HttpGet("FinshedOrders/{OstoreID}")]
        public async Task<IActionResult> GetFinshedOrdersBystoreID(int OstoreID)
        {
            var orders = await StoreRepo.GetFinshedOrdersBystoreID(OstoreID);

            return Ok(orders);
        }

        [HttpGet("MstoreID/{MstoreID}")]
        public async Task<IActionResult> GetmenuitemsBystoreIDAsync(int MstoreID)
        {
            var menuitems = await StoreRepo.GetmenuitemsBystoreID(MstoreID);

            return Ok(menuitems);
        }

        [HttpGet("CstoreID/{CstoreID}")]
        public async Task<IActionResult> GetCategoriesBystoreID(int CstoreID)
        {
            var categories = await StoreRepo.GetCategoriesBystoreID(CstoreID);

            return Ok(categories);
        }

        [HttpGet("TotalEarnings/{storeID}")]
        public async Task<IActionResult> TotalEarnings(int storeID)
        {
            var earnings = await StoreRepo.TotalEarnings( storeID);
            return Ok(earnings);
        }

        [HttpGet("PendingOrders/{storeID}")]
        public async Task<IActionResult> PendingOrders(int storeID)
        {
            var orders = await StoreRepo.PendingOrders(storeID);
            return Ok(orders);
        }

        [HttpGet("DeliveredOrders/{storeID}")]
        public async Task<IActionResult> DeliveredOrders(int storeID)
        {
            var orders = await StoreRepo.DeliveredOrders(storeID);
            return Ok(orders);
        }

        [HttpPut("DoneOrder/{orderID}")]
        public ActionResult DoneOrder(int orderID)
        {
            StoreRepo.DoneOrder(orderID);
            //"Order Is Done"
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            StoreRepo.Delete(id);
            return Ok("Store Deleted Successfully");
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

        [HttpGet("GetPendingStore")]
        public ActionResult<List<Restaurant>> PendingStore()
        {

            return StoreRepo.PendingStore();
        }

        //Upload Images
        [HttpPost("uploadImage/{storeName}")]
        public ActionResult UploadImage(IFormFile file, string storeName)
        {
            var Results =  StoreRepo.UploadImage(file, storeName);
            return Ok(Results);
        }

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