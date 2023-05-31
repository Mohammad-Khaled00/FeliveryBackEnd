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

        [HttpGet("OstoreID/{OstoreID}")]
        public async Task<IActionResult> GetOrdersBystoreIDAsync(int OstoreID)
        {
            var orders = await StoreRepo.GetOrdersBystoreID(OstoreID);

            return Ok(orders);
        }

        [HttpGet("MstoreID/{MstoreID}")]
        public async Task<IActionResult> GetmenuitemsBystoreIDAsync(int MstoreID)
        {
            var menuitems = await StoreRepo.GetmenuitemsBystoreID(MstoreID);

            return Ok(menuitems);
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
            return Ok("Order Is Done");
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
            //return Ok();
            //return Ok(new { token = result.Token, expiration = result.ExpiresOn});
        }



        //Upload Images
        [HttpPost("uploadImage")]
        public async Task<ActionResult> UploadImage(IFormFile file)
        {
            bool Results = false;
            try
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
                    using FileStream stream = System.IO.File.Create(imagepath);
                    await file.CopyToAsync(stream);
                    Results = true;
                }
            catch (Exception ex) { }
            return Ok(Results);
        }


        [NonAction]
        private string GetFilePath(string ProductCode)
        {
            return this._environment.WebRootPath + "\\Uploads\\Product\\" + ProductCode;
        }


        [NonAction]
        private string GetImagebyProduct(string productcode)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "https://localhost:7118/";
            string Filepath = GetFilePath(productcode);
            string Imagepath = Filepath + "\\image.png";
            if (!System.IO.File.Exists(Imagepath))
            {
                ImageUrl = HostUrl + "/uploads/common/noimage.png";
            }
            else
            {
                ImageUrl = HostUrl + "/uploads/Product/" + productcode + "/image.png";
            }
            return ImageUrl;
        }

    }
}