using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContactApp.Services.Customers;
using ContactApp.Core.Domain.Customers;
using ContactApp.API.ViewModels.Customers;
using ContactApp.Data.Infrastructure;
using AutoMapper;

namespace ContactApp.API.Controllers
{
    [Route("api/Customers")]
    public class CustomersController : Controller
    {

        private ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public CustomersController(IUnitOfWork unitOfWork,
                                   ICustomerService customerService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _customerService = customerService;
            _mapper = mapper;
        }
        // GET api/customers
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetCustomers();

            var customersViewModel = _mapper.Map<IEnumerable<Customer>,
                                                IEnumerable<CustomerViewModel>>(customers);

            return new OkObjectResult(customersViewModel);
        }

        // GET api/customers/5
        [HttpGet("{id:int}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.GetCustomer(id);

            if (customer != null)
            {
                CustomerViewModel customerViewModel = _mapper.Map<Customer, CustomerViewModel>(customer);
                return new OkObjectResult(customerViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        // GET api/customers/mark
        [HttpGet("{userName}")]
        public IActionResult Get(string userName)
        {
            var customer = _customerService.GetCustomer(userName);

            if (customer != null)
            {
                CustomerViewModel customerViewModel = _mapper.Map<Customer, CustomerViewModel>(customer);
                return new OkObjectResult(customerViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]CustomerViewModel customerViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = _mapper.Map<CustomerViewModel, Customer>(customerViewModel);
            _customerService.CreateCustomer(customer);
            _unitOfWork.Commit();

            CreatedAtRouteResult result = CreatedAtRoute("GetCustomer",
                                                         new { controller = "Customers", id = customer.Id },
                                                         customer);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerFromDb = _customerService.GetCustomer(id);

            if (customerFromDb == null)
            {
                return NotFound();
            }
            else
            {
                Customer customer = _mapper.Map<CustomerViewModel, Customer>(customerViewModel);
                _customerService.UpdateCustomer(customer);
                _unitOfWork.Commit();
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customerFromDb = _customerService.GetCustomer(id);

            if (customerFromDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _customerService.DeleteCustomer(customerFromDb);
                _unitOfWork.Commit();
                return new NoContentResult();
            }
        }
    }
}
