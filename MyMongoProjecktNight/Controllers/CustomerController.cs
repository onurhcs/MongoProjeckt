using Microsoft.AspNetCore.Mvc;
using MyMongoProjecktNight.Dtos.CustomerDtos;
using MyMongoProjecktNight.Services;

namespace MyMongoProjecktNight.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
          await _customerService.CreateCustomerAsync(createCustomerDto);
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var customers = await _customerService.GetAllCustomerAsync();
            return View(customers);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerDelete(string id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(string id)
        {
            var customer = await _customerService.GetByIdCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            await _customerService.UpdateCustomerAsync(updateCustomerDto);
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDetails(string id)
        {
            var customer = await _customerService.GetByIdCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}
