using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IRepository<Order> OrderRepo { get; set; }
        public OrderController(IRepository<Order> orderRepo)
        {
            OrderRepo = orderRepo;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {

            return OrderRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetById(int id)
        {
            return OrderRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            Order OrderData = OrderRepo.Delete(id);
            return Ok(OrderData);
        }

        [HttpPut]
        public ActionResult Put( Order order)
        {
        
            if (order.Id != 0 && order != null)
            {
                OrderRepo.Update(order);
                return Ok(order);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrderRepo.Insert(order);
                    return Created("url", order);
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
