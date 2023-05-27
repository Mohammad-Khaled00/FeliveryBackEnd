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
        public IOrderWithDetails OrderRepo { get; set; }
        public OrderController(IOrderWithDetails orderRepo)
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

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Order order = OrderRepo.GetDetails(id);

            if (order == null)
            {
                return NotFound();
            }
            OrderRepo.Delete(id);
            return Ok(order);
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

        //[HttpPost]
        //public ActionResult Post(Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            OrderRepo.Insert(order);
        //            return Created("url", order);
        //            // return 201 & Url is the place where you added the object
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex.Message); // Return 400!
        //        }
        //    }
        //    return BadRequest();
        //}

        [HttpPost]
        public void Post([FromBody] OrderOrderDetailsData Data)
        {
            if (!ModelState.IsValid)
                OrderRepo.BothOrderOrderDetails(Data);
        }
    }
}
