using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalFeedBackController : Controller
    {
        public IFeedBackSercivce<TechnicalFeedBack> TechFeedBackRepo { get; set; }
        public TechnicalFeedBackController(IFeedBackSercivce<TechnicalFeedBack> techFeedBackRepo)
        {
            TechFeedBackRepo = techFeedBackRepo;
        }

        [HttpGet]
        public ActionResult<List<TechnicalFeedBack>> GetTechFeedBacks()
        {
            return TechFeedBackRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TechnicalFeedBack> GetById(int id)
        {
            return TechFeedBackRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<TechnicalFeedBack> Delete(int id)
        {
            TechnicalFeedBack FeedBackData = TechFeedBackRepo.Delete(id);
            return Ok(FeedBackData);
        }

        [HttpPost]
        public ActionResult Post(TechnicalFeedBack FeedBack)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TechFeedBackRepo.Insert(FeedBack);
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
            var FeedBacks = await TechFeedBackRepo.GetBystoreID(storeID);

            return Ok(FeedBacks);
        }

        [HttpGet("CustomerFeedBack/{customerID}")]
        public async Task<IActionResult> GetByCustomerIDAsync(int customerID)
        {
            var FeedBacks = await TechFeedBackRepo.GetBycustomerID(customerID);

            return Ok(FeedBacks);
        }
    }
}
