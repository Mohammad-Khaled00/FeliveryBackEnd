using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerService CustomerRepo { get; set; }
        public CustomerController(ICustomerService customerRepo)
        {
            CustomerRepo = customerRepo;
        }
        [HttpGet]
        public ActionResult<List<Customer>> GetUsers()
        {
            return CustomerRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            return CustomerRepo.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            Customer CustomerData = CustomerRepo.Delete(id);
            return Ok(CustomerData);
        }
        [HttpPut]
        public ActionResult Put(Customer customer)
        {
            if (customer != null && customer.Id != 0)
            {
                CustomerRepo.Update(customer);
                return Ok(customer);
            }
            return NotFound();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registeration([FromBody] RegData Data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await CustomerRepo.Register(Data);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
