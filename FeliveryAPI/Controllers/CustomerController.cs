using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public IRepository<Customer> CustomerRepo { get; set; }
        public CustomerController(IRepository<Customer> customerRepo)
        {
            CustomerRepo = customerRepo;
        }
        [HttpGet]
        public ActionResult<List<Customer>> getUsers()
        {
            return CustomerRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> getById(int id)
        {
            return CustomerRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            CustomerRepo.Delete(id);

            if (id == 0)
            {
                return NotFound();
            }
            CustomerRepo.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult put(Customer customer)
        {
            if (customer != null && customer.Id != 0)
            {
                CustomerRepo.Update(customer);
                return Ok(customer);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CustomerRepo.Insert(customer);
                    return Created("url", customer);
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
