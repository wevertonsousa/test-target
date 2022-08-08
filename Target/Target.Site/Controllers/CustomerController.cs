using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Target.Domain.Entities;
using Target.Domain.Interfaces;
using Target.Site.Models;

namespace Target.Site.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRoleRepository _roleRepository;
        public CustomerController(ICustomerRepository customerRepository, IRoleRepository roleRepository)
        {
            _customerRepository = customerRepository;
            _roleRepository = roleRepository;
        }
        public IActionResult Index([FromRoute]int? Id)
        {
            CustomerViewModel customerView = new CustomerViewModel()
            {
                Roles = _roleRepository.GetList().ToList()
            };

            if (Id != null)
            {
                var customer = _customerRepository.GetById(Id.Value);
                customerView.Customer = customer;
            }
            return View(customerView);
        }

        public IActionResult Customer()
        {
            return View("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Register(RegisterCustomerViewModel customer)
        {
            if (string.IsNullOrEmpty(customer.Username))
                return "Username is required";

            if (string.IsNullOrEmpty(customer.Fullname))
                return "Fullname is required";

            if (customer.Role == 0)
                return "Role is required";

            var validateEmail = _customerRepository.ExistByEmail(customer.Email);
            if (validateEmail != 0 && validateEmail != customer.Id)
                return "Email is already being used.";

            var validateUsername = _customerRepository.ExistByUsername(customer.Username);
            if (validateUsername != 0 && validateUsername != customer.Id)
                return "Username is already being used.";

            Customer _customer = new Customer
            {
                Id = customer.Id,
                Username = customer.Username,
                Fullname = customer.Fullname,
                Email = customer.Email,
                Active = customer != null,
                Country = customer.Country,
                Role = new Role { Id = customer.Role}
            };

            if (customer.BirthDate != "")
                _customer.BirthDate = Convert.ToDateTime(customer.BirthDate);

            if (_customer.Id == 0)
                _customerRepository.Insert(_customer);
            else
                _customerRepository.Update(_customer);

            return "OK";
        }
    }
}
