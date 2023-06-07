using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        public IFeedBackSercivce<Review> ReviewRepo { get; }
        public ReviewController(IFeedBackSercivce<Review> reviewRepo)
        {
            ReviewRepo = reviewRepo;
        }

        [HttpGet]
        public ActionResult<List<Review>> GetTechFeedBacks()
        {
            return ReviewRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Review> GetById(int id)
        {
            return ReviewRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<Review> Delete(int id)
        {
            Review FeedBackData = ReviewRepo.Delete(id);
            return Ok(FeedBackData);
        }

        [HttpPost]
        public ActionResult Post(Review FeedBack)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ReviewRepo.Insert(FeedBack);
                    return Created("url", FeedBack);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpGet("StoreFeedBack/{storeID}")]
        public async Task<IActionResult> GetByStoreIDAsync(int storeID)
        {
            var FeedBacks = await ReviewRepo.GetBystoreID(storeID);

            return Ok(FeedBacks);
        }

        [HttpGet("CustomerFeedBack/{customerID}")]
        public async Task<IActionResult> GetByCustomerIDAsync(int customerID)
        {
            var FeedBacks = await ReviewRepo.GetBycustomerID(customerID);

            return Ok(FeedBacks);
        }
    }
}
