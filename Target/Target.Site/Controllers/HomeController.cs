using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Target.Domain.Interfaces;
using Target.Site.Models;

namespace Target.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public HomeController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            CustomersViewModel customersViewModel = new CustomersViewModel()
            {
                Customers = _customerRepository.GetList().ToList()
            };
            return View(customersViewModel);
        }

        [HttpPost]
        public bool DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer != null)
            {
                _customerRepository.Delete(id);
                return true;
            }
            else
                return false;
        }
    }
}
