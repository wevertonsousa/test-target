using Microsoft.AspNetCore.Mvc;
using Target.Domain.Entities;
using Target.Domain.Interfaces;

namespace Target.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _customerRepository.GetList();
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute] int Id)
        {
            var result = _customerRepository.GetById(Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Username))
                return BadRequest("Username is required");

            if (string.IsNullOrEmpty(customer.Fullname))
                return BadRequest("Fullname is required");

            if (customer.Role.Id == 0)
                return BadRequest("Role is required");

            var validateEmail = _customerRepository.ExistByEmail(customer.Email);
            if (validateEmail != 0)
                return BadRequest("Email is already being used.");

            var validateUsername = _customerRepository.ExistByUsername(customer.Username);
            if (validateUsername != 0)
                return BadRequest("Username is already being used.");

            _customerRepository.Insert(customer);
            return Ok(customer);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Username))
                return BadRequest("Username is required");

            if (string.IsNullOrEmpty(customer.Fullname))
                return BadRequest("Fullname is required");

            if (customer.Role.Id == 0)
                return BadRequest("Role is required");

            var validateEmail = _customerRepository.ExistByEmail(customer.Email);
            if (validateEmail != 0 && validateEmail != customer.Id)
                return BadRequest("Email is already being used.");

            var validateUsername = _customerRepository.ExistByUsername(customer.Username);
            if (validateUsername != 0 && validateUsername != customer.Id)
                return BadRequest("Username is already being used.");

            _customerRepository.Update(customer);
            return Ok(customer);
        }
    }
}
