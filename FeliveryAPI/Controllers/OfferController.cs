using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        public IRepository<Offer> OfferRepo { get; set; }
        public OfferController(IRepository<Offer> offerRepo)
        {
            OfferRepo= offerRepo;
        }
        [HttpGet]
        public ActionResult<List<Offer>> getFoodServed()
        {
            var listOfOffers = OfferRepo.GetAll();

            if (listOfOffers != null && listOfOffers.Count() > 0)
            {
                return Ok(listOfOffers);
            }
            return Ok(listOfOffers);
        }
        [HttpGet("{id}")]
        public ActionResult<Offer> getById(int id)
        {
            return OfferRepo.GetDetails(id);
        }
        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {     
            OfferRepo.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult put(Offer offer)
        {
            if (offer != null && offer.Id != 0)
            {
                OfferRepo.Update(offer);

                return Ok(offer);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Post([FromBody] Offer offer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OfferRepo.Insert(offer);
                    return Created("url", offer);
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
