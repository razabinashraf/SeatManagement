//using ExceptionHandling.Services;
//using Microsoft.AspNetCore.Mvc;
//namespace SeatManagement.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class CustomerController : Controller
//{
//    private readonly ICustomerService _customerService;
//    private readonly ILogger<CustomerController> _logger;

//    public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
//    {
//        _customerService = customerService;
//        _logger = logger;
//    }

//    [HttpGet]
//    public IActionResult GetCustomers()
//    {
//        try
//        {
//            _logger.LogInformation("Getting customer details");

//            var result = _customerService.GetCustomers();
//            if (result == null)
//                throw new ApplicationException("Getting errors while fetching customer details");

//            return Ok(result);
//        }
//        catch (Exception e)
//        {
//            _logger.LogError(e.Message);
//            return BadRequest("Internal server error");
//        }
//    }
//}