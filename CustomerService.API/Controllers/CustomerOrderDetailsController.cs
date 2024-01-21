using CustomerService.API.Model;
using CustomerService.Application;
using Microsoft.AspNetCore.Mvc;


namespace CustomerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderDetailsController : ControllerBase
    {
        private readonly ICustomerOrderDetailsService _customerOrderDetailsService;
        public CustomerOrderDetailsController(ICustomerOrderDetailsService customerOrderDetailsService)
        {
                _customerOrderDetailsService = customerOrderDetailsService;
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomerOrderDetails([FromBody] CustomerInput customerInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var customerOrderDetails = await _customerOrderDetailsService.GetCustomerOrderDetails(customerInput.User, customerInput.CustomerId);
                return Ok(customerOrderDetails);
            }
            catch (Exception ex)
            {
                // log exception in db or newrelic
                return BadRequest();
            }
           
        }
    
    }
}
