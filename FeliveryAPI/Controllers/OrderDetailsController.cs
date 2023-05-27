using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        public IRepository<OrderDetails> OrderDetailsRepo { get; set; }
        public OrderDetailsController(IRepository<OrderDetails> orderdetailsRepo)
        {
            OrderDetailsRepo = orderdetailsRepo;
        }
        [HttpGet]
        public ActionResult<List<OrderDetails>> GetOrders()
        {

            return OrderDetailsRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDetails> GetById(int id)
        {
            return OrderDetailsRepo.GetDetails(id);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            OrderDetails orderDetails = OrderDetailsRepo.GetDetails(id);

            if (orderDetails == null)
            {
                return NotFound();
            }
            OrderDetailsRepo.Delete(id);
            return Ok(orderDetails);
        }
        [HttpPut]
        public ActionResult Put(OrderDetails orderDetails)
        {

            if (orderDetails != null)
            {
                OrderDetailsRepo.Update(orderDetails);
                return Ok(orderDetails);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrderDetailsRepo.Insert(orderDetails);
                    return Created("url", orderDetails);
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
