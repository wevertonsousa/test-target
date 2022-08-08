using Microsoft.AspNetCore.Mvc;

namespace Target.API.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
