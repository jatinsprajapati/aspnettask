using Microsoft.AspNetCore.Mvc;
using Pinewood.DMS.API.Comman;
using Pinewood.DMS.API.DTO;
using Pinewood.DMS.API.Services;

namespace Pinewood.DMS.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _iCustomerService;
        public CustomerController(ICustomerService customerService)
        {
            _iCustomerService=customerService;  
        }

        [HttpPost(ApiRoutes.Customer.CreateCustomer)]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            var isCreate = await _iCustomerService.CreateCustomerAsync(request);
            if (isCreate == 0)
                return Ok(new ApiResponse() { Success = false, Errors = new List<string>() { "Customer not created, please try again" } });
            else
                return Ok(new ApiResponse() { Result = isCreate });
        }

        [HttpGet(ApiRoutes.Customer.GetCustomerById)]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await _iCustomerService.GetCustomerById(customerId);
            if (customer == null)
                return Ok(new ApiResponse() { Success = false, Errors = new List<string>() { "Customer Details not found, please try again" } });
            else
                return Ok(new ApiResponse() { Result = customer });
        }

        [HttpGet(ApiRoutes.Customer.GetCustomerList)]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> GetCustomerList()
        {
            var customerObj = await _iCustomerService.GetCustomerListAsync();
            if (customerObj == null)
                return Ok(new ApiResponse() { Success = false, Errors = new List<string>() { "Customer list not found" } });
            else
                return Ok(new ApiResponse() { Result = customerObj });
        }

        [HttpPost(ApiRoutes.Customer.UpdateCustomer)]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest request)
        {
            var isUpdate = await _iCustomerService.UpdateCustomerAsync(request);
            if (isUpdate == 0)
                return Ok(new ApiResponse() { Success = false, Errors = new List<string>() { "Customer not update, please try again" } });
            else
                return Ok(new ApiResponse() { Result = isUpdate });
        }

        [HttpPost(ApiRoutes.Customer.DeleteCustomer)]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> DeleteCustomer(IdDTO dto)
        {
            var isDelete = await _iCustomerService.DeleteCustomerAsync(dto);
            if (isDelete == 0)
                return Ok(new ApiResponse() { Success = false, Errors = new List<string>() { "Customer not delete, please try again" } });
            else
                return Ok(new ApiResponse() { Result = isDelete });
        }
    }
}
